using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBoosterScript : MonoBehaviour, ISellable, IConstantable
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
        player.maxhp -= 250;
        player.hp -= 250;
        player.maxMana -= 200;
        player.mana -= 200;
        Destroy(this);
    }

    public void Passive()
    {
        player.maxhp += 250;
        player.hp += 250;
        player.maxMana += 200;
        player.mana += 200;
    }
}
