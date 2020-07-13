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
        public float inputDelay = 0.1f;     //für einen kleinen Delay beim Drücken einer Taste
        public string FORWARD_AXIS = "Vertical";
        public string TURN_AXIS = "Horizontal";
        public string JUMP_AXIS = "Jump";                       
    }

    public MoveSettings moveSetting = new MoveSettings();
    public PhysSettings physSetting = new PhysSettings();
    public InputSettings inputSetting = new InputSettings();

    Vector3 velocity = Vector3.zero;
    Quaternion targetRotation;
    Rigidbody rBody;
    float forwardInput, turnInput, jumpInput;      //normale werte sind dann 1 und 0

    public Quaternion TargetRotation    
    {
        get { return targetRotation; }
    }

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
            Debug.LogError("The charactor needs a rigidbody!!");    //Falls kein Rigidbody vorhanden ist
        }

        forwardInput = turnInput = jumpInput = 0;                               //erste initialisierung der Variablen

    }

    void GetInput()
    {
        forwardInput = Input.GetAxis(inputSetting.FORWARD_AXIS);     //interpolated
        turnInput = Input.GetAxis(inputSetting.TURN_AXIS);          //interpolated
        jumpInput = Input.GetAxisRaw(inputSetting.JUMP_AXIS);       //non-interpolated
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
            //move
            //rBoddy.velocity = transform.forward * forwardInput * moveSetting.forwardVel;
            velocity.z = moveSetting.forwardVel * forwardInput;
        } else
        {
            //zero velocity
            //rBody.velocity = Vector3.zero;
            velocity.z = 0;
        }
    }

    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputSetting.inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(moveSetting.rotateVel * turnInput * Time.deltaTime, Vector3.up);
        }
        transform.rotation = targetRotation;
    }

    void Jump()
    {
        if (jumpInput > 0 && Grounded())
        {
            //Jump
            velocity.y = moveSetting.JumpVel;
        } else if (jumpInput == 0 && Grounded())
        {
            //zero out our velocity.y
            velocity.y = 0;
        } else
        {
            //decrease velocity.y
            velocity.y -= physSetting.downAccel;
        }
    }
}
