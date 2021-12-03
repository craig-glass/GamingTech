using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    string portalName;

    GameObject gameManagerObject;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            switch (portalName)
            {
                case "world1": gameManager.SwitchState(gameManager.World1state); break;
                case "catclimb": gameManager.SwitchState(gameManager.CatClimbState); break;
                case "targets": gameManager.SwitchState(gameManager.TargetsState); break;
                
            }
        }
    }
}
