using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStory : MonoBehaviour
{
    [Header("BedSpawn")]

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerInteract playerInteract;
    [SerializeField] CharacterController playerController;

    [Header("Procces 1")]
    [SerializeField] Podest podestHat;
    [SerializeField] bool hatplaced;

    [Space]

    [Header("Procces 2")]
    [SerializeField] PointCounter pointCounter;
    [SerializeField] GameObject secretroomWall;
    [SerializeField] bool secretroomopened;

    [Header("Procces 3")]
    [SerializeField] Podest podestPuppet;
    [SerializeField] bool puppetplaced;

    private void Start()
    {
        playerMovement.enabled = false;
        playerInteract.enabled = false;
        playerController.enabled = false;
    }

    private void Update()
    {
        if (podestHat.interacted == true && hatplaced == false)
            OpenWeaponBox();

        if (podestPuppet.interacted == true && puppetplaced == false)
            OpenKeyBox();

        if (pointCounter.points > 10 && secretroomopened == false)
        {
            secretroomopened = true;
            OpenSecretRoom();
        }
    }

    void OpenKeyBox()
    {
        puppetplaced = true;
    }

    void OpenWeaponBox()
    {
        hatplaced = true;
    }

    void OpenSecretRoom()
    {
        Destroy(secretroomWall);
        ScreenMessager.Instance.SendScreenMessage("A secret room has been opened!", Color.green);
    }

    public void BedSpawnTimelineEnd()
    {
        playerMovement.enabled = true;
        playerInteract.enabled = true;
        playerController.enabled = true;
    }
}
