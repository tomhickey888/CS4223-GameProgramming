using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    public GameObject wordPrefab;
    public Transform wordCanvas;
    private GameObject wordObj;
    public WordDisplay SpawnWord()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-2.5f, 2.5f), 7f);
        wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, wordCanvas);
        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();

        return wordDisplay;
    }

    private void Update()
    {
        
    }


}
