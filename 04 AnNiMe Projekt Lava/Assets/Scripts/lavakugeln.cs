using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lavakugeln : MonoBehaviour
{
    public GameObject lavakugel;
    Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        GameObject ground = GameObject.CreatePrimitive(PrimitiveType.Cube);
        ground.transform.localScale = new Vector3(-10.0f*2,0.1f,10.0f*2);
        ground.transform.Translate(-3,0,-3);

        lavakugel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    }

    // Update is called once per frame
    void Update()
    {
       float waittime = 2.0f;
       float speed = 0.1f;
       float time = Time.deltaTime;

        while(time < waittime)
        {
            lavakugel.transform.position += Vector3.up * speed;
        }



        
    }
}
