using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI scoreText;
    public int score;

    void Start()
    {
        //set initial score text
        scoreText.text = "Score: 0";
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: "+ score;
    }   
}
