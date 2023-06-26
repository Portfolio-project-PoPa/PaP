using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private float _zoomInFOV = 40f;
    [SerializeField] private float _zoomOutFOV = 60f;

    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            _mainCamera.fieldOfView = _zoomInFOV;
        }
        else
        {
            _mainCamera.fieldOfView = _zoomOutFOV;
        }
    }
}
