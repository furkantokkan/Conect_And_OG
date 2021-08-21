using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
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
    public GameObject playButton;
    
    public void PlayButtonFunc()
    {
        LevelManager.gameState = GameState.Normal;
        playButton.SetActive(false);
    }
}
