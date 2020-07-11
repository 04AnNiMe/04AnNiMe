using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavakugeln : MonoBehaviour
{
    public GameObject lavakugel;
    public Collider groundCollider;

    // Start is called before the first frame update
    void Start()
    {
        //Boden
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ground.name = "ground";
        ground.transform.localScale = new Vector3(-10.0f*2,0.1f,10.0f*2);
        ground.transform.Translate(-3,0,-3);
    }

    // Update is called once per frame
    void Update()
    {
       float waittime = 20.0f;
       float speed = 0.1f;
       float time = Time.deltaTime;

       lavakugel = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        while(waittime > 0.0f)
        {
            lavakugel.transform.position += Vector3.up * speed;
            waittime--;
        }



        
    }
}
