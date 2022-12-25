using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flickerlight : MonoBehaviour
{
    [SerializeField] Light flickerlight;

    private void Start()
    {
        InvokeRepeating(nameof(ChangeLight), 0f, 0.1f);
    }

    void ChangeLight()
    {
        flickerlight.intensity = Random.Range(0f, 1f);
    }
}
