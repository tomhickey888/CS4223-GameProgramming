using UnityEngine;
using UnityEngine.SceneManagement;

public class Frog : MonoBehaviour
{
    private int Lives;
    private int LivesUsed;

    public Rigidbody2D rb;

    private void Awake()
    {
        UpdateFrog();
    }

    public void UpdateFrog()
    {
        Lives = PlayerPrefs.GetInt("lives");
        LivesUsed = PlayerPrefs.GetInt("livesUsed");
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (transform.position.x < 5.0f) rb.MovePosition(rb.position + Vector2.right);
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.MovePosition(rb.position + Vector2.up);
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (transform.position.x > -5.0f) rb.MovePosition(rb.position + Vector2.left);
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (transform.position.y > -3.5f) rb.MovePosition(rb.position + Vector2.down);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6f, 6f), Mathf.Clamp(transform.position.y, -4.5f, 4.5f));

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Car")
        {
            Debug.Log("You Lost!");
            PlayerPrefs.SetInt("lives", Lives-1);
            PlayerPrefs.SetInt("livesUsed", LivesUsed + 1);
            PlayerPrefs.Save();
            if (Lives <= 1)
            {
                Debug.Log("Game Over!");
                int currentScene = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentScene + 1);
            }
            else SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
