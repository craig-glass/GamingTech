using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    public PlayerBaseState currentState;
    public PlayerIdleState IdleState = new PlayerIdleState();
    public PlayerWalkState WalkState = new PlayerWalkState();
    public PlayerRunState RunState = new PlayerRunState();
    public PlayerJumpState JumpState = new PlayerJumpState();
    public PlayerSprintState SprintState = new PlayerSprintState();

    public Animator anim;
    public GameObject playerObject;
    float jumpForce = 50f;
    public Rigidbody r;
    public bool hasJumped = false;
    public bool onGround = true;
    public Ham ham;
    public bool hamIsPickedUp = false;
    public bool holdingGun = false;
    public bool throwHam = false;

    public Vector3 startPos;

    [SerializeField]
    GameObject bullet, bulletSpawnPoint, hamObject, holdHam, gun, gunMag;
    public float speed = 4f;
    float rotationForce = 70f;
    public float sprintSpeed;

    // Effects

    private void Awake()
    {
        r = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = IdleState;
        currentState.EnterState(this);
    }

    private void FixedUpdate()
    {
        if (hasJumped)
        {
            r.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
            hasJumped = false;
        }
        
        if (throwHam)
        {
            ham.ThrowHam();
            throwHam = false;
        }

        currentState.FixedUpdateState(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.currentState != GameManager.Instance.OverworldState)
        {
            anim.SetFloat("vertical", Input.GetAxis("Vertical"));

            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetFloat("speed", speed);
                transform.Translate(0f, 0f, Input.GetAxis("Vertical") * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0f, rotationForce * GameManager.Instance.sensitivity * Time.deltaTime, 0f);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0f, -rotationForce * GameManager.Instance.sensitivity * Time.deltaTime, 0f);
            }

            if (Input.GetKeyDown(KeyCode.Space) && !hasJumped && onGround)
            {
                Debug.Log("space pressed");
                anim.SetTrigger("jumped");
                GameManager.Instance.jump.Play();
                hasJumped = true;
                onGround = false;
            }

            if (Input.GetKeyDown(KeyCode.I) && ham)
            {
                if (ham.canPickUp)
                {
                    ham.pickUpHam = true;
                    ham.gameObject.layer = 7;
                }

            }

            if (Input.GetKeyDown(KeyCode.U) && hamIsPickedUp)
            {
                anim.SetTrigger("throw");
                throwHam = true;
            }

            if (transform.position.y < -40f)
            {
                GameManager.Instance.LoseLife();
                GameManager.Instance.SwitchState(GameManager.Instance.CatClimbState);
            }

            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            {
                sprintSpeed = speed + 4f;
                anim.SetFloat("speed", sprintSpeed);
                transform.Translate(0f, 0f, Input.GetAxis("Vertical") * sprintSpeed * Time.deltaTime);

            }

            if (Input.GetKeyDown(KeyCode.J) && holdingGun)
            {
                anim.SetTrigger("shoot");
                Instantiate(bullet, bulletSpawnPoint.transform.position, transform.rotation);
                GameManager.Instance.gunshot.Play();
            }
            if (Input.GetKeyDown(KeyCode.K) && !hamIsPickedUp && gun)
            {
                gun.SetActive(!gun.activeSelf);
                anim.SetBool("aiming", !anim.GetBool("aiming"));
                holdingGun = !holdingGun;
            }
        }
       

        currentState.UpdateState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("devilbulldog"))
        {
            Debug.Log("Collided with devildog");
            GameManager.Instance.LoseLife();
            GameManager.Instance.SwitchState(GameManager.Instance.World1state);
        }

        if (collision.gameObject.CompareTag("floor"))
        {
            onGround = true;
            Debug.Log("hasjumped = " + hasJumped);
        }
        currentState.OnCollisionEnter(this, collision);
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    public void Footstep()
    {
        if (!hasJumped)
            GameManager.Instance.footstep.Play();
    }
    
}
