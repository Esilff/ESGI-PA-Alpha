using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerState
{
    public int turnCount;
    public int currentCheckpoint;
    public int lastCheckpoint;
}

public class GameLoop : MonoBehaviour
{
    //Should contain a list of checkpoint, checkpoint 0 will determine the time when a user win a turn
    [SerializeField] private List<Checkpoint> checkpoints;
    private GameObject testIndex;
    public List<Checkpoint> Checkpoints
    {
        get => checkpoints;
    }

    private Dictionary<GameObject, PlayerState> playersInfo;

    public Dictionary<GameObject, PlayerState> PlayerInfo
    {
        get => playersInfo;
        set => playersInfo = value;
    }

    public int maxTurn = 2;

    private bool hasStarted = false;
    // Start is called before the first frame update

    private List<GameObject> players;
    void Start()
    {
        // checkpoints = new();
        StartCoroutine(GetPlayers());
        foreach (var checkpoint in checkpoints)
        {
            checkpoint.Loop = gameObject.GetComponent<GameLoop>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Infos : " + playersInfo[testIndex].turnCount + ":" + playersInfo[testIndex].currentCheckpoint);
        if (CheckEndgame())
        {
            Debug.Log("GAME HAS ENDED");
        }
    }

    private IEnumerator GetPlayers()
    {
        playersInfo = new();
        yield return new WaitForSeconds(0.5f);
        GameObject[] objects =  GameObject.FindGameObjectsWithTag("Player");
        players = new List<GameObject>(objects);
        testIndex = objects[0];
        foreach (var o in objects)
        {
            playersInfo.Add(o, new PlayerState());
        }
        Debug.Log(playersInfo.Count);
        hasStarted = true;

    }

    private bool CheckEndgame()
    {
        foreach (var player in players)
        {
            if (playersInfo[player].turnCount < 2)
            {
                return false;
            }
        }
        return true;
    }
}
