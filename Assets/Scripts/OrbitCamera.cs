using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target; // The player character that the camera orbits around
    public float distance = 10.0f; // The distance between the camera and the player character
    public float sensitivity = 5.0f; // The sensitivity of the mouse when dragging to orbit the camera
    public Vector3 offset; 
    private float x = 0.0f; // The current x rotation of the camera
    private float y = 0.0f; // The current y rotation of the camera

    void Start()
    {
        transform.position = target.position + offset;
        transform.LookAt(target.position);
    }

    void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            // Get the mouse input and update the camera rotation
            x += Input.GetAxis("Mouse X") * sensitivity;
            y -= Input.GetAxis("Mouse Y") * sensitivity;
        }

        // Clamp the y rotation to prevent the camera from flipping upside down
        y = Mathf.Clamp(y, -90.0f, 90.0f);

        // Set the camera position and rotation
        Quaternion rotation = Quaternion.Euler(y, x, 0);
        Vector3 position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position + offset;
        transform.rotation = rotation;
        transform.position = position;
    }
    //public Transform player_avatar;
    //private Transform pivotParent;
    //// private Transform cameraCurr;
    //public Vector3 offset;
    //private Vector3 local_rotation;
    ////private float new_x;
    ////private float new_y;
    ////private Vector3 previousPosition;
    ////private float newX;
    ////private float newY;
    ////private float newZ;
    //// Update is called once per frame
    //[SerializeField] private Camera cam;
    //[SerializeField] private float distanceToTarget = 10;

    //void Start()
    //{
    //    // this.cameraCurr = this.transform; 
    //    transform.position = player_avatar.position + offset;
    //    transform.LookAt(player_avatar.position);
    //    this.pivotParent = this.transform.parent; 
    //}

    //private void LateUpdate()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
    //        {
    //            local_rotation.x += Input.GetAxis("Mouse X") * 4f;
    //            local_rotation.y -= Input.GetAxis("Mouse Y") * 4f;
    //            local_rotation.y = Mathf.Clamp(local_rotation.y, 0f, 90f);
    //        }
    //    }
    //    else if (Input.GetMouseButtonDown(0))
    //    {
    //        if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
    //        {
    //            local_rotation.x += Input.GetAxis("Mouse X") * 4f;
    //            local_rotation.y -= Input.GetAxis("Mouse Y") * 4f;
    //            local_rotation.y = Mathf.Clamp(local_rotation.y, 0f, 90f);
    //        }
    //    }
    //    else
    //    {
    //        transform.position = player_avatar.position + offset;
    //        pivotParent.position = player_avatar.position + offset;
    //    }

    //    Quaternion QT = Quaternion.Euler(local_rotation.y, local_rotation.x, 0);
    //    pivotParent.rotation = Quaternion.Lerp(pivotParent.rotation, QT, Time.deltaTime * 10f);
    //    //transform.LookAt(player_avatar.position); 
    //}
}






    //void Update()
    //{
    //    //transform.LookAt(player_avatar.position);

    //    if (Input.GetMouseButton(0))
    //    {
    //        transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * 4.0f, -Input.GetAxis("Mouse X") * 4.0f, 0));
    //        new_x = transform.rotation.eulerAngles.x;
    //        new_y = transform.rotation.eulerAngles.y;
    //        transform.rotation = Quaternion.Euler(new_x, new_y, 0);
    //        // float x_tilt = Input.GetAxis("Mouse X"); 
    //        // float y_tilt = Input.GetAxis("Mouse Y"); 

    //        // float new_x = Mathf.Cos(x_tilt); 
    //        // float new_z = Mathf.Sin(x_tilt); 
    //        // float new_y = y_tilt; 

    //        // transform.rotation = Quaternion.Euler(new Vector3(0,Input.GetAxis("Mouse X"),0)); 
    //        // transform.Translate(Vector3.right * Time.deltaTime);
    //    }
    //    else
    //    {
    //        transform.position = player_avatar.position + offset;
    //    }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        //}
        //if (Input.GetMouseButton(0))
        //{
        //    //Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        //    //Vector3 direction = previousPosition - newPosition;

        //    //float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
        //    //float rotationAroundXAxis = direction.y * 180; // camera moves vertically

        //    //cam.transform.position = player_avatar.position + offset;

        //    //cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
        //    //cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!

        //    //cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));

        //    //previousPosition = newPosition;
        //    if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
        //    {
        //        transform.position += new Vector3(Mathf.Cos(Input.GetAxis("Mouse X")), 0, Mathf.Sin(Input.GetAxis("Mouse X")));
        //        transform.position -= new Vector3(0, Input.GetAxis("Mouse Y"), 0);
        //    }
        //    //else
        //    //{
        //    //    
        //    //}
        //}
        //else
        //{
        //    transform.position = player_avatar.position + offset;
        //}
