using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private Canvas gameOverWindow;
    [SerializeField] private TextMeshProUGUI finalScore;
    [SerializeField] private Canvas ammoDisplay;
    [SerializeField] private Score score;

    private void Start()
    {
        gameOverWindow.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverWindow.enabled = true;
        finalScore.text = "You Scored " + score.GetPlayerKills() + " kills!";
        ammoDisplay.enabled = false;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
