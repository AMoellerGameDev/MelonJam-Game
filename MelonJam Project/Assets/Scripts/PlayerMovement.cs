using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f, maxSpeed = 5f, minSpeed = -5f;
    [SerializeField] private float jumpHeight = 20f;
    public static bool grounded, hasCrystal;
    private Rigidbody2D body;
    [SerializeField] public Sprite withCrystal;
    protected SpriteRenderer spr;
    

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();  
        

    }

    private void Update()
    {
        body.AddForceX(Input.GetAxis("Horizontal"), ForceMode2D.Impulse);

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            body.linearVelocityY = 0;
            body.AddForceY(jumpHeight, ForceMode2D.Impulse);
        }

        if (body.linearVelocityX > maxSpeed)
        {
            body.linearVelocity = new Vector3(maxSpeed, body.linearVelocityY, 0);
        }
        else if (body.linearVelocityX < minSpeed) 
        {
            body.linearVelocity = new Vector3(minSpeed, body.linearVelocityY, 0); 
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") grounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }

    public void CollectCrystal()
    {
        spr.sprite = withCrystal;
        hasCrystal = true;
    }

}
