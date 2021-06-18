using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    public float timeRemaining;
    private bool timerIsRunning = false;

    private void Awake()
    {
        timeRemaining = PlayerPrefs.GetFloat("timer");
        timerText.text = timeRemaining.ToString();
        timerIsRunning = true;
    }

    public void Restart()
    {
        timeRemaining = PlayerPrefs.GetFloat("timer");
        timerText.text = timeRemaining.ToString();
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
                FindObjectOfType<GameManager>().stopGame();
            }

            if (timeRemaining <= 5.0f) timerText.color = Color.red;
        }

        else
        {
            timeRemaining = 0f;
            DisplayTime(timeRemaining);
            timerIsRunning = false;
            PlayerPrefs.SetFloat("timer", timeRemaining);
            PlayerPrefs.Save();
            FindObjectOfType<GameManager>().stopGame();
        }

    }

    public void DisplayTime(float timeToDisplay)
    {
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliSeconds = (timeToDisplay % 1) * 1000;

        timerText.text = string.Format("{0:00}:{1:00}", seconds, milliSeconds);
    }
}
