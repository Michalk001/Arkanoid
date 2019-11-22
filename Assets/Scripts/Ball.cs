using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public float speed;
    public int Demage = 1;
    public int _demage { get; set; }
    void Start()
    {
        _demage = Demage;


    }
    void Awake()
    {
       
        rb = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
     
        if (other.CompareTag("BottomWall"))
        {
            --GameManager.Instance.Life;
            rb.velocity = Vector2.zero;
            GameManager.Instance.IsGameStart = false;
          
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == "Paddle")
        {
          
            Vector3 hitPoint = coll.contacts[0].point;
            Vector3 paddleCenter = new Vector3(PaddleManager.Instance.Paddle.gameObject.transform.position.x, PaddleManager.Instance.Paddle.gameObject.transform.position.y);
            rb.velocity = Vector2.zero;

            float difference = paddleCenter.x - hitPoint.x;
            if (hitPoint.x < paddleCenter.x)
            {
                rb.AddForce(new Vector2(-(Mathf.Abs(difference * 200)), 8000f));
            }
            else
            {
                rb.AddForce(new Vector2((Mathf.Abs(difference * 200)), 8000f));
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
   
       
    }

   

}
