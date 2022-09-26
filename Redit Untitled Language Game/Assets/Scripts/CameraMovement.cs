
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform target;
    [SerializeField] private Transform robot;
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField][Range(0.01f,1f)] private float smoothSpeed = 0.125f;
    private Vector3 velocity = Vector3.zero;
    private Camera m_Camera;
    public float cameraSize =18f;
    private GameController gameController;
   // private float refVelocity = 0f;
    private void Start()
    {
      m_Camera = GetComponent<Camera>();
      m_Camera.orthographicSize = cameraSize;
        robot = GameObject.FindGameObjectWithTag("Robot").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        target = player; 
    }
    // Update is called once per frame
    void LateUpdate()
    {   
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
       
        if (Input.GetAxis ("Mouse ScrollWheel") <0 && m_Camera.orthographicSize <= 45)
        {
            m_Camera.orthographicSize++; 
            //m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize, m_Camera.orthographicSize + 1, ref refVelocity, 0.01f);

        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && m_Camera.orthographicSize >= 8f)
        {
            m_Camera.orthographicSize--;
          //  m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize, m_Camera.orthographicSize - 1, ref refVelocity, 0.01f);
        }
    }
    void Update()
    { // this is awful change this to something that isn't called every frame
        if (gameController.scanning)
        {
            target = robot;

        }
        else if (!gameController.scanning) 
        {
            target = player;
        }
    
    }
}
