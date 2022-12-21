using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    public Transform selectedInteractable;
    private void Update()
    {
        //DROP
        if (Input.GetKeyDown(KeyCode.Q) && inventory.currentSlot.item != null)
        {
            inventory.RemoveItem(inventory.currentSlot.item);
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        //PICK UP
        if(Physics.Raycast(ray, out hit))
        {
            if (hit.transform.GetComponent<IInteractable>() != null)
                selectedInteractable = hit.transform;
            else
                selectedInteractable = null;

            if(Input.GetKeyDown(KeyCode.E) && hit.transform.GetComponent<IInteractable>() != null)
            {
                //Interact with objects
                if (hit.transform.GetComponent<IInteractable>().needItem == false)
                    hit.transform.GetComponent<IInteractable>().Interact();

                //Use Items for other objects/items
                if (inventory.currentSlot.item != null && hit.transform.GetComponent<IInteractable>().needItem == true)
                {
                    if(inventory.currentSlot.item.name == hit.transform.GetComponent<IInteractable>().neededItemName)
                    {
                        hit.transform.GetComponent<IInteractable>().Interact();
                        inventory.UseItem(inventory.currentSlot.item);
                    }
                }

                //Interact with items
                if (hit.transform.GetComponent<Item>() != null)
                    if(!inventory.items.Contains(hit.transform.GetComponent<Item>()))
                        inventory.AddItem(hit.transform.GetComponent<Item>());
            }
        }
    }
}
