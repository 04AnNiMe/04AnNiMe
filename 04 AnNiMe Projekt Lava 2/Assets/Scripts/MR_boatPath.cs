using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_boatPath : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 2f;
    private int waypointIndex = 0;
    
    private Transform[] element;
    private void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
    }


    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if(waypointIndex <= waypoints.Length -1)
        {
            transform.position = Vector2.MoveTowards(transform.position, 
            waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
        }

        if(transform.position == waypoints[waypointIndex].transform.position)
        {   
            waypointIndex += 1;
        }
    }
}

