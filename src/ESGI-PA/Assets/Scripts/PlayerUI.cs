using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerUI : MonoBehaviour
{
    public GameLoop loop;
    public GameObject player;
    public TextMeshProUGUI turnText;

    private PlayerState info;
    private bool _loaded = false;

    void Start()
    {
        StartCoroutine(GetPlayerInfo());
        turnText = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }
    
    void Update()
    {
        updateTurns();
    }

    private void updateTurns()
    {
        if (!_loaded) return;
        info = loop.PlayerInfo[player];
        turnText.text = "Turn : " + info.turnCount + "/2";
    }

    private IEnumerator GetPlayerInfo()
    {
        yield return new WaitForSeconds(1);
        info = loop.PlayerInfo[player];
        _loaded = true;
    }
}
