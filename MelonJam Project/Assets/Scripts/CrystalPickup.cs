using UnityEngine;

public class CrystalPickup : MonoBehaviour
{
    public GameObject player;
    private PlayerMovement pm;
    SoundManager audio;
    

    private void Awake()
    {
        pm = player.GetComponent<PlayerMovement>();
        audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<SoundManager>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pm.CollectCrystal();
            audio.PlaySFX(audio.PickupCrystal);
            Destroy(gameObject);
        }
    }
}
