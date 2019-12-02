using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatsManager : MonoBehaviour
{
    public bool ActiveCheats = false;


    private void SpawnMultiBall()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MultiBallBonus multiBallBonus = new MultiBallBonus();
            multiBallBonus.Run();
           // BonusManager.Instance.SpawnMultiBall();

        }
    }

    private void AddLife()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.Instance.Life += 1;
        }
    }
    private void AddGuns()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

        }
    }
    private void NextBoard()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            BoardlManager.Instance.NextBoard();
        }
    }
    void Update()
    {
        if(ActiveCheats)
        {
            SpawnMultiBall();
            AddLife();
            AddGuns();
            NextBoard();
        }
    }
}
