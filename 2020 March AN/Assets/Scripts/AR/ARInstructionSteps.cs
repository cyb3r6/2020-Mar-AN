using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARInstructionSteps : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject initializeHeatCanvas;
    public GameObject saltWaterCanvas;

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
        steps.Clear();

        for(int i = 0; i < initializeHeatCanvas.transform.childCount - 2; i++)
        {
            steps.Add(initializeHeatCanvas.transform.GetChild(i).gameObject);
            Debug.Log("The steps are " + steps[i]);
        }
    }

    public void TurnOnSaltWaterCanvas()
    {
        saltWaterCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
        currentCanvas = saltWaterCanvas;

        steps.Clear();

        for (int i = 0; i < saltWaterCanvas.transform.childCount - 2; i++)
        {
            steps.Add(saltWaterCanvas.transform.GetChild(i).gameObject);
            Debug.Log("The steps are " + steps[i]);
        }
    }

    // TODO: add another set of instructions!
    //       add sounds to buttons!

    public void NextStep()
    {
        steps[currentStep].SetActive(false);

        if(currentStep == steps.Count - 1)
        {
            currentStep = 0;
            steps[currentStep].SetActive(true);
            currentCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);

            return;
        }

        steps[++currentStep].SetActive(true);
    }

    public void PreviousStep()
    {
        steps[currentStep].SetActive(false);

        if(currentStep <= 0)
        {
            currentStep = 0;
            steps[currentStep].SetActive(true);

            return;
        }

        steps[--currentStep].SetActive(true);
    }
}
