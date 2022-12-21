using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    [SerializeField] GameObject particle;

    private void Start()
    {
        float r = Random.Range(0.1f, 0.3f);
        transform.localScale = new Vector3(r, r, r);
    }

    private void OnCollisionEnter(Collision other)
    {
        Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
