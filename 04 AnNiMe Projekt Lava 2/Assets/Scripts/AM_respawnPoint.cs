using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AM_respawnPoint : MonoBehaviour
{
    public bool check0 = false;
    public bool check1 = false;
    public bool check2 = false;
    public bool check3 = false;
    public bool check4 = false;
    public bool check5 = false;
    public bool check6 = false;
    public bool check7 = false;

    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        //Player = GameObject.Find("RabbitWarrior01");
        Player = gameObject;
    }

    //Diese Funktion teleportiert den Spieler an den letzten Checkpoint der mit den check bools gecheckt wird
    public void teleport()
    {
        if (check0)
        {
            Debug.Log("Teleport nach 0");

            Player.transform.position = GameObject.Find("Checkpoint_Knopf_0").transform.position + new Vector3(0, 0.1f, 0);
        }

        if (check1)
        {
            Debug.Log("Teleport nach 1");
            Player.transform.position = GameObject.Find("Checkpoint_Knopf_1").transform.position + new Vector3(0, 0.1f, 0);
        }

        if (check2)
        {
            Debug.Log("Teleport nach 2");

            Player.transform.position = GameObject.Find("Checkpoint_Knopf_2").transform.position + new Vector3(0, 0.1f, 0);
        }

        if (check3)
        {
            Debug.Log("Teleport nach 3");
            Player.transform.position = GameObject.Find("Checkpoint_Knopf_3").transform.position + new Vector3(0, 0.1f, 0);
        }

        if (check4)
        {
            Debug.Log("Teleport nach 4");

            Player.transform.position = GameObject.Find("Checkpoint_Knopf_4").transform.position + new Vector3(0, 0.1f, 0);
        }

        if (check5)
        {
            Debug.Log("Teleport nach 5");
            Player.transform.position = GameObject.Find("Checkpoint_Knopf_5").transform.position + new Vector3(0, 0.1f, 0);
        }

        if (check6)
        {
            Debug.Log("Teleport nach 6");
            Player.transform.position = GameObject.Find("Checkpoint_Knopf_6").transform.position + new Vector3(0, 0.1f, 0);
        }

        if (check7)
        {
            Debug.Log("Teleport nach 7");
            Player.transform.position = GameObject.Find("Checkpoint_Knopf_7").transform.position + new Vector3(0, 0.1f, 0);
        }
    }

}
