using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBonus : MonoBehaviour, IBonus
{
    public float WorkTime { get; set; }
    public bool Pernament { get; set; }
    public void Run()
    {
        GameManager.Instance.Life += 1;
    }
    public void Run(float time)
    {
        Run();
    }

   

}
