using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items;

    public InventorySlot[] slots;

    public InventorySlot currentSlot;
    public int currentSlotIndex;
    private void Update()
    {
        currentSlot = slots[currentSlotIndex];

        if (Input.GetKey(KeyCode.Alpha1)) SwitchSlot(0);
        if (Input.GetKey(KeyCode.Alpha2)) SwitchSlot(1);
        if (Input.GetKey(KeyCode.Alpha3)) SwitchSlot(2);
        if (Input.GetKey(KeyCode.Alpha4)) SwitchSlot(3);

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) SlotDown();
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) SlotUp();
    }

    void SwitchSlot(int index)
    {
        currentSlotIndex = index;

        foreach (var slot in slots)
        {
            slot.gameObject.SetActive(false);
            if(slot.item != null)
                slot.item.isEquiped = false;
        }

        slots[index].gameObject.SetActive(true);

        if (slots[index].item != null)
            slots[index].item.isEquiped = true;
    }

    public void AddItem(Item newItem)
    {
        bool slotFound = false;

        if(currentSlot.item == null)
        {
            currentSlot.item = newItem;
            newItem.transform.position = currentSlot.transform.position;
            newItem.transform.rotation = currentSlot.transform.rotation;
            newItem.transform.SetParent(currentSlot.transform);

            items.Add(newItem);

            if (newItem.GetComponent<Rigidbody>() != null)
                newItem.GetComponent<Rigidbody>().isKinematic = true;

            //PSIUUU
            newItem.isEquiped = true;

            return;
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slotFound == true)
                return;

            if (slots[i].item == null)
            {
                slotFound = true;

                slots[i].item = newItem;
                newItem.transform.position = slots[i].transform.position;
                newItem.transform.rotation = slots[i].transform.rotation;
                newItem.transform.SetParent(slots[i].transform);

                items.Add(newItem);

                if (newItem.GetComponent<Rigidbody>() != null)
                    newItem.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    public void RemoveItem(Item item)
    {
        currentSlot.item = null;

        items.Remove(item);

        item.transform.SetParent(null);

        if (item.GetComponent<Rigidbody>() != null)
        {
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.GetComponent<Rigidbody>().AddForce(transform.forward * 100f + transform.up * 75f);
        }

        item.isEquiped = false;
    }

    public void UseItem(Item item)
    {
        item.Use();
    }

    private void SlotUp()
    {
        if (currentSlotIndex >= 3)
            currentSlotIndex = 0;
        else
            currentSlotIndex++;

        SwitchSlot(currentSlotIndex);
    }
    
    private void SlotDown()
    {
        if (currentSlotIndex <= 0)
            currentSlotIndex = 3;
        else
            currentSlotIndex--;

        SwitchSlot(currentSlotIndex);
    }
}
