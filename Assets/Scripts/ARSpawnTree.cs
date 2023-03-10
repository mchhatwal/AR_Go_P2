using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARSpawnTree : MonoBehaviour
{
    public static TreeInstance show_tree;
    [SerializeField] GameObject squirrel_prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        if (show_tree == null) return;
        Debug.Log("show tree = " + show_tree.id);
        if (show_tree != null)
        {
            GameObject new_tree = Instantiate(show_tree.TreeType);
            new_tree.transform.localScale = Vector3.one * show_tree.scale;
            new_tree.transform.position = new Vector3(0, -1, 2);
            Debug.Log("new tree " + new_tree.transform.position);
            if (show_tree.SquirrelAround)
            {
                GameObject squ = Instantiate(squirrel_prefab);
                squ.GetComponent<IsSquirrel>().IsInteractiveMode = true;
                squ.transform.position = new Vector3(0, -1.5f, 1.9f);
                squ.transform.Rotate(new Vector3(0, 90, 0));
            }
        }
    }
}
