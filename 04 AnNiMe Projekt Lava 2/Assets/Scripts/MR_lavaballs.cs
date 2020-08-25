using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_lavaballs : MonoBehaviour
{
    GameObject lavakugel;
    BoxCollider lc;
    float speed = 0.3f;
    Random ran;
    float time;

    // Start is called before the first frame update
    void Start()
    {
       for(int i = 0; i<100; i++)
       {
           int zufall = Random.Range(0,5);
           if(time == zufall) 
           {
                time = 0;
                int zufall1 = Random.Range(0,100);
                int zufall2 = Random.Range(0,100);
                lavakugel = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                lc = lavakugel.AddComponent<BoxCollider>();
                lc.isTrigger = true;
                lavakugel.transform.Translate(zufall1, 0, zufall2);
                lavakugel.GetComponent<Renderer>().material.color = Color.red;
           }
       }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Funktioniert");

        if (other.tag == "himmel")
        {
            Debug.Log("fällt runter");
            //speed = 0.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        time+= Time.deltaTime;
        this.lavakugel.transform.position += Vector3.up * speed;
    }

    
}
