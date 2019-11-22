using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardlManager : MonoBehaviour
{

    #region Singleton
    private static BoardlManager _instance;

    public static BoardlManager Instance => _instance;

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



    [SerializeField]
    public List<Board> Boards;
    private Board Board;
    public bool PlayLVL { get; set; } = false;
    public int BoardNumber;
    private int CurrentyBoard;
    public int TotalBrickOnBoard { get; set; }
    public GameObject NextBoardSplash;
    private GameObject _NextBoardSplash = null;
    private List<Board> boards;
    private bool changingBoard = false;
    private void Start()
    {
        
        NextBoardSplash.gameObject.GetComponentInChildren<Canvas>().worldCamera = Camera.main;
        _NextBoardSplash = Instantiate(NextBoardSplash);
        _NextBoardSplash.SetActive(false);
        BoardInit();
    }
    private void BoardInit()
    {
        CurrentyBoard = BoardNumber = 0;
       
        boards = new List<Board>
        {
            Instantiate(Boards[BoardNumber])
        };
        boards[BoardNumber].transform.parent = gameObject.transform;
        PlayLVL = true;

    }

    public void Reset()
    {
        boards[BoardNumber].gameObject.SetActive(false);
        BoardNumber = 0;
        if (_NextBoardSplash != null)
            _NextBoardSplash.SetActive(false);
        ChangeBoard();
    }

    private void ChangeBoard()
    {
        
        GameManager.Instance.IsGameStart = false;
        boards[CurrentyBoard].gameObject.SetActive(false);
        
        if (BoardNumber > Boards.Count - 1)
            BoardNumber = 0;
        CurrentyBoard = BoardNumber;
        Debug.Log(BoardNumber);
        if (boards.Count <= BoardNumber)
        {
     
            boards.Add(Instantiate(Boards[BoardNumber]));
            boards[BoardNumber].transform.parent = gameObject.transform;
        }
        else
        {
            boards[BoardNumber].gameObject.SetActive(true);
            boards[BoardNumber].Reset();
        }

        _NextBoardSplash.SetActive(false);

        PlayLVL = true;
        changingBoard = false;
    }

    private void Update()
    {
        if (TotalBrickOnBoard <=0 && !changingBoard)
        {
            changingBoard = true;
            _NextBoardSplash.SetActive(true);
            PlayLVL = false;
            ++BoardNumber;
            Debug.Log(BoardNumber);
            Invoke("ChangeBoard", 2.5f);
        }
    }

}
