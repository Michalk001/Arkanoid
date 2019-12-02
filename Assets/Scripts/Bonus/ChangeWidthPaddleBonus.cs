using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWidthPaddleBonus : MonoBehaviour, IBonus
{

    public Vector3 toScale;
    public float speed;
    private bool startScale;
    private Paddle paddle;
    public void Run()
    {
      
        paddle = PaddleManager.Instance.Paddle;
        AudioManager.Instance.Play("changeWidth");
        startScale = true;
    }
    private void ScalePaddle()
    {
        if (startScale)
        {

            paddle.transform.localScale = Vector3.Lerp(paddle.transform.localScale, toScale, speed * Time.deltaTime);
            if (paddle.transform.localScale == toScale)
            {
                startScale = false;
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        ScalePaddle();
    }
}
