using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_BootCollision : MonoBehaviour
{
    GameObject empty; //Boot
    public MR_bootnew bootScript;
    public GameObject boot;

    enum CollisionType { On, Off};
    CollisionType collisionType;

    int richtung; //1: Boot rückwärts, 0: Boot vorwärts

    float speicher, speicher2;
    public GameObject knopf;

    bool yellow;    

    // Start is called before the first frame update
    void Start()
    {
        bootScript = boot.GetComponent<MR_bootnew>();
        collisionType = CollisionType.Off;
        richtung = 0;
        yellow = false;

    }

    void OnTriggerEnter(Collider other)
    {
         if(other.tag == "boot")
        {
            collisionType = CollisionType.On;
        }
         if(other.tag == "destinyBoot")
        {
            collisionType = CollisionType.Off;
            richtung = 1;
        }
        if(other.tag == "destinyBoot2")
        {
            collisionType = CollisionType.Off;
            richtung = 0;
        }

        if(other.tag == "knopf1")
        {
            collisionType = CollisionType.Off;
            knopf.GetComponent<Renderer>().material.color = Color.yellow;
            bootScript.empty.transform.position = new Vector3(251.0f, 2.17f, 25.0f);
            richtung = 0;
        }
    }

    void OnTriggerExit(Collider other)
    {
         if(other.tag == "knopf1")
        {
            knopf.GetComponent<Renderer>().material.color = Color.red;
        }
    }
          

    // Update is called once per frame
    void Update()
    {                

        if(collisionType == CollisionType.On && richtung == 0 )
        {
            bootScript.empty.transform.Translate(-0.5f,0,0);
        }

        if(collisionType == CollisionType.On && richtung == 1)
        {
            bootScript.empty.transform.Translate(0.5f,0,0);
        }
        
    }
}
