using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_bootCollision2 : MonoBehaviour
{
    GameObject empty; //Boot
    public MR_bootnew2 bootScript2;
    public GameObject boot;
    public GameObject knopf;

    //public GameObject Player;

    int richtung; //1: Boot rückwärts, 2: Boot vorwärts

    enum CollisionType { On, Off};
    CollisionType collisionType;
    bool yellow;

    // Start is called before the first frame update
    void Start()
    {
        bootScript2 = boot.GetComponent<MR_bootnew2>();
        collisionType = CollisionType.Off;
        richtung = 0;
        yellow = false;
    }

   void OnTriggerEnter(Collider other)
    {
         if(other.tag == "boot2")
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

        if(other.tag == "knopf2")
        {
            collisionType = CollisionType.Off;
            knopf.GetComponent<Renderer>().material.color = Color.yellow;
            bootScript2.empty.transform.position = new Vector3(320.7f, 2.17f, 179.6f);
        }
    }

    void OnTriggerExit(Collider other)
    {
         if(other.tag == "knopf2")
        {
            knopf.GetComponent<Renderer>().material.color = Color.red;
        }
    }
          
        
    // Update is called once per frame
    void Update()
    {   

        if(collisionType == CollisionType.On && richtung == 0 )
        {
            bootScript2.empty.transform.Translate(-0.5f,0,0);
        }

        if(collisionType == CollisionType.On && richtung == 1)
        {
            bootScript2.empty.transform.Translate(0.5f,0,0);
        }

        
    }
}
