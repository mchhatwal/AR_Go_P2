using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Utils;
using Mapbox.Unity.Map;
public class SpawnTreeExploration : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AbstractMap map;
    [SerializeField] GameObject squirrel_prefab;
    void Start()
    {
        Seeds myseeds = Seeds.instance;
        int index = myseeds.tree.Count;
        Debug.Log("TreeList count: " + index);
        for(int i = 0; i < index; i++)
        {
            // GameObject player = gameObject;
            Vector3 randomvec = new Vector3(Random.Range(2f, 4f),  0, -Random.Range(2f, 4f));

            TreeInstance new_tree = myseeds.tree[i];
            if (new_tree.TreeType.name.Contains("Mushroom"))
                new_tree.exploration_scale = 10f;
            else new_tree.exploration_scale = 1;

            GameObject tree_obj = Instantiate(new_tree.TreeType);
            new_tree.Obj = tree_obj;
            tree_obj.transform.localScale = Vector3.one * new_tree.exploration_scale;
            Debug.Log(tree_obj.transform.localScale);
            tree_obj.transform.position = randomvec + map.GeoToWorldPosition(new_tree.WorldLocation);

            float rand =  Random.Range(0f, 1f);
            if (rand <= 0.5f)
            {
                new_tree.SquirrelAround = true;
                GameObject squ = Instantiate(squirrel_prefab);
                squ.GetComponent<IsSquirrel>().IsInteractiveMode = false;
                //Debug.Log(tree_obj.transform.position);
                squ.transform.position = tree_obj.transform.position + new Vector3(Random.Range(1f, 2f), 0, -Random.Range(1f, 2f));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
