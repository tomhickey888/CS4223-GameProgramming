using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> highscoreEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("HighscoreEntryContainer");
        entryTemplate = entryContainer.Find("HighscoreEntryTemplate");
        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null)
        {
            AddHighscoreEntry(0, "");
            AddHighscoreEntry(0, "");
            AddHighscoreEntry(0, "");
            AddHighscoreEntry(0, "");
            AddHighscoreEntry(0, "");
            AddHighscoreEntry(0, "");
            AddHighscoreEntry(0, "");
            AddHighscoreEntry(0, "");
            AddHighscoreEntry(0, "");
            AddHighscoreEntry(0, "");

            jsonString = PlayerPrefs.GetString("highscoreTable");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

            for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
            {
                for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
                {
                    if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                    {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                    }
                }
            }

        for (int i = 10; i < highscores.highscoreEntryList.Count; i++)
        {
            highscores.highscoreEntryList.RemoveAt(i);
        }

        int newScore = PlayerPrefs.GetInt("score");
        string newName = PlayerPrefs.GetString("name");
        if(newScore > highscores.highscoreEntryList[9].score)
        {
            AddHighscoreEntry(newScore, newName);
            for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
            {
                for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
                {
                    if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                    {
                        HighscoreEntry tmp = highscores.highscoreEntryList[i];
                        highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                        highscores.highscoreEntryList[j] = tmp;
                    }
                }
            }
            for (int i = 10; i < highscores.highscoreEntryList.Count; i++)
            {
                highscores.highscoreEntryList.RemoveAt(i);
            }
        }

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 16f;
        Transform EntryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = EntryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        EntryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;

        switch (rank)
        {
            default:
                rankString = rank + "TH";
                break;
            case 1:
                rankString = "1ST";
                break;
            case 2:
                rankString = "2ND";
                break;
            case 3:
                rankString = "3RD";
                break;
        }

        EntryTransform.Find("posText").GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;
        EntryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        EntryTransform.Find("nameText").GetComponent<Text>().text = name;

        EntryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);

        if(rank ==1)
        {
            EntryTransform.Find("posText").GetComponent<Text>().color = Color.green;
            EntryTransform.Find("scoreText").GetComponent<Text>().color = Color.green;
            EntryTransform.Find("nameText").GetComponent<Text>().color = Color.green;
        }

        switch(rank)
        {
            default:
                EntryTransform.Find("trophy").gameObject.SetActive(false);
                break;
            case 1:
                EntryTransform.Find("trophy").GetComponent<Image>().color = UtilsClass.GetColorFromString("FFD200");
                break;
            case 2:
                EntryTransform.Find("trophy").GetComponent<Image>().color = UtilsClass.GetColorFromString("C6C6C6");
                break;
            case 3:
                EntryTransform.Find("trophy").GetComponent<Image>().color = UtilsClass.GetColorFromString("B76F56");
                break;
        }

        transformList.Add(EntryTransform);
    }


    private void AddHighscoreEntry(int score, string name)
    {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        if(highscores == null)
        {
            highscores = new Highscores()
            {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }
        highscores.highscoreEntryList.Add(highscoreEntry);
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }

    public void DeleteHighscores()
    {
        PlayerPrefs.SetString("highscoreTable", null);
        SceneManager.LoadScene(2);
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;

    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}

