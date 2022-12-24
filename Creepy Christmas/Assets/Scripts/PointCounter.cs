using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointCounter : MonoBehaviour
{
    public float points;
    [SerializeField] TMP_Text pointsText;

    [SerializeField] GameObject secretroomwall;
    [SerializeField] bool secretroomopen;
    public void AddPoints(float points)
    {
        this.points += points;
    }
    private void Update()
    {
        pointsText.text = points.ToString();

        if(points > 10 && secretroomopen == false)
        {
            secretroomopen = true;
            Destroy(secretroomwall);
            ScreenMessager.Instance.SendScreenMessage("A secret room has been opened!", Color.green);
        }
    }
}
