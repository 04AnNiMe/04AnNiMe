using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AM_Checkpoint : MonoBehaviour
{
    public GameObject Player;
    public GameObject Knopf;
    public GameObject mark0;
    public GameObject mark1;
    public GameObject mark2;
    public GameObject mark3;
    public GameObject mark4;
    public GameObject mark5;
    public GameObject mark6;
    public GameObject mark7;


    AM_respawnPoint checkpointList;

    public Vector3 aktPos;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("RabbitWarrior01");

        checkpointList = Player.GetComponent<AM_respawnPoint>();

        //GameObjecte Suchen und Zuweisen
        mark0 = GameObject.Find("AM_Checkpoint_0").transform.Find("Checkpoint_Mark_0").gameObject;
        mark1 = GameObject.Find("AM_Checkpoint_1").transform.Find("Checkpoint_Mark_1").gameObject;
        mark2 = GameObject.Find("AM_Checkpoint_2").transform.Find("Checkpoint_Mark_2").gameObject;
        mark3 = GameObject.Find("AM_Checkpoint_3").transform.Find("Checkpoint_Mark_3").gameObject;
        mark4 = GameObject.Find("AM_Checkpoint_4").transform.Find("Checkpoint_Mark_4").gameObject;
        mark5 = GameObject.Find("AM_Checkpoint_5").transform.Find("Checkpoint_Mark_5").gameObject;
        mark6 = GameObject.Find("AM_Checkpoint_6").transform.Find("Checkpoint_Mark_6").gameObject;
        mark7 = GameObject.Find("AM_Checkpoint_7").transform.Find("Checkpoint_Mark_7").gameObject;

    }

    // Diesen Button (this.) nach Unten bewegen
    void floatingdown()
    {
        this.transform.position = this.transform.position - new Vector3(0, 0.1f, 0);
    }

    /*
     * Alle Checkpoints werden gecheckt und alles was true ist wird auf false gestellt und der passende Button wird nach oben Transformiert
     * und die Markierung wird Uncheckt
     */
    void floatingUp()
    {
        //Check 0
        if (checkpointList.check0 == true)
        {
            checkpointList.check0 = false;
            mark0.SetActive(false);
            GameObject.Find("Checkpoint_Knopf_0").transform.position = GameObject.Find("Checkpoint_Knopf_0").transform.position + new Vector3(0, 0.1f, 0);

        }

        //Check 1
        if (checkpointList.check1 == true)
        {
            checkpointList.check1 = false;
            mark1.SetActive(false);
            GameObject.Find("Checkpoint_Knopf_1").transform.position = GameObject.Find("Checkpoint_Knopf_1").transform.position + new Vector3(0, 0.1f, 0);
        }

        //Check 2
        if (checkpointList.check2 == true)
        {
            checkpointList.check2 = false;
            mark2.SetActive(false);
            GameObject.Find("Checkpoint_Knopf_2").transform.position = GameObject.Find("Checkpoint_Knopf_2").transform.position + new Vector3(0, 0.1f, 0);
        }

        //Check 3
        if (checkpointList.check3 == true)
        {
            checkpointList.check3 = false;
            mark3.SetActive(false);
            GameObject.Find("Checkpoint_Knopf_3").transform.position = GameObject.Find("Checkpoint_Knopf_3").transform.position + new Vector3(0, 0.1f, 0);
        }

        //Check 4
        if (checkpointList.check4 == true)
        {
            checkpointList.check4 = false;
            mark4.SetActive(false);
            GameObject.Find("Checkpoint_Knopf_4").transform.position = GameObject.Find("Checkpoint_Knopf_4").transform.position + new Vector3(0, 0.1f, 0);
        }

        //Check 5
        if (checkpointList.check5 == true)
        {
            checkpointList.check5 = false;
            mark5.SetActive(false);
            GameObject.Find("Checkpoint_Knopf_5").transform.position = GameObject.Find("Checkpoint_Knopf_5").transform.position + new Vector3(0, 0.1f, 0);
        }

        //Check 6
        if (checkpointList.check6 == true)
        {
            checkpointList.check6 = false;
            mark6.SetActive(false);
            GameObject.Find("Checkpoint_Knopf_6").transform.position = GameObject.Find("Checkpoint_Knopf_6").transform.position + new Vector3(0, 0.1f, 0);
        }

        //Check 7
        if (checkpointList.check7 == true)
        {
            checkpointList.check7 = false;
            mark7.SetActive(false);
            GameObject.Find("Checkpoint_Knopf_7").transform.position = GameObject.Find("Checkpoint_Knopf_7").transform.position + new Vector3(0, 0.1f, 0);
        }

    }

    /* 
     * Es wird nach dem Checkpoint_Knopf Namen unterschieden.
     * Wenn dieser true ist dann wird bei Collision eine reihe von Funktionen ausgeführt.
     */
    void OnTriggerEnter(Collider other)
    {
        aktPos = this.transform.position;
        Knopf = this.gameObject;

        //Checkpoint 0
        if (Knopf == GameObject.Find("Checkpoint_Knopf_0") && checkpointList.check0 == false)
        {
            floatingUp();

            checkpointList.check0 = true;

            floatingdown();
            mark0.SetActive(true);
        }

        //Checkpoint 1
        if (Knopf == GameObject.Find("Checkpoint_Knopf_1") && checkpointList.check1 == false)
        {
            floatingUp();

            checkpointList.check1 = true;

            floatingdown();
            mark1.SetActive(true);
        }

        //Checkpoint 2
        if (Knopf == GameObject.Find("Checkpoint_Knopf_2") && checkpointList.check2 == false)
        {
            floatingUp();

            checkpointList.check2 = true;

            floatingdown();
            mark2.SetActive(true);
        }

        //Checkpoint 3
        if (Knopf == GameObject.Find("Checkpoint_Knopf_3") && checkpointList.check3 == false)
        {
            floatingUp();

            checkpointList.check3 = true;

            floatingdown();
            mark3.SetActive(true);
        }

        //Checkpoint 4
        if (Knopf == GameObject.Find("Checkpoint_Knopf_4") && checkpointList.check4 == false)
        {
            floatingUp();

            checkpointList.check4 = true;

            floatingdown();
            mark4.SetActive(true);
        }

        //Checkpoint 5
        if (Knopf == GameObject.Find("Checkpoint_Knopf_5") && checkpointList.check5 == false)
        {
            floatingUp();

            checkpointList.check5 = true;

            floatingdown();
            mark5.SetActive(true);
        }

        //Checkpoint 6
        if (Knopf == GameObject.Find("Checkpoint_Knopf_6") && checkpointList.check6 == false)
        {
            floatingUp();

            checkpointList.check6 = true;

            floatingdown();
            mark6.SetActive(true);
        }

        //Checkpoint 7
        if (Knopf == GameObject.Find("Checkpoint_Knopf_7") && checkpointList.check7 == false)
        {
            floatingUp();

            checkpointList.check7 = true;

            floatingdown();
            mark7.SetActive(true);
        }

    }

    private void Update()
    {
        /*
         * Wenn der bool true ist dann wird das Gameobject rotiert
         */
        if(checkpointList.check0)
        {
            mark0.transform.Rotate(0, 0, 0.1f);
        }

        if (checkpointList.check1)
        {
            mark1.transform.Rotate(0, 0, 0.1f);
        }

        if (checkpointList.check2)
        {
            mark2.transform.Rotate(0, 0, 0.1f);
        }

        if (checkpointList.check3)
        {
            mark3.transform.Rotate(0, 0, 0.1f);
        }

        if (checkpointList.check4)
        {
            mark4.transform.Rotate(0, 0, 0.1f);
        }

        if (checkpointList.check5)
        {
            mark5.transform.Rotate(0, 0, 0.1f);
        }

        if (checkpointList.check6)
        {
            mark6.transform.Rotate(0, 0, 0.1f);
        }

        if (checkpointList.check6)
        {
            mark7.transform.Rotate(0, 0, 0.1f);
        }

    }

}
