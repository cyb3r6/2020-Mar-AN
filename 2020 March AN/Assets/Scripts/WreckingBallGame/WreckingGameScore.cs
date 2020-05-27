using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WreckingGameScore : MonoBehaviour
{
    public Text wreckingText;
    void Update()
    {
        wreckingText.text = "You've killed: " + GameManager.instance.numberofCubesDestroyed.ToString();
    }
}
