using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowPlayerKills : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI killsText;
    private Score score;

    private void Start()
    {
        score = GetComponent<Score>();
    }

    private void Update()
    {
        DisplayPlayerKills();
    }

    public void DisplayPlayerKills()
    {
        killsText.text = "Kills: " + score.GetPlayerKills().ToString();
    }
}
