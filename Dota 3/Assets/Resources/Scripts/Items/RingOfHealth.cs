using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOfHealth : MonoBehaviour, ISellable, IConstantable
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
        player.hpRegen -= 7;
        Destroy(this);
    }

    public void Passive()
    {
        player.hpRegen += 7;
    }
}