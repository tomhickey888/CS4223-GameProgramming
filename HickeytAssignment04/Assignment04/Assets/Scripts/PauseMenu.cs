using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PinPrefab;
    public GameObject menuScreen;
    public Slider pinSpeed;
    public Text pinSpeedText;
    public Slider rotationSpeed;
    public Text rotationSpeedText;

    public bool isPaused = false;

    private void Start()
    {
        Unpause();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
        if (isPaused) menuScreen.SetActive(true);

        float rValue = PlayerPrefs.GetFloat("rotationSpeed") * 100;
        rotationSpeed.value = rValue;
        rotationSpeedText.text = rValue.ToString() + "%";

        float pValue = PlayerPrefs.GetFloat("pinSpeed") * 100;
        pinSpeed.value = pValue;
        pinSpeedText.text = pValue.ToString() + "%";
    }

    public void End()
    {
        GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().timeRemaining = 0f;
        GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().DisplayTime(GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().timeRemaining);
        GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().timerIsRunning = false;
        PlayerPrefs.SetFloat("timer", GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().timeRemaining);
        PlayerPrefs.Save();
        Unpause();
        FindObjectOfType<GameManager>().EndActions();
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        isPaused = false;
        if (!isPaused) menuScreen.SetActive(false);
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

        GameObject[] Pins = GameObject.FindGameObjectsWithTag("Pin");
        int numPins = 0;

        foreach (GameObject targetPin in Pins)
        {
            SerializableVector3 PinPosition = targetPin.transform.position;
            SerializableQuaternion PinRotation = targetPin.transform.rotation;
            save.pinPositions.Add(PinPosition);
            save.pinRotations.Add(PinRotation);
            numPins++;
        }

        save.numPins = numPins;

        save.name = PlayerPrefs.GetString("name");
        save.score = PlayerPrefs.GetInt("score");
        save.lives = PlayerPrefs.GetInt("lives");
        save.timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().timeRemaining;
        save.rotationSpeed = PlayerPrefs.GetFloat("rotationSpeed");
        save.pinSpeed = PlayerPrefs.GetFloat("pinSpeed");
        

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
        FindObjectOfType<GameManager>().Restart();
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
            PinPrefab.SetActive(false);

            GameObject[] Pins = GameObject.FindGameObjectsWithTag("Pin");
            foreach(GameObject pin in Pins)
            {
                Destroy(pin);
            }

            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            PlayerPrefs.SetString("name", save.name);
            PlayerPrefs.SetInt("score", save.score);
            PlayerPrefs.SetInt("lives", save.lives);
            PlayerPrefs.SetFloat("timer", save.timer);
            PlayerPrefs.SetFloat("rotationSpeed", save.rotationSpeed);
            PlayerPrefs.SetFloat("pinSpeed", save.pinSpeed);
            PlayerPrefs.Save();

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<UIStart>().Restart();
            GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().Restart();

            for (int i = 0; i < save.numPins; i++)
            {
                Vector3 position = save.pinPositions[i];
                Quaternion rotation = save.pinRotations[i];
                Instantiate(PinPrefab, position, rotation);
            }

            Pin[] NewPins = FindObjectsOfType<Pin>();
            foreach (Pin pin in NewPins)
            {
                pin.isPinned = true;
            }

            PinPrefab.SetActive(true);

            Debug.Log("Game Loaded");
            Unpause();
        }
        else
        {
            Debug.Log("No saved game to load");
        }
    }
}
