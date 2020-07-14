using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMcharacterMovement : MonoBehaviour
{

    [System.Serializable]
    public class MoveSettings
    {
        public float forwardVel = 12;
        public float rotateVel = 100;
        public float JumpVel = 25;
        public float distToGrounded = 0.1f;         //vielleicht auf .5 .8 setzen  // bei dem Cube auf 1.2
        public LayerMask ground;
    }

    [System.Serializable]
    public class PhysSettings
    {
        public float downAccel = 0.75f;
    }

    [System.Serializable]
    public class InputSettings
    {
        public float inputDelay = 0.1f;             //für einen kleinen Delay beim Drücken einer Taste
        public string FORWARD_AXIS = "Vertical";
        public string TURN_AXIS = "Horizontal";
        public string JUMP_AXIS = "Jump";                       
    }

    //Settings erstellen um auf einzelne Elemente zugreifen zu können
    public MoveSettings moveSetting = new MoveSettings();
    public PhysSettings physSetting = new PhysSettings();
    public InputSettings inputSetting = new InputSettings();

    Vector3 velocity = Vector3.zero;                //Bewegung
    Quaternion targetRotation;                      //Rotation
    Rigidbody rBody;                                //Rigidbody
    float forwardInput, turnInput, jumpInput;       //normale werte sind dann 1 und 0

    //public Quaternion TargetRotation    
    //{
    //    get { return targetRotation; }
    //}

    //Abstand vom GameObject bis zum Boden
    bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, moveSetting.distToGrounded, moveSetting.ground);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        targetRotation = transform.rotation;
        if (GetComponent<Rigidbody>()) {
            rBody = GetComponent<Rigidbody>();
        } else {
            Debug.LogError("The charactor needs a rigidbody!!");                //Falls kein Rigidbody vorhanden ist
        }

        //erste initialisierung der Variablen
        forwardInput = turnInput = jumpInput = 0;                               

    }

    void GetInput()
    {
        //Input festlegen
        forwardInput = Input.GetAxis(inputSetting.FORWARD_AXIS);        //interpolated
        turnInput = Input.GetAxis(inputSetting.TURN_AXIS);              //interpolated
        jumpInput = Input.GetAxisRaw(inputSetting.JUMP_AXIS);           //non-interpolated
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Turn();

    }

    private void FixedUpdate()
    {
        Run();
        Jump();

        rBody.velocity = transform.TransformDirection(velocity);
        //rBody.velocity = velocity;
    }

    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputSetting.inputDelay)
        {
            //Bewegung des GameObjects
            velocity.z = moveSetting.forwardVel * forwardInput;
        } else
        {
            //Bewegung in Z-Achse = 0 wenn kein forwardInput
            velocity.z = 0;
        }
    }

    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputSetting.inputDelay)
        {
            //Drehung des GameObjects
            targetRotation *= Quaternion.AngleAxis(moveSetting.rotateVel * turnInput * Time.deltaTime, Vector3.up);
        }
        transform.rotation = targetRotation;
    }

    void Jump()
    {
        if (jumpInput > 0 && Grounded())
        {
            //Wenn Grounded true dann Jump möglich
            velocity.y = moveSetting.JumpVel;
        } else if (jumpInput == 0 && Grounded())
        {
            //Bewegung in Y-Achse = 0 wenn kein jumpInput
            velocity.y = 0;
        } else
        {
            //Physic nach unten anwenden
            velocity.y -= physSetting.downAccel;
        }
    }
}
