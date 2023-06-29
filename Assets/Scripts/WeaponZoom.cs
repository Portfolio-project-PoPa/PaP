using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private RigidbodyFirstPersonController _fpsController;
    [SerializeField] private float _zoomInFOV = 40f;
    [SerializeField] private float _zoomOutFOV = 60f;
    [SerializeField] private float _zoomInSensitivity = 0.5f;
    [SerializeField] private float _zoomOutSensitivity = 2f;

    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
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
        _fpsController.mouseLook.XSensitivity = sensitivity;
        _fpsController.mouseLook.YSensitivity = sensitivity;
    }
}
