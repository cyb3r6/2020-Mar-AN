using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotCounter : MonoBehaviour
{
    private Text shotCounterText;
    public int shotsFired;

    void Start()
    {
        shotCounterText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        shotCounterText.text = "Shots fired: " + shotsFired;
    }
}
