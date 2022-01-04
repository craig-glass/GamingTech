using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DevilBulldogStateManager : MonoBehaviour
{
    public DevilBulldogBaseState currentState;
    public DevilBulldogIdleState IdleState = new DevilBulldogIdleState();
    public DevilBulldogHuntState HuntState = new DevilBulldogHuntState();
    public DevilBulldogFightState FightState = new DevilBulldogFightState();
    public DevilBulldogEatState EatState = new DevilBulldogEatState();
    public DevilBulldogGotoHamState GotoHamState = new DevilBulldogGotoHamState();
    public DevilBulldogPatrolState PatrolState = new DevilBulldogPatrolState();


    public HamStateManager hamStateManager;
    public PlayerStateManager playerStateManager;
    
    public GameObject player;
    public NavMeshAgent agent;
    public Animator anim;
    public GameObject[] ham;
    public GameObject hamCloseBy;
    public Rigidbody r;
    Renderer renderer;
    CapsuleCollider collider;
    public GameObject[] waypoints;
    public GameObject firstWaypoint;
    public int currentWP;
    public Vector3 startPos;

    public bool chase = false;
    public bool eat = false;
    public float timeInState;

    
    private HealthBar healthBar;
    public bool isDead = false;


    private void Awake()
    {
        player = GameObject.Find("Player");
        playerStateManager = player.GetComponent<PlayerStateManager>();
        r = GetComponent<Rigidbody>();
        renderer = GetComponentInChildren<Renderer>();
        collider = GetComponentInChildren<CapsuleCollider>();
        r.velocity = Vector3.zero;
        firstWaypoint = transform.parent.GetChild(0).gameObject;
        healthBar = GetComponent<HealthBar>();
        ham = GameObject.FindGameObjectsWithTag("ham");
    }
    // Start is called before the first frame update
    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
        startPos = transform.position;
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
            healthBar.DeductHealth();
            if (healthBar.health <= 0)
            {
                if (currentState == HuntState)
                    World1State.devilBulldogsChasing.Remove(gameObject);
                StartCoroutine("Die");
            }
            else
            {
                anim.SetTrigger("hit");
                if (currentState != HuntState)
                    SwitchState(HuntState);
            }
            
        }
        if (collision.gameObject.CompareTag("Player"))
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
                return true;
            }
        }
        return false;
    }

    public bool CanSeeHam(GameObject ham)
    {
        Vector3 hamPosition = ham.transform.position;
        Vector3 rayPos = transform.position;
        Vector3 rayDir = (hamPosition -rayPos);

        RaycastHit info;
        if (Physics.Raycast(rayPos, rayDir, out info))
        {
            Debug.DrawRay(rayPos, rayDir, Color.green);
            if (info.transform.gameObject.CompareTag("ham"))
            {
                return true;
            }
        }
        return false;
    }

    IEnumerator Die()
    {
        agent.ResetPath();
        collider.enabled = false;
        isDead = true;
        agent.isStopped = true;
        anim.SetTrigger("Death");

        yield return new WaitForSeconds(3f);
        renderer.enabled = false;
        
        yield return new WaitForSeconds(0.2f);
        renderer.enabled = true;

        yield return new WaitForSeconds(0.2f);
        renderer.enabled = false;

        yield return new WaitForSeconds(0.2f);
        renderer.enabled = true;

        yield return new WaitForSeconds(0.2f);
        renderer.enabled = false;

        yield return new WaitForSeconds(0.2f);
        renderer.enabled = true;

        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);

        
    }
}
