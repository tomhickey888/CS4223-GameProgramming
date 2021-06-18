using UnityEngine;

public class CarArea : MonoBehaviour
{
    public Collider car;
    private void OnTriggerExit2D(Collider2D collision)
    {
         Destroy(collision.gameObject);
        
    }
    
}
