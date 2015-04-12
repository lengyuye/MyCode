using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

    Transform m_transform;
    // Use this for initialization
    void Awake()
    {
        m_transform = this.transform;
    }


    public void RandomPosition()
    {
        m_transform.localPosition = new Vector3(m_transform.localPosition.x, m_transform.localPosition.y, Random.Range(5, 20));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player") && collision.gameObject.transform.position.y < 0.1f)
        {
            GameManager.Active.GameOver();
        }

    }

}
