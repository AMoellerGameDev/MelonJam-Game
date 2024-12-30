using UnityEngine;

public class CrystalPickup : MonoBehaviour
{
    public GameObject player;
    private PlayerMovement pm;
    

    private void Awake()
    {
        pm = player.GetComponent<PlayerMovement>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pm.CollectCrystal();
           
            Destroy(gameObject);
        }
    }
}
