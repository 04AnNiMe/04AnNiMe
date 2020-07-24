using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMcharacterMovement : MonoBehaviour
{
    public Animator animController;
    public float forwardVel = 12;
    public float rotateVel = 100;
    public float JumpVel = 25;
    public float distanceGround = 0.4f;
    private float mouseRot;
    private float mouseRotSmooth = 0.3f;

    public LayerMask ground;
    public bool isGrounded = false;

    public float downAccel = 1.5f;
    
    public float inputDelay = 0.1f;                     //für einen kleinen Delay beim Drücken einer Taste
        
    Vector3 velocity = Vector3.zero;                    //Bewegung
    public Quaternion targetRotation;                   //Rotation
    Rigidbody rBody;                                    //Rigidbody
    public float forwardInput = 0;
    public float turnInput = 0;
    public float jumpInput = 0;                         //normale werte sind dann 1 und 0

    // Start is called before the first frame update
    void Start()
    {
        animController = GetComponent<Animator>();
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
        {
            rBody = GetComponent<Rigidbody>();
        }
        else
        {
            Debug.LogError("The charactor needs a rigidbody!!");                //Falls kein Rigidbody vorhanden ist
        }

    }
    //Abstand vom GameObject bis zum Boden
    void Grounded()
    {
        if (!Physics.Raycast(transform.position, -Vector3.up, distanceGround + 0.1f))
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }
    }

    void GetInput()
    {
        //Input festlegen
        forwardInput = Input.GetAxis("Vertical");       //interpolated
        turnInput = Input.GetAxis("Horizontal");        //interpolated
        jumpInput = Input.GetAxisRaw("Jump");           //non-interpolated
    }

    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            //Bewegung des GameObjects
            velocity.z = forwardVel * forwardInput;
        } else
        {
            //Bewegung in Z-Achse = 0 wenn kein forwardInput
            velocity.z = 0;
        }
    }

    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputDelay)
        {
            //Drehung des GameObjects
            targetRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.DrawLine(ray.origin, hit.point);
                this.transform.LookAt(hit.point);
                mouseRot = Input.mousePosition.x - Screen.width / 2;
            }
            targetRotation *= Quaternion.AngleAxis(mouseRot * mouseRotSmooth * Time.deltaTime, Vector3.up);

        }

        transform.rotation = targetRotation;
    }

    void Jump()
    {
        if (jumpInput > 0 && isGrounded)
        {
            //Wenn Grounded true dann Jump möglich
            velocity.y = JumpVel;
        }
        else if (jumpInput == 0 && isGrounded)
        {
            //Bewegung in Y-Achse = 0 wenn kein jumpInput
            velocity.y = 0;
        }
        else
        {
            //Physic nach unten anwenden
            velocity.y -= downAccel;
        }

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Turn();

        if (forwardInput != 0)
        {
            animController.SetInteger("Walking", 1);
        } else
        {
            animController.SetInteger("Walking", 0);
        }

        if (jumpInput != 0)
        {
            animController.SetInteger("Walking", 2);
        }
        else if(forwardInput != 0)
        {
            animController.SetInteger("Walking", 1);
        } else
        {
            animController.SetInteger("Walking", 0);
        }
    }

    private void FixedUpdate()
    {
        Run();
        Jump();
        Grounded();

        rBody.velocity = transform.TransformDirection(velocity);
    }
}
