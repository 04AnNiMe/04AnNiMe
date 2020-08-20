using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AM_Checkpoint : MonoBehaviour
{
    public GameObject Player;
    public GameObject Knopf;

    public bool check = false;
    public bool check1 = false;
    public bool check2 = false;
    public bool check3 = false;
    public bool check4 = false;
    public bool check5 = false;
    public bool check6 = false;

    public Vector3 aktPos;

    public float timer = 0.0f;
    public float waitTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("RabbitWarrior01");

    }

    void floatingdown()
    {
        
        //this.transform.position = Vector3.Lerp(aktPos, aktPos - new Vector3(0f, 0.1f, 0), Time.deltaTime * 0.01f);
        this.transform.position = this.transform.position - new Vector3(0, 0.1f, 0);
    }

    void floatingup()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        aktPos = this.transform.position;
        Knopf = this.gameObject;

        if (!check)
        {
            floatingdown();
            check = true;
        }
        //this.transform.position = new Vector3(0, -0.1f, 0);
    }

    void Update()
    {
        

        if (check)
        {
            //timer += Time.deltaTime;
            //if (timer < waitTime)
            //{
            //    //aktPos = this.transform.position;
            //    floatingdown();
            //}
            //else
            //{

            //}
        }
    }
}
