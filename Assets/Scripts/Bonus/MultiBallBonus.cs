using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBallBonus : MonoBehaviour, IBonus
{
    
    public void Run()
    {
        AudioManager.Instance.Play("getBonus");
        SpawnBall();
    }

    private void SpawnBall()
    {
        List<Ball> balls = BallManager.Instance.Balls;

        List<Ball> ballstmp = new List<Ball>();
        foreach (var item in balls)
        {
             
            Vector3 startPosition = new Vector3(item.transform.position.x, item.transform.position.y, item.transform.position.z);
            var _ball = Instantiate(BallManager.Instance.Ball, startPosition, Quaternion.identity);
            var _ball2 = Instantiate(BallManager.Instance.Ball, startPosition, Quaternion.identity);
            _ball.Rb.AddForce(new Vector2(BallManager.Instance.initBallSpeed / 2, BallManager.Instance.initBallSpeed));
            _ball2.Rb.AddForce(new Vector2(-BallManager.Instance.initBallSpeed / 2, BallManager.Instance.initBallSpeed));

            _ball.transform.parent = _ball2.transform.parent = BallManager.Instance.gameObject.transform;
            ballstmp.Add(_ball);
            ballstmp.Add(_ball2);

        }
        BallManager.Instance.Balls.AddRange(ballstmp);
        BallManager.Instance.BallOnBoard = BallManager.Instance.Balls.Count;
   
    }

}
