using UnityEngine;
using UnityEngine.UI;

public class WordTrigger : MonoBehaviour
{
    public Text score;

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(col.gameObject);
        FindObjectOfType<GameManager>().LastScene();
    }
}