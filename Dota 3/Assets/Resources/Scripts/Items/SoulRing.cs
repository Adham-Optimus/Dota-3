using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulRing : MonoBehaviour, ISellable,  IPressable
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
        player.maxMana += 150;
        player.mana += 150;
        player.maxhp -= 100;
        player.hp -= 100;
        StartCoroutine(Coroutine());
    }

    private IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(10);
        player.maxMana -= 150;
        player.mana -= 150;
        player.maxhp += 100;
        player.hp += 100;
    }
}
