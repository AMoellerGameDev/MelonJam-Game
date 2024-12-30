using Unity.VisualScripting;
using UnityEngine;

public class CrystalLogic : MonoBehaviour
{
    [SerializeField] static bool active = false;
    GameObject player;
    Rigidbody2D playerRb;
    [SerializeField] static private float strength = 5;
    SoundManager audio;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
        audio = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<SoundManager>();
    }

   /* private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (active)
            {
                Vector3 dir = transform.position - player.transform.position;
                playerRb.AddForce(dir.normalized * strength, ForceMode2D.Impulse);
            }
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            active = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            active = false;
    }

    public void AttractPlayer(Transform player, Rigidbody2D playerRb)
    {
        if (active)
        {
            audio.PlaySFX(audio.blueCrystalLoop);
            Vector3 dir = transform.position - player.transform.position;
            playerRb.AddForce(dir.normalized * strength, ForceMode2D.Impulse);
        }
    }
}
