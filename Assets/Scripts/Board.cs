using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Board : MonoBehaviour
{


    private Brick[] bricks;
    public int CountCurrentyBrickInBoard()
    {
        return bricks.Where(x => x.indestructible == false).Where(x => x.gameObject.activeSelf == true).Count();
    }
    public void Reset()
    {
      
        foreach (var item in bricks)
            item.Reset();
        Init();
    }
    private void Init()
    {
        BoardlManager.Instance.TotalBrickOnBoard = bricks.Where(x => x.indestructible == false).Count();
    }
    private void Awake()
    {
        bricks = gameObject.GetComponentsInChildren<Brick>();
        Init();
        foreach (var item in bricks)
            item.transform.parent = gameObject.transform;
    }
}
