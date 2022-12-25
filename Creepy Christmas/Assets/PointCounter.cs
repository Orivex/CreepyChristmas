using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointCounter : MonoBehaviour
{
    public float points;
    [SerializeField] TMP_Text pointsText;

    [SerializeField] 
    public void AddPoints(float points)
    {
        this.points += points;
    }
    private void Update()
    {
        pointsText.text = points.ToString();

        if(points > 20)
        {

        }
    }
}
