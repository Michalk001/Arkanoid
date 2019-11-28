﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D Rb;
    public float speed;
    public int Demage = 1;
    public int _demage { get; set; }
    private readonly int crossMove = 200;

    private readonly string BottomWallTag = "BottomWall";
    private readonly string PaddleTag = "Paddle";
    void Start()
    {
        _demage = Demage;


    }

    void OnTriggerEnter2D(Collider2D other)
    {
     
        if (other.CompareTag(BottomWallTag))
        {
            if (BallManager.Instance.BallOnBoard <= 1)
            {
                --GameManager.Instance.Life;
                Rb.velocity = Vector2.zero;
                GameManager.Instance.IsGameStart = false;
            
            }
            else
            {
                --BallManager.Instance.BallOnBoard;
                BallManager.Instance.Balls.Remove(gameObject.GetComponent<Ball>());
                Destroy(gameObject);
            }
          
          
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.tag == PaddleTag)
        {
          
            Vector3 hitPoint = coll.contacts[0].point;
            Vector3 paddleCenter = new Vector3(PaddleManager.Instance.Paddle.gameObject.transform.position.x, PaddleManager.Instance.Paddle.gameObject.transform.position.y);
            Rb.velocity = Vector2.zero;

            float difference = paddleCenter.x - hitPoint.x;
            if (hitPoint.x < paddleCenter.x)
            {
                Rb.AddForce(new Vector2(-(Mathf.Abs(difference * crossMove)), speed));
            }
            else
            {
                Rb.AddForce(new Vector2((Mathf.Abs(difference * crossMove)), speed));
            }
        }
    }


   

}
