using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
public class Tree : MonoBehaviour
{
    // Start is called before the first frame update
    public float origin_scale, grown_scale;
    public int reward;
    public int id;
    float timer = 0;
    bool IsInteractionMode;

    void Start()
    {
        IsInteractionMode = SceneManager.GetActiveScene().name != "exploration_scene";
        if(IsInteractionMode)
            transform.localScale = Vector3.one * origin_scale;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(IsInteractionMode && timer >= 2f && transform.localScale.x < grown_scale)
        {
            timer -= 2f;
            transform.localScale += Vector3.one * (grown_scale - origin_scale) / 15;

            if (transform.localScale.x >= grown_scale)
            {
                if (Seeds.instance.tree[id].SquirrelAround) UpdateCurrency.currency += reward / 2;
                else UpdateCurrency.currency += reward;

            }
        }

        if (transform.position.Equals(new Vector3(0, -1, 2)) && IsInteractionMode)
        {
            ARRaycastManager m_RaycastManager = ARSpawnTree.m_RaycastManager;
            List<ARRaycastHit> m_Hits = new List<ARRaycastHit>();
            if (m_RaycastManager.Raycast(new Ray(new Vector3(0, -1, 10), new Vector3(0, 0, -1)), m_Hits))
                transform.position = m_Hits[0].pose.position;
        }

    }
}
