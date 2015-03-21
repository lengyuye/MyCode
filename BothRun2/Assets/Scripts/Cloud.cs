using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {

    Transform m_transform;
    float speed = 0.05f;


    void Start()
    {
        m_transform = this.transform;
    }


    void Update()
    {
        m_transform.Translate(Vector3.back * speed);
    }

	
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("end"))
        {
			GameManager.Active.cloudsNum--;
            this.gameObject.SetActive(false);
        }
    }


}
