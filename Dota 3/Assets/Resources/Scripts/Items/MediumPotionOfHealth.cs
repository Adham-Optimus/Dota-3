using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediumPotionOfHealth : MonoBehaviour, ISellable, IPressable
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
        player.hpRegen += 16;
        GetComponent<Image>().sprite = null;
        yield return new WaitForSeconds(12);
        player.hpRegen -= 16;
        Destroy(this);

    }
}