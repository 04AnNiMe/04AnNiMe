using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_CollisionScript : MonoBehaviour
{
    public GameObject sphere;
    //public GameObject empty; //Boot
    public MR_bootnew bootScript;
    public GameObject boot;
    public bool bootBewegung;
    private float distanceGround;
    public bool lavaKugel;
   // public bool isGround;

    // Start is called before the first frame update
    void Start()
    {
        bootBewegung = GameObject.Find("EmptyBoot").GetComponent<MR_bootnew>();
        distanceGround = GetComponent<Collider>().bounds.extents.y;
    }

    void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,-Vector3.up, out hit, distanceGround+0.1f)) {
            if (hit.collider.tag == "boot") {
                bootBewegung = true;
            }
            if (hit.collider.tag == "lavakugel") {
                lavaKugel = true;

            } 
            else 
            {
                bootBewegung = false;
                lavaKugel = false;
            }
        }
    }

    // void OnTriggerEnter(Collider collision)
    // {
    //     //Debug.Log(this.name + " collides with: " + collision.gameObject.name);
    //    // Debug.Log("HELLO");
    //     // if(collision.gameObject.name == "Sphere"){
    //     //   Destroy(collision.gameObject);
    //     // }

    //      if(collision.gameObject.name == "EmptyBoot"){
    //     // }
    //     //     //Destroy(collision.gameObject);
    //          bootBewegung = true;
    //      } else{
    //          bootBewegung = false;
    //      }
    // }

    // Update is called once per frame
    void Update()
    {
        while(bootBewegung == true)
        {
            Debug.Log("jetzt sollte sich das boot bewegen");
            //bootBewegung = false;
            bootScript.empty.transform.Translate(-0.2f,0,0);
            // if(bootScript.empty.position = new Vector3(8,0,0))
            // {
            bootBewegung = false;
            // }
        } 
    }
}
