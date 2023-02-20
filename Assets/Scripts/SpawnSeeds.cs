using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSeeds : MonoBehaviour
{
    public List<GameObject> TreesToSpawn;
    public Transform cursor;
    public AudioClip sfx;
    // Start is called before the first frame update
    void Start()
    {
        myseeds.tree = new List<GameObject>();
        myseeds.pos = new List<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(string str)
    {
        int index = int.Parse(str);
        // get cursor
        if (GameObject.Find("ar_cursor") != null)
        {

            GameObject obj = Instantiate(TreesToSpawn[index]);
            cursor = GameObject.Find("ar_cursor").transform;

            obj.transform.SetPositionAndRotation(cursor.position, cursor.rotation);


            AudioSource.PlayClipAtPoint(sfx, cursor.position);
            //sfx
        }



        //spawn in exploration ?
        myseeds.tree.Add(TreesToSpawn[index]);

    }
}

public static class myseeds{
    public static List<GameObject> tree;
    public static List<Vector2> pos;
}
