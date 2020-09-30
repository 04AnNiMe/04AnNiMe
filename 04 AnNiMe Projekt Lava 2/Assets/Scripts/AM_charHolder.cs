using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AM_charHolder : MonoBehaviour
{
    public GameObject Player;

    private void Start()
    {
        // Dem GameObject wird das gesuchte GameObject "RabbitWarrior01" übergeben
        Player = GameObject.Find("RabbitWarrior01");
    }

    private void OnTriggerEnter(Collider other)
    {
        // Bei Collision wird der Player das Child von diesem GameObject
        Player.transform.parent = transform;
        Debug.Log(this.name + " ist nun Parent von " + other.gameObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        // Bei ende der Collision ist das Parent/Child verhältnis aufgelöst
        Player.transform.parent = null;
    }
}
