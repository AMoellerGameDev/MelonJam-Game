using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private RespawnScript respawn;
    private GameObject previousCheckpoint;
    private BoxCollider2D bc;

    private void Awake()
    {
        respawn = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnScript>();
        bc = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        previousCheckpoint = GameObject.FindGameObjectWithTag("Checkpoint");
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(bc);
            Destroy(previousCheckpoint);
            gameObject.tag = "Checkpoint";
        }
    }
}
