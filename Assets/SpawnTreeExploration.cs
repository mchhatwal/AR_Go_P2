using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTreeExploration : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        Seeds myseeds = Seeds.instance;
        int index = myseeds.tree.Count;
        Debug.Log("TreeList count: " + index);
        for(int i = 0; i < index; i++)
        {
            GameObject player = gameObject;
            Vector3 randomvec = new Vector3(Random.Range(2f, 8f),  0, -Random.Range(2f, 8f));
            GameObject new_tree = Instantiate(myseeds.tree[i]);
            if (new_tree.name.Contains("Mushroom"))
                new_tree.transform.localScale = Vector3.one * 10f;
            else new_tree.transform.localScale = Vector3.one;
            new_tree.transform.position = randomvec + player.transform.position;
            Debug.Log(new_tree.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
