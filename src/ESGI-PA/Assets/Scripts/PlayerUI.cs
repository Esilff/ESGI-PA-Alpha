using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerUI : MonoBehaviour
{
    public GameObject player;

    private CarController playerController;
    public TextMeshProUGUI turnText;
    // Start is called before the first frame update
    void Start()
    {
        playerController = player.GetComponent<CarController>();
        turnText = gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        updateTurns();
    }

    private void updateTurns()
    {
        turnText.text = "Turn : " + playerController.Turn + "/2";
    }

    /*
    private List<GameObject> GetChildrens()
    {
        List<GameObject> list = new();
        for (var i = 0; i < gameObject.transform.childCount; i++)
        {
            list.Add(gameObject.transform.GetChild(i).gameObject);
        }
        return list;
    }
    */


}
