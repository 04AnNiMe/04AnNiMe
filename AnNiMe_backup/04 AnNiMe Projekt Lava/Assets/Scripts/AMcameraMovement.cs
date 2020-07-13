using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AMcameraMovement : MonoBehaviour
{
    public Transform target;
    /*public float lookSmooth = 0.03f;
    //public Vector3 offsetFromTarget = new Vector3(0, 6, -8);
    public float xRotation;
    public float yRotation;
    //public float xTilt = 10;
    */

    [System.Serializable]
    public class PositionSettings
    {
        public Vector3 targetPosOffset = new Vector3(0, 3.4f, 0);
        public float lookSmooth = 100f;
        public float distanceFromTarget = -8;
        public float zoomSmooth = 100;
        public float maxZoom = -2;
        public float minZoom = -15;
    }

    [System.Serializable]
    public class OrbitSettings
    {
        public float xRotation = -20;
        public float yRotation = -180;
        public float maxXRotation = 25;
        public float minXRotation = -85;
        public float vOrbitSmooth = 150;
        public float hOrbitSmooth = 150;
    }

    [System.Serializable]
    public class InputSettings
    {
        public string ORBIT_HORIZONTAL_SNAP = "OrbitHorizontalSnap";
        public string ORBIT_HORIZONTAL = "OrbitHorizontal";             //Kann auch auf Mouse X umgestellt werden oder OrbitHorizontal
        public string ORBIT_VERTICAL = "OrbitVertical";                 //Kann auch auf Mouse Y umgestellt werden oder OrbitVertical
        public string ZOOM = "Mouse ScrollWheel";
    }

    public PositionSettings position = new PositionSettings();
    public OrbitSettings orbit = new OrbitSettings();
    public InputSettings input = new InputSettings();

    Vector3 targetPos = Vector3.zero;
    Vector3 destination = Vector3.zero;
    AMcharacterMovement charController;
    float vOrbitInput, hOrbitInput, zoomInput, hOrbitSnapInput;
    //float rotateVel = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetCameraTarget(target);

        targetPos = target.position + position.targetPosOffset;
        destination = Quaternion.Euler(orbit.xRotation, orbit.yRotation, 0) * -Vector3.forward * position.distanceFromTarget;
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
        vOrbitInput = Input.GetAxisRaw(input.ORBIT_VERTICAL);
        hOrbitInput = Input.GetAxisRaw(input.ORBIT_HORIZONTAL);
        hOrbitSnapInput = Input.GetAxisRaw(input.ORBIT_HORIZONTAL_SNAP);
        zoomInput = Input.GetAxisRaw(input.ZOOM);
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
        targetPos = target.position + position.targetPosOffset;
        destination = Quaternion.Euler(orbit.xRotation, orbit.yRotation + target.eulerAngles.y, 0) * -Vector3.forward * position.distanceFromTarget;
        //destination = charController.TargetRotation * offsetFromTarget;         //testen
        destination += targetPos; 
        transform.position = destination;
    }

    void LookAtTarget()
    {
        Quaternion targetRotation = Quaternion.LookRotation(targetPos - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, position.lookSmooth * Time.deltaTime);

        /*float eulerYAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerYAngle, 0);*/
    }

    void OrbitTarget()
    {
        if( hOrbitSnapInput > 0)
        {
            orbit.yRotation = -180;
        }

        orbit.xRotation += -vOrbitInput * orbit.vOrbitSmooth * Time.deltaTime;
        orbit.yRotation += -hOrbitInput * orbit.hOrbitSmooth * Time.deltaTime;

        if (orbit.xRotation > orbit.maxXRotation)
        {
            orbit.xRotation = orbit.maxXRotation;
        }
        if (orbit.xRotation < orbit.minXRotation)
        {
            orbit.xRotation = orbit.minXRotation;
        }
    }

    void ZoomInOnTarget()
    {
        position.distanceFromTarget += zoomInput * position.zoomSmooth * Time.deltaTime;

        if (position.distanceFromTarget > position.maxZoom)
        {
            position.distanceFromTarget = position.maxZoom;
        }
        if (position.distanceFromTarget < position.minZoom)
        {
            position.distanceFromTarget = position.minZoom;
        }
    }
}
