using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMenager : MonoBehaviour
{
 

    #region Singleton
    private static BonusMenager _instance;

    public static BonusMenager Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    public void RunBonus(string id, float time, bool pernament)
    {
        switch (id)
        {
            case "gun":
            {
                    AddGuns(time, pernament);
                break;
            }
        }
    }
    private void AddGuns(float time, bool pernament)
    {
       
        if (PaddleManager.Instance.gun == null)
        {
            PaddleManager.Instance.gun = Instantiate(PaddleManager.Instance.Guns[0], new Vector3(0.048f, 0.21f, 0), Quaternion.identity);
            PaddleManager.Instance.gun.transform.parent = PaddleManager.Instance.Paddle.gameObject.transform;
            PaddleManager.Instance.gun.transform.localPosition = new Vector3(0.048f, 0.21f, 0);
            PaddleManager.Instance.gun.gameObject.transform.localScale = new Vector3(0.0403f, 0.024f, 0);
        }
        else
            PaddleManager.Instance.gun.SetActive(true);
        if (!pernament)
            Invoke("HiddenGuns", time);
    }
    private void HiddenGuns()
    {
        PaddleManager.Instance.gun.SetActive(false);
    }

}
