using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    private void Awake()
    {
        instance = this;
        gameState = GameState.BeforeStart;
    }
    public static GameState gameState;

    void Start()
    {
        
    }
}
