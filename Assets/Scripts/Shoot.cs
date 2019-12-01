using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Bull bullPref;
    private float counter = 0;
    private int bullCounter = 0;
    private int maxBullInstance = 10;
    public List<Bull> bulls { get; set; }
    void Start()
    {
        bulls = new List<Bull>();
       
    }

    public void HiddenBulls()
    {
        foreach(var item in bulls)
        {
            item.gameObject.SetActive(false);
        }
    }
 
    void Update()
    {

        if (GameManager.Instance.IsGameStart)
        {

            if (Input.GetKeyDown(KeyCode.Space) && counter > 0.4f)
            {
                AudioManager.Instance.Play("laserShoot");
                Vector3 position = transform.position;
                if (bulls.Count < 10)
                {
                    var bull = Instantiate(bullPref, position, Quaternion.identity);
                    bull.gameObject.transform.SetParent(gameObject.transform,false);
                    bull.gameObject.transform.localScale = new Vector3(0.5f, 2f, 1f);
                    bull.Move();
                    bulls.Add(bull);
                    ++bullCounter;
                }
                else
                {
                    bulls[bullCounter].gameObject.SetActive(true);
                    bulls[bullCounter].Move();
                }
                if (bullCounter >= maxBullInstance-1)
                    bullCounter = 0;
                else
                    ++bullCounter;
                counter = 0f;
              


            }
            counter += Time.deltaTime;
        }


    }
}
