using UnityEngine;
using UnityEngine.Rendering;

public class RockLogic : MonoBehaviour
{
    private CircleCollider2D hitbox;
    [SerializeField] public bool grabbable, followingMouse;
    private float speed = 6f;
    GameObject player;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Color activeColor = new Color(0.7490196f, 0.3139045f, 0.3791718f);


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown()
    {

        if (grabbable) followingMouse = true;

    }

    private void Update()
    {
        if (PlayerMovement.hasCrystal)
        {

            if (Vector3.Distance(player.transform.position, transform.position) > 10)
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
                sr.color = activeColor;
                Vector3 mousepos = Input.mousePosition;
                mousepos = Camera.main.ScreenToWorldPoint(mousepos);
                transform.position = Vector2.Lerp(transform.position, mousepos, speed);
                


            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                followingMouse = false;
                Vector2 Launchdir = transform.position - player.transform.position;
                rb.linearVelocity = Launchdir.normalized * 12;
                sr.color = Color.white;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (followingMouse)
        {
            followingMouse = false;
        }
    }

}
