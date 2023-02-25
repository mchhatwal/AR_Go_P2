using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TrackUserTapLandmark : MonoBehaviour
{
    [SerializeField] GameObject LandmarkDetailPanel;
    [SerializeField] TextMeshProUGUI title_text, description_text;
    [SerializeField] Image image;

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
            if (LandmarkDetailPanel.activeSelf)
            {
                LandmarkDetailPanel.SetActive(false);
                return;
            }
            //create a ray cast and set it to the mouses cursor position in game
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit t;
            if (Physics.Raycast(ray, out t))
            {
                IsLandmark landmark = t.transform.gameObject.GetComponent<IsLandmark>();
                Debug.Log(landmark == null ? null : landmark.name);
                if (landmark != null)
                {
                    LandmarkDetailPanel.SetActive(true);
                    UserInventory.instance.IsTreeUnLocked[landmark.UnlockIndex] = true;
                    image.sprite = landmark.image;
                    title_text.text = landmark.name;
                    description_text.text = landmark.description;
                }

            }
        }
    }
}
