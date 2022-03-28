using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Apple : MonoBehaviour, IPressable, IConstantable, ISellable
{
    private Item item; 
    PlayerScript player;
    private void Start()
    {
        player = GetComponentInParent<InventoryHUD>().player;
        item = GetComponent<Item>();    
        item.ActiveInstaller(this);
        item.PassiveInstaller(this);
        item.SellInstaller(this);
    }
    public  void Active()
    {
        player.hpRegen -= 1;
        player.ManaInstaller(100);
        item.GetComponent<Image>().sprite = null;
        Destroy(this);
    }
    public void SellItem()
    {
        player.hpRegen -= 1;
        Destroy(this);
    }

    public void Passive()
    {
        player.hpRegen += 1;
    }
}

