using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private Canvas gameOverWindow;

    private void Start()
    {
        gameOverWindow.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverWindow.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
