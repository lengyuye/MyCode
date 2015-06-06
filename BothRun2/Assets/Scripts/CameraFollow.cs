using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	// Use this for initialization
    public Transform MonkeyDownTrans;
    private Transform m_trans;
    public static CameraFollow Active;
	void Start () {
        m_trans = this.transform;
        Active = this;
	}
	
    private float smooth = 10f;                // how smooth the camera movement is  
    private Vector3 targetPosition;     // the position the camera is trying to be in  

    public Vector3[] GetCorners()
    {
        Camera camera = Camera.main;
        float distance = Mathf.Abs(camera.transform.position.x - MonkeyDownTrans.position.x);
        //Array.Resize(ref corners, 4);
        Vector3[] corners = new Vector3[4];
        // Top left
        corners[0] = camera.ViewportToWorldPoint(new Vector3(0, 1, distance));
        // Top right
        corners[1] = camera.ViewportToWorldPoint(new Vector3(1, 1, distance));
        // Bottom left
        corners[2] = camera.ViewportToWorldPoint(new Vector3(0, 0, distance));
        // Bottom right
        corners[3] = camera.ViewportToWorldPoint(new Vector3(1, 0, distance));
        return corners;
    }

    private void Test()
    {
        Vector3[] corners = GetCorners();
        //Debug.DrawLine(corners[0],corners[1],Color.yellow);// UpperLeft -> UpperRight
        //Debug.DrawLine(corners[1],corners[3],Color.yellow);// UpperRight -> LowerRight
        //Debug.DrawLine(corners[3],corners[2],Color.yellow);// LowerRight -> LowerLeft
        Debug.DrawLine(corners[2], corners[0], Color.yellow);// LowerLeft -> UpperLeft
    }

    public bool IsVisible(BoxCollider collider)
    {
        Vector3[] corners = GetCorners();
        if (collider.bounds.max.z < corners[0].z) return false;
        else return true;
    }

    void LateUpdate()
    {
        targetPosition = new Vector3(m_trans.position.x, m_trans.position.y, MonkeyDownTrans.position.z);
        m_trans.position = Vector3.Lerp(m_trans.position, targetPosition, Time.deltaTime * smooth);

    }  
}
