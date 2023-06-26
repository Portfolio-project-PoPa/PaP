using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _chaseRange;
    [SerializeField] private float _damage;

    private NavMeshAgent _agent;
    private float _distanceToTarget = Mathf.Infinity;
    private bool _isProvoked;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
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
        if (_target.TryGetComponent(out PlayerHealth playerHealth))
            playerHealth.TakeDamage(_damage);
    }

    private void ChaseTarget()
    {
        _agent.SetDestination(_target.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _chaseRange);
    }
}
