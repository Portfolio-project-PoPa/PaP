using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private float _zoomInFOV = 40f;
    [SerializeField] private float _zoomOutFOV = 60f;
    [SerializeField] private float _zoomInSensitivity = 0.5f;
    [SerializeField] private float _zoomOutSensitivity = 2f;

    private RigidbodyFirstPersonController _rigidbodyFirstPersonController;
    private Camera _mainCamera;

    private void Start()
    {
        _rigidbodyFirstPersonController = GetComponent<RigidbodyFirstPersonController>();
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            SetMouseSensitivity(_zoomInSensitivity);
            _mainCamera.fieldOfView = _zoomInFOV;
        }
        else
        {
            SetMouseSensitivity(_zoomOutSensitivity);
            _mainCamera.fieldOfView = _zoomOutFOV;
        }
    }

    private void SetMouseSensitivity(float sensitivity)
    {
        _rigidbodyFirstPersonController.mouseLook.XSensitivity = sensitivity;
        _rigidbodyFirstPersonController.mouseLook.YSensitivity = sensitivity;
    }
}
