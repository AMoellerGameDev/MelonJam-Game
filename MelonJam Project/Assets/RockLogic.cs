using UnityEngine;
using UnityEngine.Rendering;

public class RockLogic : MonoBehaviour
{
    private CircleCollider2D hitbox;
    [SerializeField] public bool grabbable, followingMouse;
    private float speed = 6f;
    GameObject player;
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnMouseDown()
    {

        if (grabbable) followingMouse = true;

    }

    private void Update()
    {
        if ( Vector3.Distance(player.transform.position, transform.position) > 3.5)
        {
            grabbable = false;
            followingMouse = false;

        }
        else
        {
            grabbable = true;
        }

        if (followingMouse)
        {
            Vector3 mousepos = Input.mousePosition;
            mousepos = Camera.main.ScreenToWorldPoint(mousepos);
            transform.position = Vector2.Lerp(transform.position, mousepos, speed);
           

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            followingMouse = false;
            Vector2 Launchdir = transform.position - player.transform.position;
            rb.linearVelocity = Launchdir.normalized * 6;
        }
    }

}
