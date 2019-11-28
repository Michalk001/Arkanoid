using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    public Sprite sprite;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D RB;
    public float speed;
    public string id;
    public float time;
    public bool permanent = false;

    private readonly string PaddleTag = "Paddle";
    private readonly string BottomWallTag = "BottomWall";
    public void Move()
    {
        RB.isKinematic = false;
        RB.velocity = Vector2.zero;
        RB.AddForce(Vector2.down * speed);
    }
    void Start()
    {
      
        Init();
    }

    private void Init()
    {
        spriteRenderer.sprite = sprite;
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
        if (coll.gameObject.CompareTag(PaddleTag) || coll.gameObject.CompareTag(BottomWallTag))
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
