using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AM_charControllerBesser : MonoBehaviour
{
    Quaternion aktRot;
    Quaternion gesRot;

    public float speed = 0.3f;
    public float rotSp = 1.0f;

    //Jump
    public Rigidbody bodyRig;
    public float jumpVel = 5.0f;
    public float fallMulti = 2.5f;
    public float lowJumpMulti = 2.0f;
    public float groundDist;
    bool isgrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        bodyRig = gameObject.AddComponent<Rigidbody>();
        bodyRig.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;

        groundDist = GetComponent<Collider>().bounds.extents.y;
    }

    void Grounded()
    {
        if (!Physics.Raycast(this.transform.position, Vector3.down, groundDist + 0.1f))
        {
            isgrounded = false;
            Debug.Log("false");
        }
        else
        {
            isgrounded = true;
            Debug.Log("true");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            aktRot = this.transform.rotation;
            gesRot = Quaternion.AngleAxis(0.6f, Vector3.down);

            this.transform.rotation *= Quaternion.Lerp(aktRot, gesRot, Time.deltaTime * rotSp * 100);
        } else if (Input.GetKey(KeyCode.D))
        {
            aktRot = this.transform.rotation;
            gesRot = Quaternion.AngleAxis(0.6f, Vector3.up);

            this.transform.rotation *= Quaternion.Lerp(aktRot, gesRot, Time.deltaTime * rotSp * 100);
        }

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += this.transform.localRotation * new Vector3(0, 0, speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position -= this.transform.localRotation * new Vector3(0, 0, speed);
        }

        //Checken ob Char am Boden
        Grounded();

        //Sprung
        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.up * jumpVel;
        }
        
        if (bodyRig.velocity.y < 0)
        {
            bodyRig.velocity += Vector3.up * Physics.gravity.y * (fallMulti - 1) * Time.deltaTime;
        }
        else if (bodyRig.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            bodyRig.velocity += Vector3.up * Physics.gravity.y * (lowJumpMulti - 1) * Time.deltaTime;
        }
    }
}
