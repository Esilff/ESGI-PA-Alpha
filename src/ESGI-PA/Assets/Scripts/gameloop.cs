using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameloop : MonoBehaviour
{
    public List<GameObject> checkpoints = new List<GameObject>();
    public GameObject currentCheckpoint;
    public GameObject nextCheckpoint;
    public int nbtours = 0;
    public int tours = 0;
    private bool isFinished = false;
    void Start()
    {
        for (int i = 0; i < checkpoints.Count; i++)
        {
            checkpoints[i].SetActive(false);
        }
        checkpoints[0].SetActive(true);
        currentCheckpoint = checkpoints[0];
        nextCheckpoint = checkpoints[1];
    }
    void Update()
    {
        if (isFinished) return;
        if (currentCheckpoint.GetComponent<checkpoint>().passed == true && currentCheckpoint != checkpoints[checkpoints.Count - 1])
        {
            currentCheckpoint.SetActive(false);
            currentCheckpoint = nextCheckpoint;
            currentCheckpoint.SetActive(true);
            nextCheckpoint = checkpoints[checkpoints.IndexOf(currentCheckpoint) + 1];
            
            
        }
        if (currentCheckpoint.GetComponent<checkpoint>().passed == true && currentCheckpoint == checkpoints[checkpoints.Count - 1])
        {
            tours++;

            if (tours < nbtours)
            {
                foreach(GameObject checkpoint in checkpoints)
                {
                    checkpoint.SetActive(false);
                    checkpoint.GetComponent<checkpoint>().passed = false;
                }
                checkpoints[0].SetActive(true);
                currentCheckpoint = checkpoints[0];
                nextCheckpoint = checkpoints[1];
            }
            else
            {
                Debug.Log("end of the game");
                isFinished = true;
            }

        }
        
    }

}
