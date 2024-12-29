using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public GameObject player, respawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPoint.transform.position;
        }
        else if (collision.gameObject.CompareTag("Rock"))
        {
            collision.transform.position = respawnPoint.transform.position;
        }
    }
}
