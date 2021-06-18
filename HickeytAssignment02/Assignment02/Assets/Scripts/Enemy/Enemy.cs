using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public int health;
    public int damage;
    public Transform targetTransform;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(targetTransform != null)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetTransform.transform.position, Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Attack(Player player)
    {
        player.health -= this.damage;
        Destroy(this.gameObject);
    }

    public void Initialize(Transform target, float moveSpeed, int health)
    {
        this.targetTransform = target;
        this.moveSpeed = moveSpeed;
        this.health = health;
    }
}
