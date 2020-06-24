using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spielerMovement : MonoBehaviour
{
    Quaternion aktRotation;
    Quaternion gesRotation;
    public float rotSpeed;
    public float frequenz;
    public float runSpeed;

    //Jump
    private float jumpVelocity = 5.0f;
    private float fallMultiplier = 2.5f;
    private float lowJumpMultiplier = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKey(KeyCode.A))
        {
            aktRotation = transform.rotation;
            gesRotation = Quaternion.AngleAxis(0.6f, Vector3.down);

            transform.rotation *= Quaternion.Lerp(aktRotation, gesRotation, (Time.time - frequenz) / rotSpeed * 2);
        }
        if (Input.GetKey(KeyCode.D))
        {
            aktRotation = transform.rotation;
            gesRotation = Quaternion.AngleAxis(0.6f, Vector3.up);

            transform.rotation *= Quaternion.Lerp(aktRotation, gesRotation, (Time.time - frequenz) / rotSpeed * 2);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.localRotation * new Vector3(0, 0, runSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.up * jumpVelocity;
        }

    }
}
