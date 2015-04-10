using UnityEngine;
using System.Collections;

public class Monkey1 : MonoBehaviour {
    Transform m_transform;
    float delayTime = 0.5f;
    private float orignalY = 0f;
	// Use this for initialization
	void Start () {
        m_transform = this.transform;
        orignalY = this.transform.position.y;
	}
    private int i = 0;
    void Update()
    {
        if ((orignalY - m_transform.position.y) > 0.05f)
        {
            //i++;
            //if(i==1) 
                GameManager.Active.GameOver();
            
        }
    }
	

    void Jump()
    {
        m_transform.Translate(Vector3.up * 1f); 
    }

    //IEnumerator Down()
    //{
    //    yield return new WaitForSeconds(1.5f);
    //    if (m_transform.position.y > orignalY)
    //    {
    //        m_transform.Translate(Vector3.down * 0.5f); 
    //    }
      
    //}
}
