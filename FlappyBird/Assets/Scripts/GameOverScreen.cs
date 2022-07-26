using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = "Total Points: " + score.ToString();
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("flappybird");
    }
    public void ExitButton()
    {
        //Change later to main menu scence
        SceneManager.LoadScene("MainMenu");
    } 
}
