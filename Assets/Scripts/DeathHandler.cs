using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private Canvas _gameOverCanvas;

    void Start()
    {
        _gameOverCanvas.enabled = false;
        Time.timeScale = 1;
    }
    
    public void Handle()
    {
        _gameOverCanvas.enabled = true;
        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
