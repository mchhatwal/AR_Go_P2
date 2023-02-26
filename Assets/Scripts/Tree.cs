using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Tree : MonoBehaviour
{
    // Start is called before the first frame update
    public float origin_scale, grown_scale;
    public int reward;
    public int id;
    int last_frame_count = 0;
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
        if(IsInteractionMode && Time.frameCount - last_frame_count >= 200 && transform.localScale.x < grown_scale)
        {
            last_frame_count = Time.frameCount;
            transform.localScale += Vector3.one * (grown_scale - origin_scale) / 15;

            if (transform.localScale.x >= grown_scale) UpdateCurrency.currency += reward;
        }

    }
}