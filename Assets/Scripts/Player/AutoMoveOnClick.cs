using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AutoMoveOnClick : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent agent;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Debug.Log(agent);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetFloat("vertical", 1f);

            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                Debug.Log(hit.point);
                agent.SetDestination(hit.point);
                Debug.Log(agent.destination);
            }
        }
        if (transform.position == agent.destination)
        {
            anim.SetFloat("vertical", 0f);
        }
    }
}
