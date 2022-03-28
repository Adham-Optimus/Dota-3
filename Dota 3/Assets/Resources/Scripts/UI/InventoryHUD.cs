using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHUD : MonoBehaviour
{
    public PlayerScript player;
    public Image[] slots;
    public int[] items;

    void Start()
    {
        items = new int[12];
        slots = new Image[12];
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = transform.GetChild(i).GetComponent<Image>();
        }
    }
    
    public void SellButton(GameObject gameObj)
    {
        Item item = gameObj.GetComponentInParent<Item>();
        player.moneys += item.cost / 2;
        item.GetComponent<Image>().sprite = null;
        item.s_item.SellItem();
        gameObj.SetActive(false);
    }

    public void DeleteItem(int index)
    {
        foreach (int i in items)
        {
            if (items[i] == index) { items[i] = 0; return; }
        }
    }
    

}
