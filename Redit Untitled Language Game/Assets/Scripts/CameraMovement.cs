
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField][Range(0.01f,1f)] private float smoothSpeed = 0.125f;
    private Vector3 velocity = Vector3.zero;
    private Camera m_Camera;
    private float cameraSize = 7f;
   // private float refVelocity = 0f;
    private void Start()
    {
      m_Camera = GetComponent<Camera>();
      m_Camera.orthographicSize = cameraSize;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
       
        if (Input.GetAxis ("Mouse ScrollWheel") >0 && m_Camera.orthographicSize <= 12)
        {
            m_Camera.orthographicSize++; 
            //m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize, m_Camera.orthographicSize + 1, ref refVelocity, 0.01f);

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && m_Camera.orthographicSize >= 5)
        {
            m_Camera.orthographicSize--;
          //  m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize, m_Camera.orthographicSize - 1, ref refVelocity, 0.01f);
        }
    }
}
