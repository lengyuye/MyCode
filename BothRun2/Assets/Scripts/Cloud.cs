using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {

    Transform m_transform;
    float speed = 0.05f;
   // public float lifeTime=30f;


    void Start()
    {
        m_transform = this.transform;
    }


    void Update()
    {
        //lifeTime -= Time.deltaTime;
        //if (lifeTime < 0)
        //{
        //    Destroy(this.gameObject);
        //}
        m_transform.Translate(Vector3.back * speed);
    }

	
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        if (collision.transform.tag.Equals("end"))
        {

			GameManager.Active.cloudsNum--;
            Debug.Log("GameManager.Active.cloudsNum:" + GameManager.Active.cloudsNum);
           // Debug.Log(" Destroy(this)");
            this.gameObject.SetActive(false);
           // Destroy(this.gameObject);
        }
    }


}
