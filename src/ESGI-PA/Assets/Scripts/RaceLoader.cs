using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaceLoader : MonoBehaviour
{
    [SerializeField] private RaceConfig config;

    [SerializeField] private PlayerInputManager manager;
    // Start is called before the first frame update
    [SerializeField] private GameObject playerPrefab;
    void Start()
    {
        manager.playerPrefab = playerPrefab;
        for (var i = 0; i < config.gamepads.Length; i++)
        {
            manager.JoinPlayer(i, i, "default", config.gamepads[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(config.gamepads[0]);
        
    }
}
