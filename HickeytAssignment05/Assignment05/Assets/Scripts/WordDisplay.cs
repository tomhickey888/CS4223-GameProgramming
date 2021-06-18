using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{
    public Text text;
    private float fallSpeed = 1f;

    public void SetWord(string word)
    {
        text.text = word;
    }

    public void RemoveLetter()
    {
        text.text = text.text.Remove(0, 1);
        text.color = Color.red;
    }

    public void RemoveWord()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        fallSpeed = Random.Range(0.5f, 1.5f);
    }

    private void Update()
    {
        transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
    }
}
