using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private int _ammoAmount = 10;

    public int GetCurrentAmount()
    {
        return _ammoAmount;
    }

    public void ReduceCurrentAmount()
    {
        _ammoAmount--;
    }
}
