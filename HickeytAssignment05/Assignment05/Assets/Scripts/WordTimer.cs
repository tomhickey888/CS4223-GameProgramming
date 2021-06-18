using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordTimer : MonoBehaviour
{
    public WordManager wordManger;
    public Text ScoreText;
    public int score = 0;
    public float wordDelay = 1.5f;
    private float nextWordTime = 0f;

    private void Start()
    {
        wordDelay = PlayerPrefs.GetFloat("wordSpeed");
    }

    private void Update()
    {
        if(Time.time >= nextWordTime)
        {
            wordManger.AddWord();
            nextWordTime = Time.time + wordDelay;
            wordDelay *= .99f;
            score += 10;
            ScoreText.text = score.ToString();
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.Save();
        }
    }
}
