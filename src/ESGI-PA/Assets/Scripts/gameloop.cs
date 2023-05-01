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

    private List<GameObject> players;
    void Start()
    {
        StartCoroutine(GetPlayers());
        foreach (var checkpoint in checkpoints)
        {
            checkpoint.Loop = gameObject.GetComponent<GameLoop>();
        }
    }

    void Update()
    {
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
        foreach (var o in objects)
        {
            playersInfo.Add(o, new PlayerState());
        }
        hasStarted = true;
    }

    private bool CheckEndgame()
    {
        if (!hasStarted) return false;
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
