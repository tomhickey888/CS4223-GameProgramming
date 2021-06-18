using UnityEngine;


public class Initializer : MonoBehaviour
{
    private string PlayerName = " ";
    private int Score = 0;
    private int Lives = 3;
    private float TimeLimit = 15f;
    private float Timer = 15f;
    private float RotationSpeed = 1f;
    private float PinSpeed = 1f;
    //private int HighScore = 0;
    //private string HighScoreName = "None";

    public void Awake()
    {
        PlayerPrefs.SetString("name", PlayerName);
        PlayerPrefs.SetInt("score", Score);
        PlayerPrefs.SetInt("lives", Lives);
        PlayerPrefs.SetFloat("timeLimit", TimeLimit);
        PlayerPrefs.SetFloat("timer", Timer);
        PlayerPrefs.SetFloat("rotationSpeed", RotationSpeed);
        PlayerPrefs.SetFloat("pinSpeed", PinSpeed);
        //PlayerPrefs.SetInt("highScore", HighScore);
        //PlayerPrefs.SetString("highScoreName", HighScoreName);
        PlayerPrefs.Save();
    }
}
