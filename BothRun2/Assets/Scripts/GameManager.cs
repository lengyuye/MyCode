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

    void Awake()
    {
        Active = this;   
    }


    void Update()
    {
        if (lbTime)
        {
            lbTime.text = string.Format("Time:{0}s", Time.realtimeSinceStartup.ToString("0.00"));
        }
    }



	// Use this for initialization
	void Start () {
        for (int i = 0; i < maxColudsNum; i++)
        {
            int randomIndex = Random.Range(0, GameManager.Active.cloudPrefabs.Count - 1);
            GameObject obj = (GameObject)GameObject.Instantiate(GameManager.Active.cloudPrefabs[randomIndex]);
            obj.SetActive(false);
            cloudsIns.Add(obj);
        }
	}
	

}
