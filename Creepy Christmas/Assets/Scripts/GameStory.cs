using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStory : MonoBehaviour
{
    [Header("BedSpawn")]

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerInteract playerInteract;
    [SerializeField] CharacterController playerController;
    [SerializeField] MouseLook mouseLook;

    [Header("Days")]
     public static int days; //tries

    [Space]

    [Header("Pointcounter")]
    [SerializeField] PointCounter pointCounter;
    [SerializeField] GameObject secretroomWall;
    [SerializeField] bool secretroomopened;

    private void Start()
    {
        days++;
    }

    private void Update()
    {
        if (pointCounter.points >= 10 && secretroomopened == false)
        {
            secretroomopened = true;
            OpenSecretRoom();
        }
    }

    void OpenSecretRoom()
    {
        Destroy(secretroomWall);
        ScreenMessager.Instance.SendScreenMessage("A secret room has been opened!", Color.green);
    }

    public void BedSpawnTimelineStart()
    {
        ScreenMessager.Instance.SendScreenMessage("Day " + days, Color.red);
        playerMovement.enabled = false;
        playerInteract.enabled = false;
        playerController.enabled = false;
        mouseLook.enabled = false;
    }

    public void BedSpawnTimelineEnd()
    {
        playerMovement.enabled = true;
        playerInteract.enabled = true;
        playerController.enabled = true;
        mouseLook.enabled = true;
    }
}