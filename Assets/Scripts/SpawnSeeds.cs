using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSeeds : MonoBehaviour
{
    public List<GameObject> TreesToSpawn;
    public Transform cursor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(string str)
    {
        int index = int.Parse(str);
        GameObject obj = Instantiate(TreesToSpawn[index]);
        obj.transform.SetPositionAndRotation(cursor.position, cursor.rotation);
        //sfx

        //spawn in exploration ?
    }
}
