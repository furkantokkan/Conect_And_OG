using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool gameIsRunning;
    private int score;
    public int GetScore { get { return score; } set { score = value; } }
    public bool GetGameIsRunning { get { return gameIsRunning} set { gameIsRunning = value; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        
    }
}
