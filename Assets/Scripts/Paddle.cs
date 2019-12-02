using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    private float leftScreenEdge { get; set; }
    private float rightScreenEdge { get; set; }
    private BoxCollider2D boxCollider2D;
    private float fixPositionXInBoard = 3.66f;
    void Start()
    {
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        leftScreenEdge = PaddleManager.Instance.leftScreenEdge;
        rightScreenEdge = PaddleManager.Instance.rightScreenEdge;

    }

    void Update()
    {
        PaddleMovement();
    }
    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.CompareTag("Bonus"))
        {
          
            var obj = coll.gameObject.GetComponent<IBonus>();
            obj.Run();
          
        }
    }
    public void PaddleStartPosition()
    {
        transform.position = new Vector3((leftScreenEdge + rightScreenEdge), transform.position.y, transform.position.z);
    }
    private void PaddleMovement()
    {
        if (!BoardlManager.Instance.PlayLVL)
            return;
        float horizontal = Input.GetAxis("Horizontal");
       
            transform.Translate(Vector2.right * horizontal * Time.deltaTime * PaddleManager.Instance.speed);
        if (transform.position.x - boxCollider2D.size.x * gameObject.transform.localScale.x /2 + fixPositionXInBoard < leftScreenEdge)
            transform.position = new Vector2(leftScreenEdge + boxCollider2D.size.x * gameObject.transform.localScale.x / 2 - fixPositionXInBoard, transform.position.y);
        if (transform.position.x + boxCollider2D.size.x * gameObject.transform.localScale.x / 2 + fixPositionXInBoard > rightScreenEdge)
            transform.position = new Vector2(rightScreenEdge - boxCollider2D.size.x * gameObject.transform.localScale.x / 2 - fixPositionXInBoard, transform.position.y);


    }



}
