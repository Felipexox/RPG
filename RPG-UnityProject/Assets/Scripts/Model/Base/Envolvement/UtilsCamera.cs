using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilsCamera : MonoBehaviour {
    protected float minX = -360.0f;
    protected float maxX = 360.0f;

    protected float minY = -45.0f;
    protected float maxY = 4.0f;

    protected float sensX = 100.0f;
    protected float sensY = 100.0f;

    protected float rotationY = 0.0f;
    protected float rotationX = 0.0f;
    [Range(35, 65)]
    [SerializeField]
    protected float fildCamera = 60f;
    protected Transform mainCamera;
    [Header("Caracteristica")]

    [Range(0,10)]
    [SerializeField]
    protected float smooth;

    [SerializeField]
    protected Transform target;

    protected bool isPause;

    public void pauseCamera()
    {
        isPause = true;
    }

    public void resumeCamera()
    {
        isPause = false;
    }

    protected void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        mainCamera = Camera.main.transform;
    }
  
    protected void FixedUpdate()
    {
        if (!isPause)
        {
            cameraZoom();
            rotateAround();
            followTarget();
        }
    }
    protected void rotateAround()
    {
        rotationX += Input.GetAxis("Mouse X") * sensX * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse Y") * sensY * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, minY, maxY);
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
    protected void followTarget()
    {
          transform.position = Vector3.Lerp(transform.position, target.position, 5f);

    }
    
    public Vector3 getDir()
    {
        Vector3 dir = target.position - mainCamera.position;
        dir.y = 0;
        return dir;
    }
    public void cameraZoom()
    {
        fildCamera += Input.GetAxis("Mouse ScrollWheel") * sensX * Time.deltaTime * 10;
        fildCamera = Mathf.Clamp(fildCamera, 35, 65);
        Camera.main.fieldOfView = fildCamera ;
    }

}
