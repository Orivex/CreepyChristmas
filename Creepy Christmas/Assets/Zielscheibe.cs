using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zielscheibe : MonoBehaviour
{
    [SerializeField] string arrowTag;

    [SerializeField] PointCounter counter;

    [SerializeField] Vector3 sineRange;
    [SerializeField] Vector3 sineSpeed;
    [SerializeField] Vector3 sineOffset;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag(arrowTag))
        {
            counter.AddPoints(1);
        }
    }

    private void Update()
    {
        transform.position = new Vector3(sineRange.x * Mathf.Sin(Time.time * sineSpeed.x) + sineOffset.x, sineRange.y * Mathf.Sin(Time.time * sineSpeed.y) + sineOffset.y, sineRange.z * Mathf.Sin(Time.time * sineSpeed.z) + sineOffset.z);
    }
}
