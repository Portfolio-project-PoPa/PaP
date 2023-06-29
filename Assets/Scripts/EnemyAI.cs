using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(EnemyHealth))]
[RequireComponent(typeof(Animator))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _chaseRange = 8f;
    [SerializeField] float _turnSpeed = 5f;

    private NavMeshAgent _agent;
    private EnemyHealth _health;
    private Animator _animator;
    private Transform _target;

    private float _distanceToTarget = Mathf.Infinity;
    private bool _isProvoked;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _target = FindObjectOfType<PlayerHealth>().transform;
        _health = GetComponent<EnemyHealth>();
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (_health.IsDead())
        {
            enabled = false;
            _agent.enabled = false;
            GetComponent<CapsuleCollider>().isTrigger = true;
            return;
        }

        _distanceToTarget = Vector3.Distance(_target.position, transform.position);
        
        if (_isProvoked)
        {
            EngageTarget();
        }
        else if (_distanceToTarget <= _chaseRange)
        {
            _isProvoked = true;
        }
    }

    private void EngageTarget()
    {
        FaceTarget();

        if (_distanceToTarget > _agent.stoppingDistance)
        {
            ChaseTarget();
        }
        else
        {
            AttackTarget();
        }
    }

    public void OnDamageTaken()
    {
        _isProvoked = true;
    }

    private void AttackTarget()
    {
        _animator.SetBool("attack", true);
    }

    private void ChaseTarget()
    {
        _animator.SetBool("attack", false);
        _animator.SetTrigger("move");

        _agent.SetDestination(_target.position);
    }

    private void FaceTarget()
    {
        Vector3 direction = (_target.position - transform.position).normalized;

        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _turnSpeed);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _chaseRange);
    }
}
