using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;

    Vector3 shootDirection;

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Translate(shootDirection * speed, Space.World);
    }

    public void FireBullet(Ray shootRay)
    {
        this.shootDirection = shootRay.direction;
        this.transform.position = shootRay.origin;
        RotateInShootDirection();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.collider.gameObject.GetComponent<Enemy>();

        if(enemy)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(this.gameObject);
    }

    void RotateInShootDirection()
    {
        Vector3 newRotation = Vector3.RotateTowards(transform.forward, shootDirection, 0.01f, 0.0f);
        transform.rotation = Quaternion.LookRotation(newRotation);
    }
}
