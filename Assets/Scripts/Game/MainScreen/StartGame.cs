using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StartGame : MonoBehaviour
{
    Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton = GetComponent<Button>();
        startButton.onClick.AddListener(GameStart);
    }

    void GameStart()
    {
        Debug.Log("Game Start");
        GameManager.Instance.gameOver = false;
        GameManager.Instance.lives = 3;
        GameManager.Instance.SwitchState(GameManager.Instance.OverworldState);
        GameManager.Instance.SetDifficultySettings();
    }
}
