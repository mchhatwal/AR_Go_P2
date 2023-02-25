using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Utils;
public class Seeds : MonoBehaviour
{
    public static Seeds instance;
    public List<TreeInstance> tree;
    public static Vector2d User_location;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        tree = new List<TreeInstance>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


}

public class TreeInstance
{
    public GameObject Obj;
    public GameObject TreeType;
    public float scale, grown_scale, exploration_scale;
    public Vector2d WorldLocation;
    public int id;

    public TreeInstance(int id, float origin_scale = .3f, float grown_scale = 1f)
    {
        this.scale = origin_scale;
        this.grown_scale = grown_scale;
        this.id = id;
    }
}
