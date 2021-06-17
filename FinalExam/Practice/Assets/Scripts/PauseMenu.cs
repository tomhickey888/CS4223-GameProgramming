using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Toggle toggle;
    public AudioSource myAudio;
    public GameObject menu;

    private bool isPaused = false;

    // Start is called before the first frame update
    private void Start()
    {
        Unpause();

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

    public void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
        if (isPaused) menu.SetActive(true);

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

    public void Unpause()
    {
        Time.timeScale = 1;
        isPaused = false;
        if (!isPaused) menu.SetActive(false);
    }

    public bool IsGamePaused()
    {
        return isPaused;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused)
            {
                Unpause();
            }
            else
            {
                Pause();
            }
        }
    }
}