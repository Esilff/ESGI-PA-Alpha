using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerEvents : MonoBehaviour
{
    [SerializeField] private PlayerInputManager manager;

    [SerializeField] private RaceConfig raceConfig;

    [SerializeField] private MenuController menu;
    // Start is called before the first frame update
    private int gamepadCount = 0;
    private int previousCount = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //manager.JoinPlayer(manager.playerCount, manager.playerCount, "default", Gamepad.all.ToArray());
        /*Debug.Log("Gamepad count : " + gamepadCount);
        Debug.Log("Player count : " + manager.playerCount);*/
        //Debug.Log("Gamepads : " + Gamepad.all.ToArray()[0]);
        if (gamepadCount != Gamepad.all.Count)
        {
            previousCount = gamepadCount;
            gamepadCount = Gamepad.all.Count;
            if (Gamepad.all.Count < previousCount)
            {
                /*Debug.Log("Removing controller");
                Debug.Log("Count at removing : " + previousCount);*/
                menu.playerImages[previousCount - 1].color = Color.gray;
            }
            else
            {
                /*Debug.Log("Adding controller");
                Debug.Log("Count at adding : " + (gamepadCount - 1));*/
                menu.playerImages[gamepadCount - 1].color = Color.white;
            }
        }
    }

    private void OnDestroy()
    {
        raceConfig.gamepads = Gamepad.all.ToArray();
    }
}