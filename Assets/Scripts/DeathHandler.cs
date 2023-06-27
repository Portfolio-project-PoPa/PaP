using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverCanvas;

    void Start()
    {
        _gameOverCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    
    public void Handle()
    {
        _gameOverCanvas.SetActive(true);
        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
