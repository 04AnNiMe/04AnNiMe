using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMcameraMovement : MonoBehaviour
{
    public Transform target;
        
    public Vector3 targetPosOffset = new Vector3(0, 3.4f, 0);
    public float lookSmooth = 100f;
    public float distanceFromTarget = -8;
    public float zoomSmooth = 100;
    public float maxZoom = -2;
    public float minZoom = -15;
    
    public float xRotation = -20;
    public float yRotation = -180;
    public float maxXRotation = 25;
    public float minXRotation = -85;
    public float vOrbitSmooth = 150;
    public float hOrbitSmooth = 150;
    
    private string ORBIT_HORIZONTAL_SNAP = "OrbitHorizontalSnap";
    private string ORBIT_HORIZONTAL = "OrbitHorizontal";                        //Kann auch auf Mouse X umgestellt werden oder OrbitHorizontal
    private string ORBIT_VERTICAL = "OrbitVertical";                          //Kann auch auf Mouse Y umgestellt werden oder OrbitVertical
    private string ZOOM = "Mouse ScrollWheel";

    Vector3 targetPos = Vector3.zero;
    Vector3 destination = Vector3.zero;
    AMcharacterMovement charController;
    float vOrbitInput;
    float hOrbitInput;
    float zoomInput;
    float hOrbitSnapInput;
    //float rotateVel = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetCameraTarget(target);

        targetPos = target.position + targetPosOffset;
        destination = Quaternion.Euler(xRotation, yRotation, 0) * -Vector3.forward * distanceFromTarget;
        destination += targetPos;
        transform.position = destination;
    }

    void SetCameraTarget(Transform t)
    {
        target = t;

        if (target != null)
        {
            if (target.GetComponent<AMcharacterMovement>())
            {
                charController = target.GetComponent<AMcharacterMovement>();
            } else
            {
                Debug.LogError("The camera's target needs a character controller");
            }
        } else
        {
            Debug.LogError("Your camera needs a target.");
        }
    }

    void GetInput()
    {
        vOrbitInput = Input.GetAxisRaw(ORBIT_VERTICAL);
        hOrbitInput = Input.GetAxisRaw(ORBIT_HORIZONTAL);
        hOrbitSnapInput = Input.GetAxisRaw(ORBIT_HORIZONTAL_SNAP);
        zoomInput = Input.GetAxisRaw(ZOOM);
    }

    void Update()
    {
        GetInput();
        OrbitTarget();
        ZoomInOnTarget();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //movint
        MoveToTarget();
        //rotating
        LookAtTarget();
    }

    void MoveToTarget()
    {
        targetPos = target.position + targetPosOffset;
        destination = Quaternion.Euler(xRotation, yRotation + target.eulerAngles.y, 0) * -Vector3.forward * distanceFromTarget;
        destination += targetPos; 
        transform.position = destination;
    }

    void LookAtTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetPos - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, lookSmooth * Time.deltaTime);

    }

    void OrbitTarget()
    {
        if( hOrbitSnapInput > 0)
        {
            yRotation = -180;
        }

        xRotation += -vOrbitInput * vOrbitSmooth * Time.deltaTime;
        yRotation += -hOrbitInput * hOrbitSmooth * Time.deltaTime;

        if (xRotation > maxXRotation)
        {
            xRotation = maxXRotation;
        }
        if (xRotation < minXRotation)
        {
            xRotation = minXRotation;
        }
    }

    void ZoomInOnTarget()
    {
        distanceFromTarget += zoomInput * zoomSmooth * Time.deltaTime;

        if (distanceFromTarget > maxZoom)
        {
            distanceFromTarget = maxZoom;
        }
        if (distanceFromTarget < minZoom)
        {
            distanceFromTarget = minZoom;
        }
    }
}
