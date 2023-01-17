using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
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
    }

    public int GetPlayerKills()
    {
        return playerKills;
    }

    public void IncreasePlayerKills()
    {
        playerKills++;
    }

    public void SetScore(int score)
    {
        PlayerPrefs.SetInt(scoreKey, score);
    }
}
