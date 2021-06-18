using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject wordPrefab;
    public Text score;

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

    private Save CreateSaveGameObject()
    {
        Save save = new Save();
        /*
        GameObject[] Words = GameObject.FindGameObjectsWithTag("Word");
        int numWords = 0;

        foreach (GameObject targetWord in Words)
        {
            SerializableVector3 WordPosition = targetWord.transform.position;
            save.wordPositions.Add(WordPosition);
            numWords++;
        }

        save.numWords = numWords;
        */
        save.name = PlayerPrefs.GetString("name");
        save.wordSpeed = PlayerPrefs.GetFloat("wordSpeed");
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
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            PlayerPrefs.SetString("name", save.name);
            PlayerPrefs.SetFloat("wordSpeed", save.wordSpeed);
            PlayerPrefs.SetInt("score", save.score);
            PlayerPrefs.Save();

            FindObjectOfType<WordManager>().GetComponent<WordTimer>().score = PlayerPrefs.GetInt("score");
            score.text = PlayerPrefs.GetInt("score").ToString();
            /*
            for (int i = 0; i < save.numWords; i++)
            {
                Vector3 position = save.wordPositions[i];
                Instantiate(wordPrefab, position, Quaternion.identity);
            }
            */
            Debug.Log("Game Loaded");

            FindObjectOfType<GameManager>().GetComponent<PauseMenu>().Unpause();
        }
        else
        {
            Debug.Log("No game saved!");
        }
    }
}