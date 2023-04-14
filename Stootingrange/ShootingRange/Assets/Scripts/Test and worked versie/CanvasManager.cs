using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public Text health;

    public void UpdateHealth(string healthText)
    {
        this.health.text = healthText;
    }
}
