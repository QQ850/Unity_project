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

    /*---------------------- Score ----------------------*/
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;

    /*---------------------- Add timer ----------------------*/
    public float timeRemaining = 120; //60 seconds 
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;

    /*---------------------- Add armband ----------------------*/
    public ThalmicMyo rightHand;
    public Thalmic.Myo.Pose lastPose = Thalmic.Myo.Pose.Rest;
    public bool makeFist = false;


    /*  public GameObject tunnelObj;
        public GameManager manager;
    */

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        timerIsRunning = true;
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
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
            
            /*---------------------- Myo Setter ----------------------*/
            if (lastPose != rightHand.pose)
            {
                lastPose = rightHand.pose;
                makeFist = false;
            }
            if (rightHand.pose.ToString() == "Fist" && /*transform.position.y <= maxHeightThreshold &&*/ !makeFist)
            {
                playerRB.AddForce(Vector3.up * force, forceMode);
                makeFist = true;
            }
            playerRB.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = "Time left: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }


 /*   // Update is called once per frame
    void FixedUpdate()
    {
        if (!playerIsAlive || !timerIsRunning)
        {
            return;
        }
        if (rightHand.pose.ToString() == "Fist" && transform.position.y <= maxHeightThreshold)
        {
            playerRB.AddForce(Vector3.up * force, forceMode);
        }
        playerRB.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
        if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y <= maxHeightThreshold)
        {
            playerRB.AddForce(Vector3.up * force, forceMode);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y >= minHeightThreshold)
        {
            playerRB.AddForce(Vector3.down * gravity, forceMode);
            // playerRB.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
        }
    }*/


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Tunnel" || !timerIsRunning)
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
