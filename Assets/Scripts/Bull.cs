using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{


    public Sprite bull;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D RB;
    public float speed;
    public Transform parent;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = bull;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Wall" || coll.gameObject.tag == "Brick")
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
            Invoke("HiddenObject", 2.5f);
        }
                
    }
    
    public void Move()
    {
        RB = GetComponent<Rigidbody2D>();
        gameObject.SetActive(true);
        RB.isKinematic = false;
        RB.velocity = Vector2.zero;
        gameObject.transform.position = gameObject.transform.parent.position;
        RB.AddForce(Vector2.up * speed);
       

    }

    private void HiddenObject()
    {

        gameObject.SetActive(false);
    }
}
