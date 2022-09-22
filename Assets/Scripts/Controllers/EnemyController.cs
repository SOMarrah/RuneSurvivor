using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    //change look radius to change the distance an enemy will look for the player.
    public float lookRadius = 20f;
    Transform target;
    NavMeshAgent agent;
    CharacterCombat combat;


    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
    }

    // Update is called once per frame
    //this makes the enemy always follow and face the player
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
        
    }
    //the collider will set the attack range of the enemy
    void OnTriggerEnter(Collider other){
        CharStats targetStats = target.GetComponent<CharStats>();
             if(targetStats != null)
                {
                    combat.Attack(targetStats);
                }
        }
    void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime *5f);
    }
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
