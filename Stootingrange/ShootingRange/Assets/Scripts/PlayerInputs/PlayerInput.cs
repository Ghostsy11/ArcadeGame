using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Transform camTrans;

    [Header("Movement")]
    private float moveSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float sprintSpeed;
    public Transform orientation;
    float horizontalinput;
    float verticalinput;
    Vector3 XYZ;
    Rigidbody m_Rb;

    [Header("Ground Check")]
    public float groundDrag;
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;
    public MovementState state;
    private PlayerCameraYZAxis newY;

    //damagingPlayer damagingPlayerr;
    public enum MovementState
    {
        waling,
        sprintring,
        air

    }

    [Header("Keybinds")]
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode walking = KeyCode.W;
    
    // Start is called before the first frame update
    void Start()
    {
        camTrans = Camera.main.transform;
        m_Rb= GetComponent<Rigidbody>();
        newY = GetComponent<PlayerCameraYZAxis>();
        //damagingPlayerr = GetComponent<damagingPlayer>();
    }
    private void FixedUpdate()
    {
        MoveThePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        InputFunction();
        speedControll();
        StateHandler();
        CheckTheGround();



    }
    private void InputFunction()
    {
         horizontalinput = Input.GetAxis("Horizontal");
        verticalinput = Input.GetAxis("Vertical");
    }

    private void MoveThePlayer()
    {
        XYZ = orientation.forward * verticalinput + orientation.right * horizontalinput;
        m_Rb.AddForce(XYZ.normalized * moveSpeed * 10f, ForceMode.Force);

        /*
        Vector3 newRotation = new Vector3(XYZ.x, newY.YRotation, XYZ.z);
        m_Rb.rotation = Quaternion.Euler(newRotation);
        */

        /*
       Vector3 justY = new Vector3(0, camTrans.transform.forward.y, 0);

       transform.forward = justY;
       */
    }
    private void speedControll()
    {
       Vector3 OverSpeed= new Vector3(m_Rb.velocity.x, 0f, m_Rb.velocity.z);
        if(OverSpeed.magnitude > moveSpeed)
        {
            Vector3 limitedSpeed = OverSpeed.normalized* moveSpeed;
            m_Rb.velocity = new Vector3(limitedSpeed.x,m_Rb.velocity.y, limitedSpeed.z);
          //Debug.Log(moveSpeed);
        }
    }

    private void StateHandler()
    {
        if (Input.GetKey(sprintKey))
        {
            state = MovementState.sprintring;
            moveSpeed = sprintSpeed;
        }
        
        else if (Input.GetKey(walking))
        {
            state = MovementState.waling;
            moveSpeed = walkSpeed;
        }
        else
        {
            state = MovementState.air;
        }
    }

    private void CheckTheGround()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        if (grounded)
        {
            m_Rb.drag = groundDrag;
        }
        else m_Rb.drag = 0f;

    }


    //void OnCollisionEnter(Collision other)
    //{
    //    Debug.Log(other.gameObject);
    //    if (other.gameObject.tag == "Player")
    //    {
    //        damagingPlayerr.TakeDamageOnPlayer(20);
    //        Destroy(gameObject);

    //    }
    //}
}




//if (Input.GetKey(KeyCode.W))
//{
//    m_Animator.SetBool(m_HashForwardSpeed, true);
//    transform.position += Vector3.forward.normalized * speed * Time.deltaTime;

//    //Debug.Log("w");
//    //Debug.Log(transform.position.magnitude);
//}
//else
//{
//    m_Animator.SetBool(m_HashForwardSpeed, false);
//}

//if (Input.GetKey(KeyCode.S))
//{

//    transform.position += Vector3.back.normalized * speed * Time.deltaTime;
//    //Debug.Log("S");


//}
//if (Input.GetKey(KeyCode.D))
//{

//    transform.position += Vector3.left.normalized * speed * Time.deltaTime;
//    // Debug.Log("D");

//}
//if (Input.GetKey(KeyCode.A))
//{

//    transform.position += Vector3.right.normalized * speed * Time.deltaTime;
//    // Debug.Log("A");

//}
//if (Input.GetKey(KeyCode.Space))
//{

//    transform.position += Vector3.up.normalized * speed * Time.deltaTime;
//    //Debug.Log("SPACE");

//}