using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Toggle toggle;
    public AudioSource myAudio;
    public GameObject menu;

    public Text scoreText;
    public Text livesText;
    public Text nameText;

    private bool isPaused = false;

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

    private Save CreateSaveGameObject()
    {
        Save save = new Save();

        save.name = PlayerPrefs.GetString("name");
        save.score = PlayerPrefs.GetInt("score");
        save.lives = PlayerPrefs.GetInt("lives");
        save.timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().timeRemaining;

        return save;
    }

    public void SaveGame()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Game Saved");
        FindObjectOfType<GameManager>().restartGame();
    }

    public void SaveAsJSON()
    {
        Save save = CreateSaveGameObject();

        string json = JsonUtility.ToJson(save);

        Debug.Log("Saving as JSON: " + json);
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            PlayerPrefs.SetString("name", save.name);
            PlayerPrefs.SetInt("score", save.score);
            PlayerPrefs.SetInt("lives", save.lives);
            PlayerPrefs.SetFloat("timer", save.timer);
            PlayerPrefs.Save();

            GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().Restart();

            int score = PlayerPrefs.GetInt("score");
            int lives = PlayerPrefs.GetInt("lives");
            string name = PlayerPrefs.GetString("name");

            scoreText.text = score.ToString();
            livesText.text = lives.ToString();
            nameText.text = name;

            Debug.Log("Game Loaded");
            Unpause();
        }
        else
        {
            Debug.Log("No saved game to load");
        }
    }
}