using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update

    private GameLoop loop;

    public GameLoop Loop
    {
        get => loop;
        set => loop = value;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            int checkpointIndex = Loop.Checkpoints.IndexOf(gameObject.GetComponent<Checkpoint>());
            var info = Loop.PlayerInfo[other.gameObject];
            info.lastCheckpoint = info.currentCheckpoint;
            info.currentCheckpoint = checkpointIndex;
            if ((checkpointIndex == 0 && info.lastCheckpoint > Loop.Checkpoints.Count * 0.8f) || (info.lastCheckpoint > Loop.Checkpoints.Count / 2 && checkpointIndex > 0))
            {
                info.turnCount++;
            }
            Loop.PlayerInfo[other.gameObject] = info;
            Debug.Log(info.lastCheckpoint + ";" + checkpointIndex + ":" + info.turnCount);
        }
    }
}
