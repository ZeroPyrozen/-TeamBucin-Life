using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAndChase : MonoBehaviour {
    //patrol randomly between waypoints

    public Transform[] moveSpots;
    private int randomSpot;

    NavMeshAgent nav;

    //when to chase
    public float chaseRadius = 20f;
    public float facePlayerFactor = 20f;

    //wait time at waypoint for patrolling
    private float waitTime;
    public float startWaitTime = 1f;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = true;
    }

    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    void Update()
    {
        float distance = Vector3.Distance(PlayerMotor.playerPos, transform.position);
        if (distance > chaseRadius)
        {
            Patrol();
        }

        else if (distance <= chaseRadius)
        {
            //chasePlayer();
            //facePlayer();

        }
       
    }

    void Patrol()
    {
        nav.SetDestination(moveSpots[randomSpot].position);

        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 2.0f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length); //choose next spot
                waitTime = startWaitTime; //reset

            }

            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }
         
}
