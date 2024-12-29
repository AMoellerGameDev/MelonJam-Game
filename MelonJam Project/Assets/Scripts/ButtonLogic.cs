using System.Xml.Linq;
using UnityEngine;

public class ButtonLogic : MonoBehaviour
{
    public SpriteRenderer sr;
    public BoxCollider2D bcollider;
    public Color color = Color.red;
    bool isPressed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bcollider = GetComponent<BoxCollider2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        sr.color = color;
        isPressed = true;
    }
}
