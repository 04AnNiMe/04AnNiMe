using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AM_charHolder : MonoBehaviour
{
    public GameObject Player;

    private void Start()
    {
        Player = GameObject.Find("RabbitWarrior01");
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject == Player)
        //{
        Player.transform.parent = transform;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject == Player)
        //{
        Player.transform.parent = null;
        //}
    }
}
