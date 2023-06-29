using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private int _ammoAmount = 5;
    [SerializeField] private AmmoType _ammoType;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Ammo>().IncreaseCurrentAmount(_ammoType, _ammoAmount);
            Destroy(gameObject);
        }
    }
}
