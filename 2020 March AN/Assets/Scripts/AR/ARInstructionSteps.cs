using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARInstructionSteps : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject initializeHeatCanvas;

    // TODO: more gameobject canvas for instruciton steps!

    private List<GameObject> steps = new List<GameObject>();
    private int currentStep = 0;
    private GameObject currentCanvas;

    public void TurnOnHeatSequenceCanvas()
    {
        initializeHeatCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
        currentCanvas = initializeHeatCanvas;

        // add the steps to our list!

        for(int i = 0; i < initializeHeatCanvas.transform.childCount -1; i++)
        {
            steps.Add(initializeHeatCanvas.transform.GetChild(i).gameObject);
            Debug.Log("The steps are " + steps[i]);
        }
    }
}
