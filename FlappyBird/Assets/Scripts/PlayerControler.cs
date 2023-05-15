using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]

public class PlayerControler : MonoBehaviour
{
    /*-----------unchanged variable - control bird up and down-----------*/
    [SerializeField] private float force;
    [SerializeField] private float gravity;
    [SerializeField] private ForceMode forceMode;
    [SerializeField] private float maxHeightThreshold;
    [SerializeField] private float minHeightThreshold;
    private Rigidbody playerRB;

    /*---------------------- Game over ----------------------*/
    public GameOverScreen GameOverScreen;
    private bool playerIsAlive = true;
   
    /*---------------------- Time over ----------------------*/
    public TimeUpScreen TimeUprScreen;

    /*---------------------- Score ----------------------*/
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;

    /*---------------------- Add timer ----------------------*/
    public float timeRemaining = 240; //120 seconds, 2 mins 
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;

    /*---------------------- Add armband ----------------------*/
    public ThalmicMyo rightHand;
    public Thalmic.Myo.Pose lastPose = Thalmic.Myo.Pose.Rest;
    public bool makeWaveIn = false;
    public bool makeWaveOut = false;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        timerIsRunning = true;
        //X = weapon.transform.position.x;
    }


    void Update()
    {
        if (playerIsAlive && timerIsRunning)
        {
            /*---------------------- Timer Setter ----------------------*/
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                //TimeUprScreen.Setup(score);
            }
            
            /*---------------------- Myo Setter ----------------------*/
            if (lastPose != rightHand.pose)
            {
                lastPose = rightHand.pose;
                makeWaveIn = false;
                makeWaveOut = false;
            }

            if (rightHand.pose.ToString() == "WaveIn" && !makeWaveIn)
            {
                playerRB.AddForce(Vector3.up * force, forceMode);
                makeWaveIn = true;
            }
           /*if (rightHand.pose.ToString() == "WaveOut" && !makeWaveOut)
            {
                playerRB.AddForce(Vector3.down * force, forceMode);
                makeWaveOut = true;
            }*/

           
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = "Time Remaining: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Tunnel" || other.gameObject.tag == "Block" || !timerIsRunning)
        {
            playerIsAlive = false;
            GameOverScreen.Setup(score);
        }
        if (other.gameObject.tag == "ScoreTrigger" && playerIsAlive)
        {
            score += 1;
            SetScore();

        }
    }

    void SetScore()
    {
        //NullReferenceException: Object reference not set to an instance of an object Solution
        scoreText.text = "Score: " + score.ToString();
    }

}
