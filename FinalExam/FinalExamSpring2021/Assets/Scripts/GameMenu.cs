using System;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;
    public Text nameText;

    int score;
    int lives;
    string name;

    void Awake()
    {
        score = PlayerPrefs.GetInt("score");
        lives = PlayerPrefs.GetInt("lives");
        name = PlayerPrefs.GetString("name");

        scoreText.text = score.ToString();
        livesText.text = lives.ToString();
        nameText.text = name; 
    }

    void Update()
    {
        
    }

    public void pointsUp()
    {
        score+=100;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
    }

    public void pointsDown()
    {
        score-=100;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
    }

    public void livesUp()
    {
        lives++;
        livesText.text = lives.ToString();
        PlayerPrefs.SetInt("lives", lives);
        PlayerPrefs.Save();
    }

    public void livesDown()
    {
        lives--;
        livesText.text = lives.ToString();
        PlayerPrefs.SetInt("lives", lives);
        PlayerPrefs.Save();
    }
}

