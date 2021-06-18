using UnityEngine;

public class Pin : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    private int Lives;
    public bool isPinned = false;

    private void FixedUpdate()
    {
        Lives = PlayerPrefs.GetInt("lives");

        float modifier = PlayerPrefs.GetFloat("pinSpeed");
        float PinSpeed = speed * modifier;
        PlayerPrefs.SetFloat("PinSpeed", PinSpeed);

        if (!isPinned)
        {
            rb.MovePosition(rb.position + Vector2.up * PinSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Rotator")
        {
            transform.SetParent(col.transform);
            isPinned = true;
            PinSpawner.PinCount++;
            PlayerPrefs.SetInt("score", PinSpawner.PinCount);
            PlayerPrefs.Save();
            FindObjectOfType<GameManager>().GetComponent<PlayerSettings>().DisplayScore();
        }

        else if (col.tag == "Pin")
        {
            Destroy(gameObject);
            Lives--;
            PlayerPrefs.SetInt("lives", Lives);
            PlayerPrefs.Save();
            FindObjectOfType<GameManager>().GetComponent<PlayerSettings>().DisplayLives();
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
