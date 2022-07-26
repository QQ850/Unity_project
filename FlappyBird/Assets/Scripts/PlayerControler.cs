using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]

public class PlayerControler : MonoBehaviour
{
    //unchanged variable 
    [SerializeField] private float force;
    [SerializeField] private float gravity;
    [SerializeField] private ForceMode forceMode;
    [SerializeField] private float maxHeightThreshold;

    public GameOverScreen GameOverScreen;
    public GameObject tunnelObj;

    private Rigidbody playerRB;
    public GameManager manager;
    private bool playerIsAlive = true;
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        //manager.OnPlayerDeath.AddListener(OnPlayerDeath);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!playerIsAlive)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y <= maxHeightThreshold)
        {
            playerRB.AddForce(Vector3.up * force, forceMode);
        }
        playerRB.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Tunnel")
        {
            playerIsAlive = false;
            GameOverScreen.Setup(score);
            //tunnelObj.isAlive();
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
        scoreText.text = score.ToString();
    }

}
