using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AM_levitatingPlate : MonoBehaviour
{
    public GameObject player;
    public GameObject plattform1;

    public bool upTrigger = false;
    public bool downTrigger = false;
    public bool forwardTrigger = false;
    public bool backTrigger = false;

    public float speed;

    public Vector3 aktPos1;
    public Vector3 startPos1;
    public Vector3 endPos1;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("RabbitWarrior01");
        plattform1 = GameObject.Find("AM_Trampolin01");
        startPos1 = plattform1.transform.position;
        endPos1 = plattform1.transform.position + new Vector3(26.13f, 2, 16.266f);
    }

    public void OnTriggerEnter(Collider other)
    {
        upTrigger = true;
        
    }

    public void OnTriggerExit(Collider other)
    {
        upTrigger = false;
    }

    void floatingUp()
    {
        aktPos1 = plattform1.transform.position;
        plattform1.transform.position = Vector3.Lerp(aktPos1, aktPos1 + new Vector3(0, 2, 0), Time.deltaTime * speed);
    }

    void floatingForward()
    {
        if (backTrigger)
        {
            aktPos1 = plattform1.transform.position;
            plattform1.transform.position = Vector3.Lerp(aktPos1, aktPos1 - new Vector3(26.13f, 0, 16.266f), Time.deltaTime * speed);
        }
        else
        {
            aktPos1 = plattform1.transform.position;
            plattform1.transform.position = Vector3.Lerp(aktPos1, aktPos1 + new Vector3(26.13f, 0, 16.266f), Time.deltaTime * speed);
        }
    }

    void floatingDown()
    {
        if (backTrigger)
        {
            aktPos1 = plattform1.transform.position;
            plattform1.transform.position = Vector3.Lerp(aktPos1, aktPos1 + new Vector3(0, -2f, 0), Time.deltaTime * speed);
        }
        else
        {
            aktPos1 = plattform1.transform.position;
            plattform1.transform.position = Vector3.Lerp(aktPos1, aktPos1 + new Vector3(0, -1.8f, 0), Time.deltaTime * speed);
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if (upTrigger)
        {
            speed = 0.7f;
            floatingUp();
            if (aktPos1.y >= endPos1.y)
            {
                upTrigger = false;
                forwardTrigger = true;
            }
        }

        if (forwardTrigger)
        {
            speed = 0.2f;
            if (backTrigger)
            {
                floatingForward();
                if (aktPos1.x <= startPos1.x && aktPos1.z <= startPos1.z)
                {
                    forwardTrigger = false;
                    downTrigger = true;
                }
            }
            else
            {
                floatingForward();
                if (aktPos1.x >= endPos1.x && aktPos1.z >= endPos1.z)
                {
                    forwardTrigger = false;
                    downTrigger = true;
                }
            }
        }

        if (downTrigger)
        {
            speed = 0.7f;
            if (backTrigger)
            {
                floatingDown();
                if (aktPos1.y <= endPos1.y - 1.8f)
                {
                    downTrigger = false;
                    backTrigger = false;
                }
            }
            else
            {
                floatingDown();
                if (aktPos1.y <= endPos1.y - 1.8f)
                {
                    downTrigger = false;
                    backTrigger = true;
                }
            }
        }        
    }
}
