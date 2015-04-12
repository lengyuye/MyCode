using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public List<GameObject> wallsPerfabs = new List<GameObject>();
    public List<GameObject> cloudPrefabs = new List<GameObject>();
    public List<GameObject> cloudsIns = new List<GameObject>();
    public int maxColudsNum = 25;

    public static GameManager Active;
	public int cloudsNum=0;
    public UILabel lbTime;
    public UILabel lbGameOver;

    public GameObject btnExit;
    public GameObject btnTryAgain;
    public GameObject spMenu;
    private bool isOver = false;

    void Awake()
    {
        Active = this;   
    }


    void Update()
    {
        if (lbTime)
        {
            if (isOver) return;
            lbTime.text = string.Format("Time:{0}s", Time.timeSinceLevelLoad.ToString("0.00"));
        }
    }



	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        for (int i = 0; i < maxColudsNum; i++)
        {
            int randomIndex = Random.Range(0, GameManager.Active.cloudPrefabs.Count - 1);
            GameObject obj = (GameObject)GameObject.Instantiate(GameManager.Active.cloudPrefabs[randomIndex]);
            obj.SetActive(false);
            cloudsIns.Add(obj);
        }
        if (lbGameOver) lbGameOver.gameObject.SetActive(false);
	}



    public void GameOver()
    {
        Debug.Log("GameOver");
        if (!isOver)
        {
            isOver = true;
            Time.timeScale = 0;
            SetMenuShow(true);
        }
      
    }

    private void SetMenuShow(bool isShow)
    {
        lbGameOver.gameObject.SetActive(isShow);
        btnExit.SetActive(isShow);
        btnTryAgain.SetActive(isShow);
        spMenu.SetActive(isShow);
    }

    void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    void TryAgain()
    {
        Application.LoadLevel(0);
        //Debug.Log("TryAgain");
        //Time.timeScale = 1;
        //isOver = false;
        //SetMenuShow(false);
        //lbTime.text = string.Format("Time:{0}s", 0);
    }
}
