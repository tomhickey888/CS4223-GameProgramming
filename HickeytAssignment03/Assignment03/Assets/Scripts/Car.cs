using UnityEngine;

public class Car : MonoBehaviour
{
    public Rigidbody2D rb;
    public float minSpeed = 8f;
    public float maxSpeed = 12f;
    private float carSpeed;


    float speed = 1f;

    private void Start()
    {
        carSpeed = PlayerPrefs.GetFloat("carSpeed");
        speed = Random.Range(minSpeed, maxSpeed) * carSpeed / 100f;
    }
    void FixedUpdate()
    {
        Vector2 forward = new Vector2(transform.right.x, transform.right.y);
        rb.MovePosition(rb.position + forward * Time.fixedDeltaTime * speed);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7f, 7f), Mathf.Clamp(transform.position.y, -4.5f, 4.5f));
    }
}
