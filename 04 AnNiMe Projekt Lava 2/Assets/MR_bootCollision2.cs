using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_bootCollision2 : MonoBehaviour
{
    GameObject empty; //Boot
    public MR_bootnew2 bootScript2;
    public GameObject boot;

    enum CollisionType { On, Off};
    private CollisionType collisionType;

    // Start is called before the first frame update
    void Start()
    {
        bootScript2 = boot.GetComponent<MR_bootnew2>();
        collisionType = CollisionType.Off;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boot2")
        {
            collisionType = CollisionType.On;
        }
         if (other.tag == "destinyBoot")
        {
            Debug.Log("stop");
            collisionType = CollisionType.Off;
        }

    }
          

    // Update is called once per frame
    void Update()
    {    
        if(collisionType == CollisionType.On)
        {
            // bootScript.empty.transform.Rotate(0,0,35);
            bootScript2.empty.transform.Translate(-0.5f,0,0);
        }
        
    }
}
