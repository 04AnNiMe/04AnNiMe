using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_CollisionScript : MonoBehaviour
{
    public GameObject sphere;
    //public GameObject empty; //Boot
    public MR_bootnew bootScript;
    bool bootBewegung = false;

    // Start is called before the first frame update
    void Start()
    {
        bootBewegung = GameObject.Find("EmptyBoot").GetComponent<MR_bootnew>();
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(this.name + " collides with: " + collision.gameObject.name);
        
        // if(collision.gameObject.name == "Sphere"){
        //   Destroy(collision.gameObject);
        // }

        // if(collision.gameObject.name == "Boot"){
        // }
        //     //Destroy(collision.gameObject);
        //     bootBewegung = true;
        // } else{
        //     bootBewegung = false;
        // }
    }

    // Update is called once per frame
    void Update()
    {
        // if(bootBewegung == true)
        // {
        //     Debug.Log("hallo");
        //     //bootBewegung = false;
        //     //bootScript.empty.transform.Translate(1,0,0);
        //     // if(bootScript.empty.position = new Vector3(8,0,0))
        //     // {
        //     //     bootBewegung = false;
        //     // }
        // } 
    }
}
