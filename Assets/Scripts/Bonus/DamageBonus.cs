using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DamageBonus : MonoBehaviour, IBonus
{
    public float time;
    public bool pernament;
    private float counter = 0f;
    public int Damage = 2;
    public void Run()
    {
        BallManager.Instance.Balls = BallManager.Instance.Balls.Select(x => { x._damage = Damage; return x; }).ToList();
       
    }

    void Update()
    {
        if (!pernament)
        {
            if(counter >= time)
            {
                BallManager.Instance.Balls = BallManager.Instance.Balls.Select(x => { x._damage = x.Damage; return x; }).ToList();
                Destroy(gameObject);
            }
            else
            {
                counter += Time.deltaTime;
            }
        }
    }
}
