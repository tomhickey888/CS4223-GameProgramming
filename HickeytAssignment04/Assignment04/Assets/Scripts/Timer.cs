using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public bool timerIsRunning = false;
    public Text timeText;
    public float timeRemaining;

    private void Start()
    {
        timeRemaining = PlayerPrefs.GetFloat("timeLimit");
        timerIsRunning = true;
    }

    public void Restart()
    {
        timeRemaining = PlayerPrefs.GetFloat("timer");
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0f)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0f;
                DisplayTime(timeRemaining);
                timerIsRunning = false;
                PlayerPrefs.SetFloat("timer", timeRemaining);
                PlayerPrefs.Save();
                FindObjectOfType<GameManager>().EndGame();
            }

            if (timeRemaining <= 5.0f) timeText.color = Color.red;
        }

        else
        {
            timeRemaining = 0f;
            DisplayTime(timeRemaining);
            timerIsRunning = false;
            PlayerPrefs.SetFloat("timer", timeRemaining);
            PlayerPrefs.Save();
            FindObjectOfType<GameManager>().EndGame();
        }

    }

    public void DisplayTime(float timeToDisplay)
    {
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 1000;

        timeText.text = string.Format("{0:00}:{1:00}", seconds, milliSeconds);
    }
}