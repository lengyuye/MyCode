using UnityEngine;
using System.Collections;


public class Ground : MonoBehaviour {

    Transform m_transform;

    float speed = 0.05f;
    float moveLength = 25.09f;
    GameObject wallObj;
    private bool m_HasShowInCamera = false;
    private BoxCollider m_collider;

    // Use this for initialization
    void Start()
    {
        m_collider = this.GetComponentInChildren<BoxCollider>();
        m_transform = this.transform;
        if (GameManager.Active)
        {
            if (GameManager.Active.wallsPerfabs.Count == 0)
            {
                Debug.LogError("no find wall");
                return;
            }
            RandomCreateWall();
        }
     
    }


	
	private void RandomCreateWall()
	{
		Transform wall = m_transform.FindChild("Wall");
        if (wall) Destroy(wall.gameObject);

        int wallIndex = Random.Range(0, GameManager.Active.wallsPerfabs.Count - 1);
        //Debug.Log("wallIndex:" + wallIndex);
        wallObj = (GameObject)GameObject.Instantiate(GameManager.Active.wallsPerfabs[wallIndex]);
        if (wallObj)
        {
            wallObj.name = "Wall";
            wallObj.transform.parent = m_transform;
            wallObj.transform.localPosition = Vector3.zero;
        }
        RandomPosition();
    }






    private float m_checkTime = 0.5f;
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0) return;
        /*
        m_transform.Translate(Vector3.back * speed);
        if (m_transform.position.z < -2 * moveLength)
        {
            //移动地图
            m_transform.position = new Vector3(m_transform.position.x, m_transform.position.y, moveLength);
            //随机改变位置
            RandomCreateWall();
        }*/
        m_checkTime -= Time.deltaTime;
        if (m_checkTime < 0)
        {
            m_checkTime = 0.5f;
            if (!CameraFollow.Active.IsVisible(m_collider) )
            {
				if(m_HasShowInCamera)
				{
                   GroundManager manger= this.gameObject.transform.parent.gameObject.GetComponent<GroundManager>();
                   if (manger)
                   {
                       manger.AddGround();
                   }
					//Destroy(this.gameObject);
                    this.gameObject.SetActive(false);
				}
            }
            else
            {
                if (!m_HasShowInCamera) m_HasShowInCamera = true;
            }

        }
		//Test();
	}

    private void RandomPosition()
    {
        Wall wall = m_transform.FindChild("Wall").GetComponent<Wall>();
        wall.RandomPosition();
    }




}
