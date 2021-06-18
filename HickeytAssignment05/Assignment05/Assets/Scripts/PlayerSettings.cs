using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    private string PlayerName;
    private float WordSpeed;

    public Text Name;
    public Slider SpeedSlider;
    public Text Speed;

    public void SetName()
    {
        PlayerName = Name.text;
        PlayerPrefs.SetString("name", PlayerName);
        PlayerPrefs.Save();
    }

    public void SetWordSpeed()
    {
        float value = SpeedSlider.value;
        Speed.text = value.ToString() + " Seconds";
        WordSpeed = value;
        PlayerPrefs.SetFloat("wordSpeed", WordSpeed);
        PlayerPrefs.Save();
    }

    public void DisplayName()
    {
        Name.text = PlayerPrefs.GetString("name");
    }
}
