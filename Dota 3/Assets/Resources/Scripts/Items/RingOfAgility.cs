using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOfAgility : MonoBehaviour, ISellable, IConstantable
{
    private Item item;
    PlayerScript player;
    private void Start()
    {
        player = GetComponentInParent<InventoryHUD>().player;
        item = GetComponent<Item>();
        item.SellInstaller(this);
        item.PassiveInstaller(this);
    }
    public void SellItem()
    {
        player.AgilityInstaller(-6);
        Destroy(this);
    }

    public void Passive()
    {
        player.AgilityInstaller(6);
    }
}
