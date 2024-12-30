using JetBrains.Annotations;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class RespawnScript : MonoBehaviour
{
    public GameObject player, respawnPoint, deathPanel;
    SoundManager audio;
    [SerializeField] private CanvasGroup deathScreen;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<SoundManager>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(RespawnPlayer());
        }
        else if (collision.gameObject.CompareTag("Rock"))
        {
            respawnPoint = GameObject.FindGameObjectWithTag("Checkpoint");
            collision.attachedRigidbody.linearVelocityX = 0;
            collision.transform.position = respawnPoint.transform.position;
        }

        IEnumerator RespawnPlayer()
        {
            
            audio.PlaySFX(audio.death);
            yield return new WaitForSeconds(3);
                deathPanel.SetActive(false);
                respawnPoint = GameObject.FindGameObjectWithTag("Checkpoint");
                collision.attachedRigidbody.linearVelocity = new Vector2(0, 0);
                player.transform.position = respawnPoint.transform.position;
            
        }
    }
    public void FadeIn()
    {
        deathScreen.alpha = 1;
    }

    public void FadeOut()
    {
        deathScreen.alpha = 0;
    }

}
