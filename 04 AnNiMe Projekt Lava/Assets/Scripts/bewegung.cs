using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bewegung : MonoBehaviour
{
    public GameObject turtlee;
    public Collider cubeCollider ;

    // Start is called before the first frame update
    void Start()
    {
        turtlee = GameObject.CreatePrimitive(PrimitiveType.Cube);
        turtlee.transform.Translate(4.0f, 0.5f, 0);
        turtlee.AddComponent<BoxCollider>();
        cubeCollider = turtlee.GetComponent<BoxCollider>();
        cubeCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A)) {
            Debug.Log("A was pressed");
            turtlee.transform.rotation *= Quaternion.AngleAxis(-90, Vector3.up);
        }

        if(Input.GetKeyDown(KeyCode.W)) {
            Debug.Log("W was pressed");
            turtlee.transform.position += turtlee.transform.localRotation * new Vector3(1, 0, 0);
        }

        if(Input.GetKeyDown(KeyCode.D)) {
            Debug.Log("D was pressed");
            turtlee.transform.rotation *= Quaternion.AngleAxis(90, Vector3.up);
        }
    }
}
