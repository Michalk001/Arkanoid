using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBonus : MonoBehaviour, IBonus
{

    public float WorkTime;

    
    public bool Pernament;

    void Start()
    {
       
    }
    private GameObject gun { get; set; } = null;
    private float counterGuns = 0f;
    public void Run()
    {

        AddGuns(WorkTime, Pernament);
    }

    private bool hiddenGun = false;
    public void AddGuns(float time, bool pernament)
    {
        Debug.Log(time);

        if (gun == null)
        {
            gun = Instantiate(PaddleManager.Instance.Guns[0], new Vector3(0.048f, 0.21f, 0), Quaternion.identity);
            gun.transform.parent = PaddleManager.Instance.Paddle.gameObject.transform;
            gun.transform.localPosition = new Vector3(0.048f, 0.21f, 0);
            gun.gameObject.transform.localScale = new Vector3(0.0403f, 0.024f, 0);

        }
        else
        {
            gun.SetActive(true);
            ResetBull();
        }
        if (!pernament)
        {
            
            counterGuns = time;
            hiddenGun = true;
        }
        else
        {
            hiddenGun = false;
        }

    }

    private void ResetBull()
    {
        var bb = gun.GetComponentsInChildren<Shoot>();
        foreach (var item in bb)
        {
            item.HiddenBulls();
        }
    }
    private void HiddenGuns()
    {
       
        if (counterGuns < 0f && hiddenGun)
        {
            Debug.Log(111111);
            gun.SetActive(false);
            hiddenGun = false;
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log(counterGuns);
            if (!GameManager.Instance.gamePause && hiddenGun)
                counterGuns -= Time.deltaTime;
        }
    }

    public void Update()
    {
       
        HiddenGuns();
    }

}
