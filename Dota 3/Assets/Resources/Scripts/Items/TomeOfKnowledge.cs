using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomeOfKnowledge : MonoBehaviour, ISellable, IPressable
{
    private Item item;
    PlayerScript player;
    private void Start()
    {
        player = GetComponentInParent<InventoryHUD>().player;
        item = GetComponent<Item>();
        item.SellInstaller(this);
        item.ActiveInstaller(this);
    }
    public void SellItem()
    {
        Destroy(this);
    }

    public void Active()
    {
        player.XPInstaller(400);
        Destroy(this);
    }

}
