using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    [SerializeField] private GameObject pointA, pointB;
    private Rigidbody2D rb;
    private Transform currentPoint;
    [SerializeField] private float speed;
    private static GameObject player, respawnPoint;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
        player = GameObject.FindGameObjectWithTag("Player");
   

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.linearVelocity = new Vector2(speed, 0);
        }
        else
        {
            rb.linearVelocity = new Vector2 (-speed, 0);       
        }
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if  (collision.gameObject.tag == "Rock")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            respawnPoint = GameObject.FindGameObjectWithTag("Checkpoint");
            player.transform.position = respawnPoint.transform.position;
        }

    }
}
