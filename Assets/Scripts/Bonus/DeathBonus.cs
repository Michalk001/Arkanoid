using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBonus : MonoBehaviour, IBonus
{
    public float WorkTime { get; set; }
    public bool Pernament { get; set; }
    public void Run()
    {
        GameManager.Instance.Life = 0;
    }
    public void Run(float time)
    {
        Run();
    }
}
