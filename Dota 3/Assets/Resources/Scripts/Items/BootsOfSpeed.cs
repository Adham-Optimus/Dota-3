using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootsOfSpeed : MonoBehaviour, ISellable, IConstantable
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
        player.agent.speed -= 5;
        Destroy(this);
    }

    public void Passive()
    {
        player.agent.speed += 5;
    }
}