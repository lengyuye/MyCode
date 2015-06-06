using UnityEngine;
using System.Collections;

public class Cloud : MonoBehaviour {

    Transform m_transform;
    private float time = 2f;
    private BoxCollider m_collider;
    

    void Start()
    {
        m_transform = this.transform;
        m_collider = this.GetComponentInChildren<BoxCollider>();
    }


    void Update()
    {
        time -= Time.deltaTime;
        
        if (time < 0)
        {
            time = 2f;
            if (!CameraFollow.Active.IsVisible(m_collider))
            {
                GameManager.Active.cloudsNum--;
                this.gameObject.SetActive(false);
            }
        }

    }

}
