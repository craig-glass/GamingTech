using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField]
    int ringNo;
    bool canTrigger = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (canTrigger)
        {
            if (other.gameObject.CompareTag("bullet"))
            {
                Debug.Log("Hit " + ringNo + " " + other.gameObject.name);
                GameManager.Instance.score += ringNo;
                Score.scoreText.text = "Score: " + GameManager.Instance.score;
                canTrigger = false;
            }
            
        }
        
        
    }
   
}
