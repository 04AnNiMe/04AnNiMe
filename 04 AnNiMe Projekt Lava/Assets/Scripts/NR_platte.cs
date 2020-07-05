using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NR_platte : MonoBehaviour
{

    GameObject platte;
    private float time = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        //platte = GameObject.CreatePrimitive(PrimitiveType.Plane);
        platte = GameObject.CreatePrimitive(PrimitiveType.Cube);
        platte.transform.localScale = new Vector3(1,1,1);
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= time)
        {           
        time += 1.0f;
        platte.transform.position += platte.transform.localRotation * new Vector3(0f, 1.0f, 0);
        }    
    }
}
