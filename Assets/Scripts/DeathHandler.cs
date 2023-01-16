using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private Canvas gameOverWindow;
    [SerializeField] private Canvas ammoDisplay;

    private void Start()
    {
        gameOverWindow.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverWindow.enabled = true;
        ammoDisplay.enabled = false;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
