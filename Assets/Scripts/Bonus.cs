using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public Sprite sprite;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D RB;
    public float speed;
    public string id;
    public float time;
    public bool permanent = false;
    public void Move()
    {
        RB.isKinematic = false;
        RB.velocity = Vector2.zero;
        RB.AddForce(Vector2.down * speed);
    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        RB = GetComponent<Rigidbody2D>();
        RB.isKinematic = false;
        RB.velocity = Vector2.zero;
        RB.AddForce(Vector2.down * speed);
    }
    public void StopMovement()
    {
        RB.isKinematic = false;
        RB.Sleep();
        RB.velocity = Vector2.zero;
    }
   

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Paddle") || coll.gameObject.CompareTag("BottomWall"))
        {
            gameObject.SetActive(false);
        }
    }
        void Update()
        {
            if (!BoardlManager.Instance.PlayLVL)
            {
                StopMovement();
            }
        }
}
