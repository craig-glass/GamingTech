using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanelController : MonoBehaviour
{
    public static GameObject gameOverPanel;
    GameObject panelText;
    Text text;

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel = GameObject.Find("GameOverPanel");
        panelText = GameObject.Find("TextGameOver");
        text = panelText.GetComponent<Text>();
        text.text = "Paused";
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.gameOver)
        {
            text.text = "Game Over";
            gameOverPanel.SetActive(true);
        }
        
    }
}
