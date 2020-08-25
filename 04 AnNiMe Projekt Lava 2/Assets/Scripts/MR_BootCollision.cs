using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_BootCollision : MonoBehaviour
{
    GameObject empty; //Boot
    public MR_bootnew bootScript;
    public GameObject boot;

    enum CollisionType { On, Off};
    private CollisionType collisionType;

    // Start is called before the first frame update
    void Start()
    {
        bootScript = boot.GetComponent<MR_bootnew>();
        collisionType = CollisionType.Off;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "boot")
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
            bootScript.empty.transform.Translate(-0.5f,0,0);
        }
        
    }
}
