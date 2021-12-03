using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DevilBulldogStateManager : MonoBehaviour
{
    public DevilBulldogBaseState currentState;
    public DevilBulldogIdleState IdleState = new DevilBulldogIdleState();
    public DevilBulldogHuntState HuntState = new DevilBulldogHuntState();
    public DevilBulldogFightState FightState = new DevilBulldogFightState();
    public DevilBulldogEatState EatState = new DevilBulldogEatState();
    public DevilBulldogGotoHamState GotoHamState = new DevilBulldogGotoHamState();

    public HamStateManager hamStateManager;
    
    public GameObject player;
    public NavMeshAgent agent;
    public Animator anim;
    public GameObject ham;
    public Rigidbody r;

    public bool chase = false;
    public bool eat = false;


    public float timeLeft = 20f;


    private void Awake()
    {
        player = GameObject.Find("Player");
        r = GetComponent<Rigidbody>();
        r.velocity = Vector3.zero;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentState = IdleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            anim.SetTrigger("hit");
        }
    }


    public void SwitchState(DevilBulldogBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public bool CanSeePlayer()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 rayPos = transform.position;
        Vector3 rayDir = (playerPosition - rayPos);

        RaycastHit info;
        if (Physics.Raycast(rayPos, rayDir, out info))
        {
            Debug.DrawRay(rayPos, rayDir, Color.red);
            if (info.transform.gameObject.CompareTag("Player"))
            {
                Debug.Log("see player");
                return true;
            }
        }
        return false;
    }

    public bool CanSeeHam()
    {
        Vector3 hamPosition = ham.transform.position;
        Vector3 rayPos = transform.position;
        Vector3 rayDir = (hamPosition - rayPos);

        RaycastHit info;
        if (Physics.Raycast(rayPos, rayDir, out info))
        {
            Debug.DrawRay(rayPos, rayDir, Color.green);
            if (info.transform.gameObject.CompareTag("ham"))
            {
                Debug.Log("see ham");
                return true;
            }
        }
        return false;
    }
}
