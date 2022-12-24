using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheDoor : MonoBehaviour, IInteractable
{
    [field: SerializeField] public bool needItem { get; set; }
    [field: SerializeField] public string neededItemName { get; set; }
    [field: SerializeField] public string description { get; set; }
    [field: SerializeField] public bool interacted { get; set; }

    [SerializeField] int keys;
    [SerializeField] GameObject[] keyObjects;
    [SerializeField] Animator animator;

    private void Update()
    {
        description = "I need " + (3 - keys).ToString() + " key" + "(s)";

        if(keys == 3)
            Destroy(gameObject);
    }

    public void Interact()
    {
        keys++;
        keyObjects[keys - 1].SetActive(true);
        animator.SetBool("key" + keys, true);
    }
}
