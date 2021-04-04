using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int score;
    public static GameManager inst;
    public static GameManager distanceInst;

    [SerializeField] Text scoreText;
    [SerializeField] Text distanceText;

    private static float distance = 0;
    private static float difficultyMultiplier = 1;
    private static float difficultyOffset = 100;

    public static float Distance { get => distance; set => distance = value; }



    //[SerializeField] PlayerMovement playerMovement;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE:" + score;
        //playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    public void IncrementDistance()
    {
        distanceText.text += "Distance: " + Time.fixedDeltaTime;
    }

    void Awake()
    {
        inst = this;
        distanceInst = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        difficultyMultiplier = 1 + (distance / difficultyOffset);
    }
}
