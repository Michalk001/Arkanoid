using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour
{
    // Start is called before the first frame update
    public Text TotalScoreText;
    public Text LifeText;
    public GameManager gameManager { get; set; } = null;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager != null)
        {
            TotalScoreText.text = GameManager.Instance.TotalScore.ToString();
            LifeText.text = GameManager.Instance.Life.ToString();
        }

    }
}
