using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text score;
    public Text lives;
    public Text playerName;
    public GameObject car;
    public GameObject frog;
    public Canvas menu;

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void LastScene()
    {
        SceneManager.LoadScene(2);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        if (UnityEditor.EditorApplication.isPlaying == true) UnityEditor.EditorApplication.isPlaying = false;

        else Application.Quit();
    }

    public void ClearCars()
    {
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Car");

        foreach (GameObject car in cars)
        {
            Destroy(car);
        }
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();

        GameObject[] Cars = GameObject.FindGameObjectsWithTag("Car");
        int numCars = 0;

        foreach (GameObject targetCar in Cars)
        {
            SerializableVector3 CarPosition = targetCar.transform.position;
            SerializableQuaternion CarRotation = targetCar.transform.rotation;
            save.carPositions.Add(CarPosition);
            save.carRotations.Add(CarRotation);
            numCars++;
        }

        save.numCars = numCars;
        SerializableVector3 FrogPosition = GameObject.FindWithTag("Frog").transform.position;
        save.frogPosition = FrogPosition;

        save.name = PlayerPrefs.GetString("name");
        save.lives = PlayerPrefs.GetInt("lives");
        save.livesUsed = PlayerPrefs.GetInt("livesUsed");
        save.carSpeed = PlayerPrefs.GetFloat("carSpeed");
        save.score = PlayerPrefs.GetInt("score");

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
        Restart();
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
            ClearCars();
            
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            PlayerPrefs.SetString("name", save.name);
            PlayerPrefs.SetInt("lives", save.lives);
            PlayerPrefs.SetInt("livesUsed", save.livesUsed);
            PlayerPrefs.SetFloat("carSpeed", save.carSpeed);
            PlayerPrefs.SetInt("score", save.score);
            PlayerPrefs.Save();

            score.text = PlayerPrefs.GetInt("score").ToString();
            lives.text = "Lives: " + PlayerPrefs.GetInt("lives").ToString();
            playerName.text = PlayerPrefs.GetString("name");

            for (int i = 0; i < save.numCars; i++)
            {
                Vector3 position = save.carPositions[i];
                Quaternion rotation = save.carRotations[i];
                Instantiate(car, position, rotation);
            }

            if (!FindObjectOfType<Frog>()) Instantiate(frog, new Vector3(0f,-4.5f,0f), Quaternion.identity);

            else
            {
                Frog Frog = FindObjectOfType<Frog>();
                Frog.transform.position = save.frogPosition;
                Frog.UpdateFrog();
            }
            
            Debug.Log("Game Loaded");

            menu.GetComponent<PauseMenu>().Unpause();
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
}
