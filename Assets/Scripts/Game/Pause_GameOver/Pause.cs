using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static GameObject pauseMenu;

    private void Awake()
    {
        pauseMenu = GameObject.Find("PauseMenu");
    }
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.paused)
        {
            pauseMenu.SetActive(true);
        }
    }
}
