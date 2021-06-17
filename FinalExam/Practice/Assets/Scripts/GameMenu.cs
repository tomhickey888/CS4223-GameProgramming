using System;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public Text scoreText;
    public Text livesText;
    public Text nameText;

    // Start is called before the first frame update
    void Start()
    { 
        scoreText.text = PlayerPrefs.GetInt("score").ToString();
        livesText.text = PlayerPrefs.GetInt("lives").ToString();
        nameText.text = PlayerPrefs.GetString("name"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pointsUp()
    {
        int score = Convert.ToInt32(scoreText.text);
        score++;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
    }

    public void pointsDown()
    {
        int score = Convert.ToInt32(scoreText.text);
        score--;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
    }

    public void livesUp()
    {
        int lives = Convert.ToInt32(livesText.text);
        lives++;
        livesText.text = lives.ToString();
        PlayerPrefs.SetInt("lives", lives);
        PlayerPrefs.Save();
    }

    public void livesDown()
    {
        int lives = Convert.ToInt32(livesText.text);
        lives--;
        livesText.text = lives.ToString();
        PlayerPrefs.SetInt("lives", lives);
        PlayerPrefs.Save();
    }
}

