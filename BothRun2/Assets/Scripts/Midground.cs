using UnityEngine;
using System.Collections;

public class Midground : MonoBehaviour {

    Transform m_transform;
    float speed = 0.01f;
    float time = 10;
	// Use this for initialization
	void Start () {
        m_transform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;
        if (time < 0)
        {
            Debug.Log("time = 10;");
            speed = -speed;
            Debug.Log("speed:" + speed);
            time = 10;
        }
        m_transform.Translate(Vector3.back * speed);
	}
}
