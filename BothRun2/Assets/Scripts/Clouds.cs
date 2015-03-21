using UnityEngine;
using System.Collections;

public class Clouds : MonoBehaviour {

    Transform m_transform;
    
    float distance =-10f;

    float createTimeInterval = 0.5f;
    int time = 5;


	// Use this for initialization
	void Start () {
        m_transform = this.transform;
        if (GameManager.Active.cloudPrefabs.Count == 0)
        {
            Debug.LogError("no find clouds");
            return;
        }
        CreateCloud();
	}
	
	// Update is called once per frame
	void Update () {
        createTimeInterval -= Time.deltaTime;
        if (time > 0)
        {
            CreateCloud();
            time--;
        }
        else
        {
            if (createTimeInterval < 0)
            {
                createTimeInterval = 0.5f;
                CreateCloud();
            }
        }


        

	}

    private int randomIndex = 0;
    private void CreateCloud()
    {
        if (GameManager.Active.cloudsNum >= GameManager.Active.maxColudsNum)
        {    
            distance -= 1;
            return;
        }

        if (randomIndex >= GameManager.Active.maxColudsNum)
        {
            randomIndex = 0;
        }

        //Debug.Log("randomIndex:" + randomIndex); 

        GameObject obj =GameManager.Active.cloudsIns[randomIndex];
        obj.SetActive(true);
        obj.transform.parent = this.transform;
        obj.transform.localPosition = new Vector3(0, 0, distance);
        distance += Random.Range(3,5);
        randomIndex++;
		GameManager.Active.cloudsNum++;
        //Debug.Log(" CreateCloud  GameManager.Active.cloudsNum: " + GameManager.Active.cloudsNum); 
    }

    //缓慢移动中景
}
