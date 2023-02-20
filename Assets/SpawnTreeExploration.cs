using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTreeExploration : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        int index = myseeds.tree.Count;
        int pos_index = myseeds.pos.Count;
        while (pos_index < index)
        {
            pos_index++;
            GameObject player = gameObject;
            Vector3 randomvec = new Vector3(Random.Range(0, 1),  0, Random.Range(0, 1));
            myseeds.pos.Add(player.transform.position + randomvec);
        }

        for (int i = 0; i < myseeds.tree.Count; i++)
        {
            GameObject obj = Instantiate(myseeds.tree[i]);
            Debug.Log(obj);
            obj.transform.position = myseeds.pos[i];
            obj.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
