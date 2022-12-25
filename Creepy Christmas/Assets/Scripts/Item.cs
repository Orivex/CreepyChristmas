using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [field: SerializeField] public bool needItem { get; set; }
    [field: SerializeField] public string neededItemName { get; set; }
    [field: SerializeField] public string description { get; set; }
    [field: SerializeField] public bool interacted { get; set; }

    public Sprite slotSprite;

    public bool isEquiped;

    [SerializeField] bool destroyWhenUsed; 

    public void Interact()
    {

    }

    public virtual void Use()
    {
        Debug.Log(name + " used");

        if (destroyWhenUsed == true)
            Destroy(gameObject);
    }
}
