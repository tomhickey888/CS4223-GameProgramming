using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public int health = 3;
    public event Action<Player> OnPlayerDeath;

    void CollidedWithEnemy(Enemy enemy)
    {
        enemy.Attack(this);

        if(health <= 0)
        {
            if(OnPlayerDeath != null)
            {
                OnPlayerDeath(this);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.collider.gameObject.GetComponent<Enemy>();

        if (enemy)
        {
            CollidedWithEnemy(enemy);
        }
    }
}
