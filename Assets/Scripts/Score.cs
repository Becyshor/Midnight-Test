using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI killsText;

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

    private void Update()
    {
        DisplayPlayerKills();
    }

    public void DisplayPlayerKills()
    {
        killsText.text = "Kills: " + GetPlayerKills().ToString();
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
