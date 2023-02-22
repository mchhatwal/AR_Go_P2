using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform player_avatar; 
    public Vector3 offset; 
    private float new_x;
    private float new_y; 

    void Start()
    { 
        transform.position = player_avatar.position + offset;  
        transform.LookAt(player_avatar.position);
    }

    // Update is called once per frame
    [SerializeField] private Camera cam;
    [SerializeField] private float distanceToTarget = 10;
    
    private Vector3 previousPosition;

    void Update()
    {
        // transform.LookAt(player_avatar.position);

        // if (Input.GetMouseButton(0)) 
        // { 
        //     transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * 4.0f, -Input.GetAxis("Mouse X") * 4.0f, 0)); 
        //     new_x = transform.rotation.eulerAngles.x; 
        //     new_y = transform.rotation.eulerAngles.y; 
        //     transform.rotation = Quaternion.Euler(new_x, new_y, 0); 
        //     // float x_tilt = Input.GetAxis("Mouse X"); 
        //     // float y_tilt = Input.GetAxis("Mouse Y"); 

        //     // float new_x = Mathf.Cos(x_tilt); 
        //     // float new_z = Mathf.Sin(x_tilt); 
        //     // float new_y = y_tilt; 

        //     // transform.rotation = Quaternion.Euler(new Vector3(0,Input.GetAxis("Mouse X"),0)); 
        //     // transform.Translate(Vector3.right * Time.deltaTime);
        // }
        // else { 
        //     transform.position = player_avatar.position + offset;  
        // }

        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = previousPosition - newPosition;
            
            float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
            float rotationAroundXAxis = direction.y * 180; // camera moves vertically
            
            cam.transform.position = player_avatar.position + offset;
            
            cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
            cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!
            
            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));
            
            previousPosition = newPosition;
        }
        // else { 
        //     transform.position = player_avatar.position + offset;  
        // }
    }
}
