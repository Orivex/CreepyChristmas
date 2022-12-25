using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] PlayerInteract playerInteract;

    [SerializeField] Color umrandungColor;
    [SerializeField] Image[] slotUmrandungImages;

    [SerializeField] TMP_Text selectedInteractableText;
    [SerializeField] TMP_Text selectedGameObjectDescriptionText;

    private void Update()
    {
        for (int i = 0; i < slotUmrandungImages.Length; i++)
        {
            if(i == inventory.currentSlotIndex)
                slotUmrandungImages[i].color = umrandungColor;
            else
                slotUmrandungImages[i].color = Color.white;
        }

        if (playerInteract.selectedInteractable != null)
            ShowSelectedInteractableUI();
        else
            HideSelectedInteractableUI();
    }

    void ShowSelectedInteractableUI()
    {
        selectedInteractableText.text = playerInteract.selectedInteractable.name;
        selectedGameObjectDescriptionText.text = playerInteract.selectedInteractable.GetComponent<IInteractable>().description;
    }
    void HideSelectedInteractableUI()
    {
        selectedInteractableText.text = string.Empty;
        selectedGameObjectDescriptionText.text = string.Empty;
    }
}
