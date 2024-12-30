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
    private bool fadeIn = false, fadeOut = false;

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
            FadeIn();
            audio.PlaySFX(audio.death);
            yield return new WaitForSeconds(3);
                FadeOut();
                respawnPoint = GameObject.FindGameObjectWithTag("Checkpoint");
                collision.attachedRigidbody.linearVelocity = new Vector2(0, 0);
                player.transform.position = respawnPoint.transform.position;
            
        }
    }
    public void FadeIn()
    {

        fadeIn = true;
    }

    public void FadeOut()
    {
        fadeOut = true;
    }

    public void Update()
    {
        if (fadeIn)
        {
            if (deathScreen.alpha < 1)
            {
                deathScreen.alpha += Time.deltaTime;
                if (deathScreen.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut)
        {
            if (deathScreen.alpha > 0)
            {
                deathScreen.alpha -= Time.deltaTime;
                if (deathScreen.alpha <= 0)
                {
                    fadeOut = false;
                }
            }
        }
    }
}
