using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wardrobe : MonoBehaviour, IInteractable
{
    [field: SerializeField] public bool needItem { get; set; }
    [field: SerializeField] public string neededItemName { get; set; }
    [field: SerializeField] public string description { get; set; }
    [field: SerializeField] public bool interacted { get; set; }

    [SerializeField] Animator animator;

    public void Interact()
    {
        Toggle();
    }

    void Toggle()
    {
        animator.SetBool("open", !animator.GetBool("open"));
    }
}
