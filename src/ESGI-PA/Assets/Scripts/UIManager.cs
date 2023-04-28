using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    /*[SerializeField] private gameloop trackInfo;

    [SerializeField] private TMP_Text trackTurn;
    // Start is called before the first frame update
    void Start()
    {
        trackTurn.text = "Turn : ";
    }

    // Update is called once per frame
    void Update()
    {
        trackTurn.text = "Turn : " + trackInfo.tours + "/" + trackInfo.nbtours;
    }*/
    [SerializeField] private GameObject[] uiList;
    [SerializeField] private RaceConfig config;
    public GameObject[] Players;

    private void Start()
    {
        StartCoroutine(SetUIConfig());
    }

    public IEnumerator SetUIConfig()
    {
        yield return new WaitForSeconds(0.1f);
        switch (config.devices.Count)
        {
            case 1:
                uiList[0].SetActive(true);
                break;
            case 2:
                uiList[1].SetActive(true);
                break;
            case 3:
                uiList[2].SetActive(true);
                break;
            case 4:
                uiList[3].SetActive(true);
                break;
        }
        LinkUI(config.devices.Count);
    }

    private void LinkUI(int players)
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
        //Debug.Log(Players.Length);
       // Debug.Log("UI list : " + uiList[players - 1]);
        //Debug.Log(uiList[0].gameObject.transform.GetChild(0));
        //Debug.Log(uiList[players - 1].gameObject.transform.childCount);
        for (var i = 0; i < players; i++)
        {
            //Debug.Log("i : " + i);
            uiList[players - 1].gameObject.transform.GetChild(i).gameObject.GetComponent<PlayerUI>().player =
                Players[i];
            //Debug.Log(Players[i]);
        }
        /*foreach (var player in Players)
        {
            uiList
        }*/
    }
}
