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
        Player.transform.parent = transform;
        Debug.Log(this.name + " ist nun Parent von " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        Player.transform.parent = null;
    }
}
