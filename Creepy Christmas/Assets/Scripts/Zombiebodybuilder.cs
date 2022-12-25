using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombiebodybuilder : MonoBehaviour, IInteractable
{
    [field: SerializeField] public bool needItem { get; set; }
    [field: SerializeField] public string neededItemName { get; set; }
    [field: SerializeField] public string description { get; set; }
    [field: SerializeField] public bool interacted { get; set; }

    [SerializeField] NavMeshAgent agent;

    [SerializeField] Transform[] walkPoints;

    [SerializeField] GameObject head;
    [SerializeField] ParticleSystem ps;
    [SerializeField] Animator animator;
    [SerializeField] GameObject keyPrefab;
    [SerializeField] Transform keySpawnPos;

    private void Start()
    {
        agent.SetDestination(walkPoints[0].position);
    }

    private void Update()
    {
        if (Vector3.Distance(new Vector3(transform.position.x, 0f, transform.position.z), new Vector3(agent.destination.x, 0f, agent.destination.z)) == 0f)
        {
            agent.SetDestination(walkPoints[Random.Range(0, walkPoints.Length)].position);
        }
    }

    public void Interact()
    {
        head.SetActive(true);
        ps.Stop();
        animator.SetTrigger("healed");
        agent.isStopped = true;
        description = "Thank you, here is a key I found";
        GameObject key = Instantiate(keyPrefab, keySpawnPos.position, Quaternion.identity);
        key.name = "Key Nr.2";
        Destroy(gameObject, 7f);
    }
}
