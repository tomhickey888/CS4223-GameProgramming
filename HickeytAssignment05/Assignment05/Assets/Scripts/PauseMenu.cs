using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    public Toggle toggle;
    [SerializeField]
    private AudioSource myAudio;

    public bool isPaused = false;

    public GameObject menu;



    private void Start()
    {
        Unpause();
        GameObject GM = GameObject.FindGameObjectWithTag("GameManager");
        myAudio = GM.gameObject.GetComponent<AudioSource>();

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
