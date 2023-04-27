using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaceLoader : MonoBehaviour
{
    [SerializeField] private RaceConfig config;

    [SerializeField] private PlayerInputManager manager;
    // Start is called before the first frame update
    [SerializeField] private GameObject playerPrefab;

    private int playerJoined;

    private Rect[] viewportDuo =
    {
        new Rect(0,0,1,0.5f),
        new Rect(0,0.5f,1,0.5f)
    };
    
    void Start()
    {
        playerJoined = 0;
        manager.playerPrefab = playerPrefab;
        if (config.devices.Count <= 1) manager.splitScreen = false;
        //manager.splitScreen = true;
        for (var i = 0; i < config.devices.Count; i++)
        {
            
            if (config.devices[i] is Gamepad)
            {
                manager.JoinPlayer(i, i, "gamepad", config.devices[i]);
                continue;
            }
            if (config.devices[i] is Keyboard)
            {
                manager.JoinPlayer(i, i, "keyboard", config.devices[i]);
            }
            
            //Debug.Log("Player joining");
        }

        // manager.splitScreen = true;
        /*for (var i = 0; i < config.devices.Count(); i++)
        {
            manager.JoinPlayer(i, i, "default", config.devices[i]);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < config.devices.Count; i++)
        {
            //Debug.Log("Device " + i + " : " + config.devices[i]);
        }
    }

    public void setViewport(PlayerInput player)
    {
        /*player.gameObject.GetComponentInChildren<Camera>().rect = new Rect();
        
        Debug.Log("Setting viewport");*/
        if (config.devices.Count == 1)
        {
            player.gameObject.GetComponentInChildren<Camera>().rect = new Rect(0,0,1,1);
        }
        if (config.devices.Count == 2)
        {
            player.gameObject.GetComponentInChildren<Camera>().rect = viewportDuo[playerJoined];
        }

        playerJoined++;
    }
}
