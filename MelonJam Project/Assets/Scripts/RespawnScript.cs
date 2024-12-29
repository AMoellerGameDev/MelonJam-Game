using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public static GameObject player, respawnPoint;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
   
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            respawnPoint = GameObject.FindGameObjectWithTag("Checkpoint");
            player.transform.position = respawnPoint.transform.position;
        }
        else if (collision.gameObject.CompareTag("Rock"))
        {
            respawnPoint = GameObject.FindGameObjectWithTag("Checkpoint");
            collision.transform.position = respawnPoint.transform.position;
        }
    }
}
