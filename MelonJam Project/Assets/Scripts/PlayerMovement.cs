using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 10f, maxSpeed = 5f, minSpeed = -5f, vertSpeed = 12;
    [SerializeField] private float jumpHeight = 20f;
    [SerializeField] public static bool grounded, hasCrystal;
    private Rigidbody2D body;
    [SerializeField] public Sprite withCrystal;
    protected SpriteRenderer spr;
    public GameObject[] crystals;
    

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        crystals = GameObject.FindGameObjectsWithTag("Crystal");
        

    }

    private void Update()
    {
        body.AddForceX(Input.GetAxis("Horizontal"), ForceMode2D.Impulse);

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            grounded = false;
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

        if (body.linearVelocityY > maxSpeed)
        {
            body.linearVelocity = new Vector3(body.linearVelocityX, vertSpeed, 0);   
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            GameObject crys = ClosestCrystal();
            crys.GetComponent<CrystalLogic>().AttractPlayer(gameObject.transform, body);
            Debug.Log("fortnite");

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Rock") grounded = true;
    }

    public void CollectCrystal()
    {
        spr.sprite = withCrystal;
        hasCrystal = true;
    }

    private GameObject ClosestCrystal()
    {
        var nearestDist = float.MaxValue;
        GameObject nearestObj = null; 
        foreach (GameObject Crystal in crystals)
        {
            if (Vector3.Distance(Crystal.transform.position, gameObject.transform.position) < nearestDist)
            {
                nearestDist = Vector3.Distance(gameObject.transform.position, Crystal.transform.position);
                nearestObj = Crystal;
            }
        }
        Debug.Log($"{nearestObj} is the closest crystal!");
        return nearestObj;
   
    }
        
    
}
