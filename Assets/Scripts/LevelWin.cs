using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelWin : MonoBehaviour
{
    [SerializeField] private Canvas levelWinWindow;
    [SerializeField] private TextMeshProUGUI finalScore;
    private AudioSource audioSource;
    public int killsToWin;

    private Score score;

    void Start()
    {
        score = GetComponent<Score>();
        levelWinWindow.enabled = false;
        audioSource = GetComponent<AudioSource>();
    }

    public void LevelPassed()
    {
        StartCoroutine(DisplayLevelWin());
    }

    IEnumerator DisplayLevelWin()
    {
        yield return new WaitForSeconds(2);
        audioSource.Play();
        levelWinWindow.enabled = true;
        finalScore.text = "You Scored " + score.GetPlayerKills() + " kills!";
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
