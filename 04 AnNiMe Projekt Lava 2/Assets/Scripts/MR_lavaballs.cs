using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_lavaballs : MonoBehaviour
{
    GameObject lavakugel;
   // BoxCollider hc;
    SphereCollider lc;
    SphereCollider lcc;
    //Rigidbody rig;

    // Start is called before the first frame update
    void Start()
    {
        lavakugel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //rig = lavakugel.AddComponent<Rigidbody>();
        //rig.isKinematic = false;
        lc = lavakugel.AddComponent<SphereCollider>();
        lcc = lavakugel.AddComponent<SphereCollider>();
        lcc.isTrigger = true;

        lavakugel.tag = "lavaball";

        // //Himmel
        // GameObject himmel = GameObject.CreatePrimitive(PrimitiveType.Cube);
        // himmel.name = "himmmel";
        // himmel.transform.localScale = new Vector3(1000,0.1f,1000);
        // himmel.transform.Translate(217.0f,105.9f,157.0f);

        // hc = himmel.AddComponent<BoxCollider>();
        // hc.size = new Vector3(1000.0f,0.1f,1000.0f);

    }

    // Update is called once per frame
    void Update()
    {
       //float waittime = 20.0f;
       float speed = 0.3f;
       float time = Time.deltaTime;

        lavakugel.transform.position += Vector3.up * speed;
       // if(lavakugel.position)
        //Debug.Log(time);
        if(time == 6.0f)
        {
            //rig.isKinematic = true;
        }
 
    }
}
