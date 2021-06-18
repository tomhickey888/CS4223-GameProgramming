using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    private string PlayerName;
    private int LivesRemaining;
    private float TimeLimit;
    private float RotationSpeed;
    private float PinSpeed;

    public Text Name;
    public Text Score;
    public Text Lives;

    public Dropdown LivesDropdown;
    public Dropdown TimeLimitDropdown;
    public Slider RotationSlider;
    public Text Rotation;
    public Slider PinSlider;
    public Text Pin;


    public void SetName()
    {
        PlayerName = Name.text;
        PlayerPrefs.SetString("name", PlayerName);
        PlayerPrefs.Save();
    }

    public void SetLives()
    {
        switch (LivesDropdown.value)
        {
            case 0:
                LivesRemaining = 3;
                break;
            case 1:
                LivesRemaining = 3;
                break;
            case 2:
                LivesRemaining = 6;
                break;
            case 3:
                LivesRemaining = 9;
                break;
            default:
                LivesRemaining = 3;
                break;
        }

        PlayerPrefs.SetInt("lives", LivesRemaining);
        PlayerPrefs.Save();
    }

    public void SetTimeLimit()
    {
        switch (TimeLimitDropdown.value)
        {
            case 0:
                TimeLimit = 15f;
                break;
            case 1:
                TimeLimit = 15f;
                break;
            case 2:
                TimeLimit = 30f;
                break;
            case 3:
                TimeLimit = 60f;
                break;
            default:
                TimeLimit = 15f;
                break;
        }

        PlayerPrefs.SetFloat("timeLimit", TimeLimit);
        PlayerPrefs.SetFloat("timer", TimeLimit);
        PlayerPrefs.Save();
    }

    public void SetRotationSpeed()
    {
        float value = RotationSlider.value;
        Rotation.text = value.ToString() + "%";
        RotationSpeed = value / 100f;
        PlayerPrefs.SetFloat("rotationSpeed", RotationSpeed);
        PlayerPrefs.Save();
    }

    public void SetPinSpeed()
    {
        float value = PinSlider.value;
        Pin.text = value.ToString() + "%";
        PinSpeed = value / 100f;
        PlayerPrefs.SetFloat("pinSpeed", PinSpeed);
        PlayerPrefs.Save();
    }

    public void DisplayName()
    {
        Name.text = PlayerPrefs.GetString("name");
    }

    public void DisplayScore()
    {
        Score.text = PlayerPrefs.GetInt("score").ToString();
    }

    public void DisplayLives()
    {
        Lives.text = PlayerPrefs.GetInt("lives").ToString();
    }
}

