using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnSeeds : MonoBehaviour
{
    public static SpawnSeeds instance;
    public List<GameObject> TreesToSpawn;
    public Transform cursor;
    public AudioClip sfx;
    [SerializeField] List<TextMeshProUGUI> tree_count_displayer;
    [SerializeField] TextMeshProUGUI acorn_count_displayer;
    [SerializeField] TextMeshProUGUI choco_count_displayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < tree_count_displayer.Count; i++)
        {
            tree_count_displayer[i].text = "" + UserInventory.instance.tree_count[i];
        }

        // Debug.Log(UserInventory.instance.tree_count[0]);
        acorn_count_displayer.text = "" + UserInventory.instance.acorn_count;
    }

    public void Spawn(string str)
    {
        int index = int.Parse(str);
        // get cursor
        // check if not enough seeds
        if(UserInventory.instance.tree_count[index] == 0)
        {
            return;
        }

        TreeInstance new_tree = new TreeInstance(id:Seeds.instance.tree.Count);
        Seeds.instance.tree.Add(new_tree);

        if (GameObject.Find("ar_cursor") != null)
        {

            GameObject obj = Instantiate(TreesToSpawn[index]);
            cursor = GameObject.Find("ar_cursor").transform;

            obj.transform.SetPositionAndRotation(cursor.position, cursor.rotation);


            AudioSource.PlayClipAtPoint(sfx, cursor.position);
            new_tree.Obj = obj;
            new_tree.scale = obj.GetComponent<Tree>().origin_scale;
            new_tree.grown_scale = obj.GetComponent<Tree>().grown_scale;


            //sfx
        }

        new_tree.WorldLocation = Seeds.User_location;
        new_tree.TreeType = TreesToSpawn[index];

        //spawn in exploration ?

        Debug.Log("Tree Spawn " + Seeds.instance.tree.Count);
        UserInventory.instance.tree_count[index] -= 1;
        int tree_index = Seeds.instance.tree.Count - 1;
       // Seeds.instance.tree[tree_index].GetComponent<>

    }
}


