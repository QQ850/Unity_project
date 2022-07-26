using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameManager : MonoBehaviour
{
    //GameManager only one reference 
    private int score = 0; 
    public static GameManager manager;
    public GameObject tunnelSpawner;
    public GameObject player;

    public IntEvent OnScoreChange;
    public UnityEvent OnPlayerDeath;

    void Start()
    {
        OnPlayerDeath = new UnityEvent();
        OnScoreChange = new IntEvent();
    }

    public void DestroyEverything()
    {
        //Destroy(tunnelSpawner);
        //Destroy(player);
        //SceneManager.LoadScene("Game Over");
    }

    public void adjustScore(int adjustment)
    {
        Debug.Log("adjust score");
        score += adjustment;
        OnScoreChange.Invoke(score);
    }
/*
    private void Awake()
    {
        *//*if (manager == null)
        {
            manager = this;
        }

        if (manager != this)
        {
            Destroy(this.gameObject);
        }*//*

        OnPlayerDeath = new UnityEvent();
        OnScoreChange = new intEvent();
    }*/

    [System.Serializable]

    public class IntEvent : UnityEvent<int> { }

    /*public static GameManager Instance
    {
        //getter
        get
        {
            if (manager == null)
            {
                manager = GameObject.FindObjectOfType<GameManager>();
                if (manager == null)
                {
                    var newObj = new GameObject();
                    manager = newObj.AddComponent<GameManager>();
                }
            }
            return manager;
        }
    }*/

}
