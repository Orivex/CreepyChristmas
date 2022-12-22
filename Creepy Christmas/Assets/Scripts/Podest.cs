using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Podest : MonoBehaviour, IInteractable
{
    [field: SerializeField] public bool needItem { get; set; }
    [field: SerializeField] public string neededItemName { get; set; }
    [field: SerializeField] public string description { get; set; }
    [field: SerializeField] public bool interacted { get; set; }

    [SerializeField] Animator animator;
    [SerializeField] UnityEvent onPodestUse;
    public void Interact()
    {
        if (interacted == true)
            return;

        interacted = true;
        animator.SetTrigger("play");
        onPodestUse?.Invoke();
    }

}
