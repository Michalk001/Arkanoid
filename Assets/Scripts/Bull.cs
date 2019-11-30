using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{


    public Sprite bull;
    private SpriteRenderer spriteRenderer;
    public Rigidbody2D RB;
    public float speed;
    public Transform Parent { get; set; }

    private readonly string BrickTag = "Brick";
    private readonly string WallTag = "Wall";
    private readonly float TimeToHidden = 2.5f;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = bull;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == WallTag || coll.gameObject.tag == BrickTag)
        {
            HiddenObject();
        }
    }

    void Update()
    {
        if (!BoardlManager.Instance.PlayLVL )
        {
          
            RB.isKinematic = false;
            RB.Sleep();
            RB.velocity = Vector2.zero;
            Invoke("HiddenObject", TimeToHidden);
        }
                
    }
    
    public void Move()
    {
        
        gameObject.SetActive(true);
        RB.isKinematic = false;
        RB.velocity = Vector2.zero;
        gameObject.transform.position = gameObject.transform.parent.position;
        Parent = gameObject.transform.parent;
        transform.parent = null;
        RB.AddForce(Vector2.up * speed);
       

    }

    private void HiddenObject()
    {
        transform.parent = Parent;
        gameObject.SetActive(false);
    }
}
