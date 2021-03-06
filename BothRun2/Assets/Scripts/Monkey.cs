﻿using UnityEngine;
using System.Collections;

public class Monkey : MonoBehaviour {
    Transform m_transform;
    float delayTime = 0.5f;
    private float orignalY = 0f;
    public float speed = 3f;


    [HideInInspector]
    public bool isWalkOnWall = false;

	// Use this for initialization
	void Start () {
        m_transform = this.transform;
        orignalY = this.transform.position.y;
	}
    private int i = 0;
    void Update()
    {
        if ((orignalY - m_transform.position.y) > 0.1f)
        {
            //i++;
            //if(i==1) 
            GameManager.Active.GameOver();

        }
        else
        {
            Move();
        }
    }

	

    void Jump()
    {
       m_transform.Translate(Vector3.up * 0.5f); 
       // this.rigidbody.constraints=RigidbodyConstraints.FreezeRotation|RigidbodyConstraints.
      //  this.rigidbody.AddForce(Vector3.up, ForceMode.Impulse);
       // this.rigidbody.AddForce(Vector3.up, ForceMode.Impulse);
    }

    
    IEnumerator Down()
    {
        yield return new WaitForSeconds(1f);
        if (m_transform.position.y > orignalY)
        {
            if (!isWalkOnWall)
            {
                m_transform.Translate(Vector3.down * 0.5f);
            }
        }
    }

    void Move()
    {
        m_transform.Translate(Vector3.forward * speed*Time.deltaTime);
    }
}
