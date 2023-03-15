using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private gameloop trackInfo;

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
    }
}
