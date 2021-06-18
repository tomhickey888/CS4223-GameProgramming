using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
    [SerializeField]
    public Toggle toggle;
    [SerializeField]
    private AudioSource myAudio;
    [SerializeField]
    private int Music;
    [SerializeField]
    private string PlayerName;
    [SerializeField]
    private int Lives;
    [SerializeField]
    private int LivesUsed;
    [SerializeField]
    private float CarSpeed;
    [SerializeField]
    private int Score;

    public GameObject menu;
    public Slider slider;
    public Text speedText;

    public void Awake()
    {
        if (!PlayerPrefs.HasKey("music"))
        {
            PlayerPrefs.SetInt("music", 0);
            toggle.isOn = false;
            myAudio.enabled = false;
            PlayerPrefs.Save();
        }

        else
        {
            if (PlayerPrefs.GetInt("music") == 0)
            {
                myAudio.enabled = false;
                toggle.isOn = false;
            }
            else
            {
                myAudio.enabled = true;
                toggle.isOn = true;
            }
        }

        if (PlayerPrefs.HasKey("music")) Music = PlayerPrefs.GetInt("music");
        if (PlayerPrefs.HasKey("name")) PlayerName = PlayerPrefs.GetString("name");
        if (PlayerPrefs.HasKey("lives")) Lives = PlayerPrefs.GetInt("lives");
        if (PlayerPrefs.HasKey("livesUsed")) LivesUsed = PlayerPrefs.GetInt("livesUsed");
        if (PlayerPrefs.HasKey("carSpeed")) CarSpeed = PlayerPrefs.GetFloat("carSpeed");
        if (PlayerPrefs.HasKey("score")) Score = PlayerPrefs.GetInt("score");
    }

    public void ToggleMusic()
    {
        if (toggle.isOn)
        {
            PlayerPrefs.SetInt("music", 1);
            myAudio.enabled = true;
        }
        else
        {
            PlayerPrefs.SetInt("music", 0);
            myAudio.enabled = false;
        }
        PlayerPrefs.Save();
    }

    public void SetSpeed(float value)
    {
        speedText.text = value.ToString() + "%";
        CarSpeed = value / 100f;
        PlayerPrefs.SetFloat("carSpeed", value);
        PlayerPrefs.Save();
    }

}