using UnityEngine;
using System.Collections;

public class Monkey : MonoBehaviour {
    Transform m_transform;
    float delayTime = 0.5f;
	// Use this for initialization
	void Start () {
        m_transform = this.transform;
	}
	

    void Jump()
    {
        Debug.Log("Jump");
        m_transform.Translate(Vector3.up * 0.5f); 
    }

    IEnumerator Down()
    {
        yield return new WaitForSeconds(0.5f);
        m_transform.Translate(Vector3.down * 0.5f); 
    }
}
