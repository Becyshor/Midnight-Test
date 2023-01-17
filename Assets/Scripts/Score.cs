using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private LevelWin levelWin;
    private string scoreKey = "Score";
    private int playerKills = 0;
    public int CurrentScore { get; set; }

    private void Awake()
    {
        CurrentScore = PlayerPrefs.GetInt(scoreKey);
    }

    private void Start()
    {
        playerKills = CurrentScore;
        levelWin = GetComponent<LevelWin>();
    }

    public int GetPlayerKills()
    {
        return playerKills;
    }

    public void IncreasePlayerKills()
    {
        playerKills++;
        if (playerKills == levelWin.killsToWin)
        {
            levelWin.DisplayLevelWin();
        }
    }

    public void SetScore(int score)
    {
        PlayerPrefs.SetInt(scoreKey, score);
    }
}
