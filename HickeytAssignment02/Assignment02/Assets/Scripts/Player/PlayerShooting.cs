using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Bullet bulletPrefab;
    public LayerMask mask;

    void shoot(RaycastHit hit)
    {
        var projectile = Instantiate(bulletPrefab).GetComponent<Bullet>();

        var pointAboveFloor = hit.point + new Vector3(0, this.transform.position.y, 0);


        var direction = pointAboveFloor - transform.position;

        var shootRay = new Ray(this.transform.position, direction);
        Debug.DrawRay(shootRay.origin, shootRay.direction * 100.1f, Color.green, 2);

        Physics.IgnoreCollision(GetComponent<Collider>(), projectile.GetComponent<Collider>());

        projectile.FireBullet(shootRay);
    }
    void raycastOnMouseClick()
    {
        RaycastHit hit;
        Ray rayToFloor = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(rayToFloor.origin, rayToFloor.direction * 100.1f, Color.red, 2);

        if (Physics.Raycast(rayToFloor, out hit, 100.0f, mask, QueryTriggerInteraction.Collide))
        {
            shoot(hit);
        }
    }

    void Update()
    {
        if (!PauseScreen.GameIsPaused)
        {
            bool mouseButtonDown = Input.GetMouseButtonDown(0);
            if (mouseButtonDown)
            {
                raycastOnMouseClick();
            }
        }
    }
}

