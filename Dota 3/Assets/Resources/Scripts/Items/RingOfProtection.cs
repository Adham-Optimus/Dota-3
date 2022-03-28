using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOfProtection : MonoBehaviour, ISellable, IConstantable
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
        player.ArmorInstaller(-2);
        Destroy(this);
    }

    public void Passive()
    {
        player.ArmorInstaller(2);
    }
}