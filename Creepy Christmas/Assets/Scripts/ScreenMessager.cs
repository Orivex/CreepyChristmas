using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenMessager : MonoBehaviour
{
    public static ScreenMessager Instance { get; private set; }

    [SerializeField] TMP_Text screenMessageText;
    [SerializeField] Animator animator;

    private void Awake()
    {
        Instance = this;
    }

    public void SendScreenMessage(string message, Color color)
    {
        screenMessageText.text = message;
        screenMessageText.color = color;
        animator.SetTrigger("play");
    }
}
