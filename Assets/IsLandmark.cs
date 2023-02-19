using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Utils;
using Mapbox.Unity.Map;

public class IsLandmark : MonoBehaviour
{
    [SerializeField] AbstractMap map;
    [SerializeField] Vector2d world_position;
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
