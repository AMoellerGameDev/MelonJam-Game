using UnityEngine;

public class IceWallLogic : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            RockLogic rb = collision.gameObject.GetComponent<RockLogic>();
            if (rb.followingMouse == false)
            {
                Destroy(gameObject);
            }
        }
    }
}
