using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRigid : MonoBehaviour
{
    // für Springen Testspielfigur:
    public GameObject testspielfigur;

    // Start is called before the first frame update
    void Start()
    {
        // Testspielfigur:
        testspielfigur = GameObject.CreatePrimitive(PrimitiveType.Cube);
    }

    // Update is called once per frame
    void Update()
    {
       //Steuerung Testspielfigur:
        testspielfigur.transform.position += testspielfigur.transform.localRotation * new Vector3(0.01f, 0, 0);
        if(Input.GetKeyDown(KeyCode.A)) {
            testspielfigur.transform.position += testspielfigur.transform.localRotation * new Vector3(0.001f, 0, 0);
            testspielfigur.transform.rotation *= Quaternion.AngleAxis(-90, Vector3.up);
        }
        if(Input.GetKeyDown(KeyCode.D)) {
            testspielfigur.transform.rotation *= Quaternion.AngleAxis(90, Vector3.up);
        } 
    }
}
