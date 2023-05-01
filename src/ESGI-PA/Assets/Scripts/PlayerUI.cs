using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerUI : MonoBehaviour
{
    public GameLoop loop;
    public GameObject player;
    public TextMeshProUGUI turnText;
    // Start is called before the first frame update
    private PlayerState info;
    private bool loaded = false;
    
    
    void Start()
    {
        StartCoroutine(GetPlayerInfo());
        turnText = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        updateTurns();
    }

    private void updateTurns()
    {
        if (!loaded) return;
        info = loop.PlayerInfo[player];
        Debug.Log("Info : "+ info.turnCount + ":" + info.currentCheckpoint + ":" + info.lastCheckpoint);
        
        turnText.text = "Turn : " + info.turnCount + "/2";
    }

    private IEnumerator GetPlayerInfo()
    {
        yield return new WaitForSeconds(1);
        info = loop.PlayerInfo[player];
        loaded = true;
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
