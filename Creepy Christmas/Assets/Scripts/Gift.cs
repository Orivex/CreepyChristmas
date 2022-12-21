using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gift : MonoBehaviour, IInteractable
{
    [field: SerializeField] public bool needItem { get; set; }
    [field: SerializeField] public string neededItemName { get; set; }
    [field: SerializeField] public string description { get; set; }
    [field: SerializeField] public bool interacted { get; set; }

    [SerializeField] GameObject cover;
    [SerializeField] float openForce;
    [SerializeField] ParticleSystem ps;

    public void Interact()
    {
        if(interacted == false)
            StartCoroutine(Open());
    }

    IEnumerator Open()
    {
        interacted = true;

        Rigidbody coverRb = cover.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(0.1f);
        coverRb.AddForce(transform.up * openForce/* + RandomDirection() * openForce / 2*/);
        ps.Play();


        Destroy(cover, 3f);
    }

    Vector3 RandomDirection()
    {
        int r = Random.Range(0, 3);

        switch(r)
        {
            case 0:
                return Vector3.forward;
            case 1:
                return Vector3.right;
            case 2:
                return Vector3.back;
            case 3:
                return Vector3.left;
        }

        return Vector3.zero;
    }
}
