using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GroundManager : MonoBehaviour {

    [HideInInspector]
    private Transform m_Trans;
	int addCount=9;
	
    int count;
    public List<GameObject> m_groundPrefab = new List<GameObject>();
	// Use this for initialization
	void Start () {
        m_Trans = this.transform;
		count=addCount-2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddGround()
    {
		count--;
		if(count<0)
		{
			count=addCount-2;
			if (m_groundPrefab.Count > 0)
			{
				for (int i = 0; i < addCount; i++) {
					GameObject ground =(GameObject) GameObject.Instantiate(m_groundPrefab[Random.Range(0,2)]);
					StaticBatchingUtility.Combine(ground);
					ground.transform.parent=m_Trans;
					ground.transform.position = GetRightPos();
				}
			}

			List<GameObject> lst = new List<GameObject>();
			foreach (Transform child in transform)
			{
				if(!child.gameObject.activeInHierarchy)lst.Add(child.gameObject); 
			}
			for(int i = 0;i < lst.Count;i++)
			{
				Destroy(lst[i]);
			}
		}
		
		
    }
	

	
	private Vector3 GetRightPos()
	{
		Transform rightTrans = null;
        foreach (Transform child in m_Trans)
        {
            if (rightTrans == null)
            {
                rightTrans = child;
            }
            else
            {
                if (child.position.z > rightTrans.position.z)
                {
                    rightTrans = child;
                }
            }
        }
        if (rightTrans)
        {
            BoxCollider collider = rightTrans.GetComponentInChildren<BoxCollider>();
			Vector3 newPos=new Vector3(0f,0f,collider.bounds.max.z);
			return newPos;
		}
        else
        {
            return Vector3.zero;
        }

    }
}
