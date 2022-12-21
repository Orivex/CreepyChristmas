using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class SantaClaus : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;

    [SerializeField] Transform[] walkPoints;

    [SerializeField] Transform player;
    [SerializeField] float detectDistance;
    [SerializeField] float catchDistance;
    [SerializeField] LayerMask ignoreLayer;

    [SerializeField] Animator animator;
    [SerializeField] bool catched;

    private void Start()
    {
        agent.SetDestination(walkPoints[0].position);
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, player.position) < detectDistance && Physics.Linecast(transform.position, player.position, ignoreLayer) == false)
        {
            ScreenMessager.Instance.SendScreenMessage("YOU WILL DIE", Color.red);
            RunToPlayer();
            if(Vector3.Distance(transform.position, player.position) < catchDistance)
            {
                CatchPlayer();
            }
        }
        else if(Vector3.Distance(new Vector3(transform.position.x, 0f, transform.position.z), new Vector3(agent.destination.x, 0f, agent.destination.z)) == 0f)
        {
            RunToWalkpoint();
        }
    }

    void CatchPlayer()
    {
        ScreenMessager.Instance.SendScreenMessage("YOU DIED!", Color.red);
        player.GetComponentInParent<PlayerMovement>().speed = 0f;
        if (Vector3.Distance(transform.position, player.position) > 6f)
            RunToPlayer();
        else if (catched == false)
        {
            catched = true;
            agent.isStopped = true;
            animator.SetTrigger("catched");
            SceneLoader.Instance.ReloadScene();
        }
    }

    void RunToWalkpoint()
    {
        agent.SetDestination(walkPoints[Random.Range(0, walkPoints.Length)].position);
        agent.speed = 3f;
        animator.SetBool("chasing", false);
    }

    void RunToPlayer()
    {
        agent.SetDestination(player.position);
        agent.speed = 6f;
        animator.SetBool("chasing", true);
    }
}
