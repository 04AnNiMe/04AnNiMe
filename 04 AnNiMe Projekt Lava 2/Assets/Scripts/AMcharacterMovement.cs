using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMcharacterMovement : MonoBehaviour
{
    public Animator animController;
    public float forwardVel = 7;                        // die Vorwärtsgeschwindigkeit vom Spieler
    public float standardVel = 7;
    public float speedVel = 12;
    public float sideVel = 4;
    public float rotateVel = 100;                       // die Rotationsgeschwindigkeit vom Spieler
    public float JumpVel = 30;                          // die Sprungkraft vom Spieler
    public float distanceGround = 0.2f;                 // die Entfernung zum Boden vom Spieler
    private float mouseRot;
    private float mouseRotSmooth = 0.3f;

    public LayerMask ground;
    public bool isGrounded = false;                     // Check ob der Spieler den Boden berührt

    public float downAccel = 2.5f;                      // die Geschwindigkeit mit der der Spieler Richtung Boden fällt
    
    public float inputDelay = 0.01f;                    //für einen kleinen Delay beim Drücken einer Taste

    public Vector3 velocity = Vector3.zero;             // Bewegung
    public Quaternion playerRotation;                   // für die aktuelle Rotation des Spielers
    Rigidbody rBody;                                    // Rigidbody
    public float forwardInput = 0;
    public float sideInput = 0;
    public float turnInput = 0;
    public float jumpInput = 0;                         // normale werte sind dann 1 und 0
    public float speedInput = 0;

    // Start is called before the first frame update
    void Start()
    {
        animController = GetComponent<Animator>();
        playerRotation = transform.rotation;            // der playerRotation die aktuelle Rotation übergeben

        //Check ob ein Rigidbody vorhanden ist
        if (GetComponent<Rigidbody>())
        {
            rBody = GetComponent<Rigidbody>();
        }
        else
        {
            Debug.LogError("The charactor needs a rigidbody!!");                // Falls kein Rigidbody vorhanden ist
        }

    }

    //Abstand vom GameObject bis zum Boden
    void Grounded()
    {
        // Es wird mit einem Raycast überprüft ob der Spieler vom Boden entfernt ist oder nicht
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
        sideInput = Input.GetAxis("SideWalk");
        turnInput = Input.GetAxis("Horizontal");        //interpolated
        jumpInput = Input.GetAxisRaw("Jump");           //non-interpolated
        speedInput = Input.GetAxisRaw("SpeedUp");
    }

    void Run()
    {
        // Wenn der forwardInput größer als der inputDelay dann wird der Spieler bewegt
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            /* 
             * Bewegung des GameObjects indem beim Vector3 velocity die z Achse verändert wird
             * In der höhe von der forwardVel mal dem forwardInput
             */
            velocity.z = forwardVel * forwardInput;
        } else
        {
            //Bewegung in Z-Achse = 0 wenn kein forwardInput
            velocity.z = 0;
        }

        if (speedInput > 0)
        {
            forwardVel = speedVel;
            animController.speed = 1.3f;
        } else
        {
            forwardVel = standardVel;
            animController.speed = 1;
        }

    }

    void Turn()
    {
        // Wenn der turnInput größer als der inputDelay dann wird Rotiert
        if (Mathf.Abs(turnInput) > inputDelay)
        {
            playerRotation *= Quaternion.AngleAxis(rotateVel * turnInput * Time.deltaTime, Vector3.up);
        }

        // Zusätzlich noch ein Seitwärtsgang mit Q und E
        if (Mathf.Abs(sideInput) < 0)
        {
            velocity.x = sideInput * sideVel;
        }
        else
        {
            velocity.x = 0;
        }

        if (Mathf.Abs(sideInput) > 0)
        {
            velocity.x = sideInput * sideVel;
        }
        else
        {
            velocity.x = 0;
        }

        transform.rotation = playerRotation;            // den neuen Wert von playerRotation an den Spieler übergeben
    }

    void Jump()
    {
        if (jumpInput > 0 && isGrounded)
        {
            //Wenn Grounded true dann Jump möglich in höhe von der JumpVel in Richtung Y-Achse
            velocity.y = JumpVel;
        }
        else if (jumpInput == 0 && isGrounded)
        {
            //Bewegung in Y-Achse = 0 wenn kein jumpInput
            velocity.y = 0;
        }
        else
        {
            // Den Spieler in der Y-Achse nach Unten bewegen wenn er in der Luft ist
            velocity.y -= downAccel;
        }

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name == "Lava")
    //    {
    //        Debug.Log(this.name + " 28.August " + other.gameObject.name);
    //        animController.SetInteger("Walking", 3);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        GetInput();

        // Bewegung ausführen
        if (forwardInput != 0 || sideInput != 0)
        {
            animController.SetInteger("Walking", 1);
        } else
        {
            animController.SetInteger("Walking", 0);
        }


        // Sprung ausführen
        if (jumpInput != 0)
        {
            animController.SetInteger("Walking", 2);
        }
        else if(forwardInput != 0 || sideInput != 0)
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
        Turn();
        Jump();
        Grounded();

        rBody.velocity = transform.TransformDirection(velocity);
    }
}
