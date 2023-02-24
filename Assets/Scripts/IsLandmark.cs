using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Utils;
using Mapbox.Unity.Map;
using UnityEngine.UI;

public class IsLandmark : MonoBehaviour
{
    [SerializeField] AbstractMap map;
    [SerializeField] Vector2d world_position;
    public string name;
    public Sprite image;
    public string description;
    // Start is called before the first frame update
    void Start() 
    {
 

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = map.GeoToWorldPosition(world_position);
    }
}
