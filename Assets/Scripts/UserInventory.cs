using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UserInventory : MonoBehaviour
{
    // Start is called before the first frame update
    public static UserInventory instance;
    public int acorn_count, acorn_price;
    public List<int> tree_count;
    [SerializeField] GameObject SeedShopPanel;
    public List<int> tree_price;
    [SerializeField] List<TextMeshProUGUI> tree_price_displayer;
    public List<bool> IsTreeUnLocked;
    public TextMeshProUGUI acorn_displayer;
    void Start()
    {
        if(instance == null) instance = this;
        SeedShopPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!SeedShopPanel.activeSelf) return;

        for(int i = 0; i < tree_price_displayer.Count; i++)
        {
            if(!IsTreeUnLocked[i]) tree_price_displayer[i].text = "LOCKED";
            else tree_price_displayer[i].text = "$ " + tree_price[i];
        }
        acorn_displayer.text = "$ " + acorn_price;
    }

    public void PurchaseSeed(string str)
    {
        if(str == "acorn")
        {
            if (UpdateCurrency.currency >= acorn_price)
            {
                UpdateCurrency.currency -= acorn_price;
                acorn_count++;
            }
        }
        else
        {
            int index = int.Parse(str);

            if(UpdateCurrency.currency >= tree_price[index] && IsTreeUnLocked[index])
            {
                UpdateCurrency.currency -= tree_price[index];
                tree_count[index]++;
            }
        }

    }

    public void OpenSeedShop() {
        if (!SeedShopPanel.activeSelf)
            SeedShopPanel.SetActive(true);
        else SeedShopPanel.SetActive(false);
    }
}
