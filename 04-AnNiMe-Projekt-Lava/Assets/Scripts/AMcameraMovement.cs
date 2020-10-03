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
    public bool smoothFollow = true;
    public float smooth = 0.05f;

    [HideInInspector]
    public float newDistance = -8; //set by zoom input
    [HideInInspector]
    public float adujstmentDistance = -8;

    public float xRotation = -20;
    public float yRotation = -180;
    public float maxXRotation = 25;
    public float minXRotation = -85;
    public float vOrbitSmooth = 150;
    public float hOrbitSmooth = 150;
    
    private string ORBIT_HORIZONTAL_SNAP = "OrbitHorizontalSnap";
    private string ORBIT_HORIZONTAL = "OrbitHorizontal";                        // Kann auch auf Mouse X umgestellt werden oder OrbitHorizontal
    private string ORBIT_VERTICAL = "OrbitVertical";                            // Kann auch auf Mouse Y umgestellt werden oder OrbitVertical
    private string ZOOM = "Mouse ScrollWheel";

    [System.Serializable]
    public class DebugSettings
    {
        public bool drawDesiredCollisionLines = true;
        public bool drawAdjustedCollisionLines = true;
    }

    public DebugSettings debug = new DebugSettings();
    public CollisionHandlder collision = new CollisionHandlder();

    Vector3 targetPos = Vector3.zero;
    Vector3 destination = Vector3.zero;
    Vector3 adjustedDestionation = Vector3.zero;    //NEW
    Vector3 camVel = Vector3.zero;                  //NEW
    //AMcharacterMovement charController;
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

        MoveToTarget();

        collision.Initialize(Camera.main);
        collision.UpdateCameraClipPoints(transform.position, transform.rotation, ref collision.adjustedCameraClipPoints);
        collision.UpdateCameraClipPoints(destination, transform.rotation, ref collision.desiredCameraClipPoints);

    }

    void SetCameraTarget(Transform t)
    {
        target = t;

        //if (target != null)
        //{
        //    if (target.GetComponent<AMcharacterMovement>())
        //    {
        //        charController = target.GetComponent<AMcharacterMovement>();
        //    } else
        //    {
        //        Debug.LogError("The camera's target needs a character controller");
        //    }
        //} else
        //{
        //    Debug.LogError("Your camera needs a target.");
        //}
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
    void FixedUpdate()
    {
        //movint
        MoveToTarget();
        //rotating
        LookAtTarget();

        collision.UpdateCameraClipPoints(transform.position, transform.rotation, ref collision.adjustedCameraClipPoints);
        collision.UpdateCameraClipPoints(destination, transform.rotation, ref collision.desiredCameraClipPoints);

        //draw debug lines
        for(int i = 0; i < 5; i++)
        {
            if (debug.drawDesiredCollisionLines)
            {
                Debug.DrawLine(targetPos, collision.desiredCameraClipPoints[i], Color.white);
            }
            if (debug.drawAdjustedCollisionLines)
            {
                Debug.DrawLine(targetPos, collision.adjustedCameraClipPoints[i], Color.green);
            }
        }

        collision.CheckColliding(targetPos); //using raycasts here
        adujstmentDistance = collision.GetAdjustedDistanceWithRayFrom(targetPos);
    }

    void MoveToTarget()
    {
        targetPos = target.position + targetPosOffset;
        destination = Quaternion.Euler(xRotation, yRotation + target.eulerAngles.y, 0) * -Vector3.forward * distanceFromTarget;
        destination += targetPos; 
        //transform.position = destination;

        if (collision.colliding)
        {
            adjustedDestionation = Quaternion.Euler(xRotation, yRotation + target.eulerAngles.y, 0) * Vector3.forward * adujstmentDistance;
            adjustedDestionation += targetPos;

            if (smoothFollow)
            {
                //use smooth damp function
                transform.position = Vector3.SmoothDamp(transform.position, adjustedDestionation, ref camVel, smooth);
            }
            else
            {
                transform.position = adjustedDestionation;
            }
        }
        else
        {
            if (smoothFollow)
            {
                //use smooth damp function
                transform.position = Vector3.SmoothDamp(transform.position, destination, ref camVel, smooth);
            }
            else
            {
                transform.position = destination;
            }
        }
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

    [System.Serializable]
    public class CollisionHandlder
    {
        public LayerMask collisionLayer;

        [HideInInspector]
        public bool colliding = false;
        [HideInInspector]
        public Vector3[] adjustedCameraClipPoints;
        [HideInInspector]
        public Vector3[] desiredCameraClipPoints;

        Camera camera;

        public void Initialize(Camera cam)
        {
            camera = cam;
            adjustedCameraClipPoints = new Vector3[5];
            desiredCameraClipPoints = new Vector3[5];
        }

        public void UpdateCameraClipPoints(Vector3 cameraPosition, Quaternion atRotation, ref Vector3[] intoArray)
        {
            if (!camera)
                return;

            //clear the contents of intoArray
            intoArray = new Vector3[5];

            float z = camera.nearClipPlane;
            float x = Mathf.Tan(camera.fieldOfView / 3.41f);        //kann man etwas verändern
            float y = x / camera.aspect;

            //top left
            intoArray[0] = (atRotation * new Vector3(-x, y, z)) + cameraPosition;    //added and rotated the point relative to camera
            //top right
            intoArray[1] = (atRotation * new Vector3(x, y, z)) + cameraPosition;    //added and rotated the point relative to camera
            //bottom left
            intoArray[2] = (atRotation * new Vector3(-x, -y, z)) + cameraPosition;    //added and rotated the point relative to camera
            //bottom right
            intoArray[3] = (atRotation * new Vector3(x, -y, z)) + cameraPosition;    //added and rotated the point relative to camera
            //cameras position
            intoArray[4] = cameraPosition - camera.transform.forward;
        }

        bool CollisionDetectedAtClipPoints(Vector3[] clipPoints, Vector3 fromPosition)
        {
            for (int i = 0; i < clipPoints.Length; i++)
            {
                Ray ray = new Ray(fromPosition, clipPoints[i] - fromPosition);
                float distance = Vector3.Distance(clipPoints[i], fromPosition);
                if(Physics.Raycast(ray, distance, collisionLayer))
                {
                    return true;
                }
            }

            return false;
        }

        public float GetAdjustedDistanceWithRayFrom(Vector3 from)
        {
            float distance = -1;

            for(int i = 0; i < desiredCameraClipPoints.Length; i++)
            {
                Ray ray = new Ray(from, desiredCameraClipPoints[i] - from);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    if (distance == -1)
                        distance = hit.distance;
                    else
                        if (hit.distance < distance)
                            distance = hit.distance;
                }
            }

            if (distance == -1)
                return 0;
            else
                return distance;
        }

        public void CheckColliding(Vector3 targetPosition)
        {
            if (CollisionDetectedAtClipPoints(desiredCameraClipPoints, targetPosition))
            {
                colliding = true;
            }
            else
            {
                colliding = false;
            }
        }
    }
}
