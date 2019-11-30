using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWidthPaddleBonus : MonoBehaviour, IBonus
{

    public Vector3 toScale;
    public float speed;
    private bool finishScale = true;
    private Paddle paddle;
    public void Run()
    {
        paddle = PaddleManager.Instance.Paddle;
        finishScale = false;
    }
    private void ScalePaddle()
    {
        if (!finishScale)
        {

            paddle.transform.localScale = Vector3.Lerp(paddle.transform.localScale, toScale, speed * Time.deltaTime);
            if (paddle.transform.localScale == toScale)
            {
                finishScale = true;
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        ScalePaddle();
    }
}
