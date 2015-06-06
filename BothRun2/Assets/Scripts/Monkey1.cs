using UnityEngine;
using System.Collections;

public class Monkey1 : MonoBehaviour {
    Transform m_transform;
    private float orignalY = 0f;
    public float speed = 3f;
	// Use this for initialization
	void Start () {
        m_transform = this.transform;
        orignalY = this.transform.position.y;
	}
    private int i = 0;
    void Update()
    {
        if ((orignalY - m_transform.position.y) > 0.01f)
        {
            //i++;
            //if(i==1) 
            Debug.Log("orignalY:" + orignalY);
            Debug.Log("m_transform.position.y:" + m_transform.position.y);
            GameManager.Active.GameOver();
        }
        else
        {
            Move();
        }
    }
	

    void Jump()
    {
        this.rigidbody.AddForce(Vector3.up, ForceMode.Impulse);
    }

    void Move()
    {
        m_transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

}
