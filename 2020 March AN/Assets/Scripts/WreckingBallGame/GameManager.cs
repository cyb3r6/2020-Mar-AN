using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int numberofCubesDestroyed;
    
    void Awake()
    {
        // Singleton pattern
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void CountCubesDestroyed()
    {
        numberofCubesDestroyed = numberofCubesDestroyed + 1;
        Debug.Log("cubes destroyed: " + numberofCubesDestroyed);
    }
}
