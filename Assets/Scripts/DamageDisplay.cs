using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDisplay : MonoBehaviour
{
    [SerializeField] private Canvas damageDisplay;
    [SerializeField] private float displayTime = 0.2f;

    private void Start()
    {
        damageDisplay.enabled = false;
    }

    public void ShowDamageDisplay()
    {
        StartCoroutine(ShowRedScreen());
    }

    IEnumerator ShowRedScreen()
    {
        damageDisplay.enabled = true;
        yield return new WaitForSeconds(displayTime);
        damageDisplay.enabled = false;
    }
}
