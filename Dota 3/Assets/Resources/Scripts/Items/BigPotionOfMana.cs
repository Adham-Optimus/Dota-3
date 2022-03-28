using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigPotionOfMana : MonoBehaviour, ISellable, IPressable
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
        StartCoroutine(Coroutine());
    }

    private IEnumerator Coroutine()
    {
        player.manaRegen += 15;
        GetComponent<Image>().sprite = null;
        yield return new WaitForSeconds(16);
        player.manaRegen -= 15;
        Destroy(this);

    }
}
