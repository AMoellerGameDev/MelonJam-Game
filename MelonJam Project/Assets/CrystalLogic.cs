using Unity.VisualScripting;
using UnityEngine;

public class CrystalLogic : MonoBehaviour
{
    [SerializeField] bool active = false;
    GameObject player;
    Rigidbody2D playerRb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (active)
            {
                Vector3 dir = transform.position - player.transform.position;
                playerRb.AddForce(dir, ForceMode2D.Impulse);
            }
        }
    }

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
}
