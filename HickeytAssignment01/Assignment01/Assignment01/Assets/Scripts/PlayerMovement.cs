using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody Rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    // Update is called once per frame
    //FixedUpdate is for physics scripts
    void FixedUpdate()
    {
        Rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if(Input.GetKey("d"))
        {
            Rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            Rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if(Rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
