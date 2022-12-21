using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyInteractable : MonoBehaviour, IInteractable
{
    [field: SerializeField] public bool needItem { get; set; }
    [field: SerializeField] public string neededItemName { get; set; }
    [field: SerializeField] public string description { get; set; }
    [field: SerializeField] public bool interacted { get; set; }

    public void Interact()
    {

    }
}
