using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICat : MonoBehaviour
{
    public Player player;
    public float wanderRadius;
    public float wanderTimer;
    public float regenTimer = 5.0f;
        
    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    public int healthAI = 100;
    void OnEnable () {
        agent = GetComponent<NavMeshAgent> ();
        timer = wanderTimer;
        
    }
    public void TakeDamage(int damage)
    {
        healthAI -= damage;
        if(healthAI<=0)
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) < 5.0f)
        {
            Debug.Log("Chase");
            ChasePlayer();
            regenTimer = 5.0f;
        }
        else
        {
            Debug.Log("Wander");
            Wander();
            Regeneration();
        }
        
    }
    private void Regeneration()
    {
        regenTimer -= Time.deltaTime;
        if(regenTimer < 0)
        {
            healthAI += 5;
            regenTimer = 5.0f;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player"){
            Debug.Log("Damage Player");
            player.TakeDamage(5);
        }   
    }

    void ChasePlayer()
    {
        Vector3 newPos = player.transform.position;
        agent.SetDestination(newPos);
    }
    void Wander()
    {
        timer += Time.deltaTime;
 
        if (timer >= wanderTimer) {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        NavMeshHit navHit;
 
        NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }
}
