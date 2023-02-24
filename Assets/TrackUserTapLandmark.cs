using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackUserTapLandmark : MonoBehaviour
{
    [SerializeField] GameObject LandmarkDetailPanel;

    // Start is called before the first frame update
    void Start()
    {
        LandmarkDetailPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if mouse button (left hand side) pressed instantiate a raycast
        if (Input.GetMouseButtonDown(0))
        {
            //create a ray cast and set it to the mouses cursor position in game
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit t;
            if (Physics.Raycast(ray, out t))
            {
                IsLandmark landmark = t.transform.gameObject.GetComponent<IsLandmark>();
                if (landmark != null)
                {
                    LandmarkDetailPanel.SetActive(true);
                }

            }
        }
    }
}
