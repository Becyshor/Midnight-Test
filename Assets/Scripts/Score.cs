using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI killsText;

    private int playerKills = 0;

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
}
