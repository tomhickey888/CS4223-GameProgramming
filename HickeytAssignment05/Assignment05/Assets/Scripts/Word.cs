using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word
{
    public string word;
    private int typeIndex;
    private WordDisplay display;

    public Word(string word, WordDisplay display)
    {
        this.word = word;
        typeIndex = 0;

        this.display = display;
        display.SetWord(word);
    }

    public char GetNextLetter()
    {
        return word[typeIndex];
    }

    public void TypeLetter()
    {
        typeIndex++;
        display.RemoveLetter();
    }

    public bool WordFinished()
    {
        bool wordFinished = (typeIndex >= word.Length);

        if(wordFinished)
        {
            display.RemoveWord();
        }

        return wordFinished;
    }
}
