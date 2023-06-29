using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private AmmoSlot[] _ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType AmmoType;
        public int AmmoAmount;
    }

    public int GetCurrentAmount(AmmoType ammoType)
    {
        return GetAmmoSlot(ammoType).AmmoAmount;
    }

    public void ReduceCurrentAmount(AmmoType ammoType)
    {
        GetAmmoSlot(ammoType).AmmoAmount--;
    }

    public void IncreaseCurrentAmount(AmmoType ammoType, int amount)
    {
        GetAmmoSlot(ammoType).AmmoAmount += amount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType)
    {
        foreach (AmmoSlot slot in _ammoSlots)
        {
            if (slot.AmmoType == ammoType)
            {
                return slot;
            }
        }

        return null;
    }
}
