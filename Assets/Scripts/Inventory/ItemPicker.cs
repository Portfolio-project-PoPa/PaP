using System;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    private Inventory _inventory;

    private void Start()
    {
        _inventory = new Inventory();
    }

    private void Update()
    {
        float range = 2f;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(_mainCamera.transform.position,
                    _mainCamera.transform.forward,
                    out RaycastHit raycastHit))
            {
                if (raycastHit.transform.TryGetComponent(out Item item))
                {
                    Pick(item);
                }
            }
        }
    }

    private void Pick(Item item)
    {
        _inventory.Take(item);
        Destroy(item.gameObject);
    }
}