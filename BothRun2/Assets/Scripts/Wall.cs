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
        if (collision.gameObject.tag.Equals("Player") )
        {
            if (collision.gameObject.transform.position.y < 0.1f)
            {
                GameManager.Active.GameOver();
            }
            else
            {
                Debug.Log("isWalkOnWall");
                Monkey monkey = collision.gameObject.GetComponent<Monkey>();
                monkey.isWalkOnWall = true;
            }
           
        }

    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Monkey monkey = collision.gameObject.GetComponent<Monkey>();
            monkey.isWalkOnWall = false;
            collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, 0f, collision.gameObject.transform.position.z);
        }
    }

}
