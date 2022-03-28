using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]private string name;
    [SerializeField] [Multiline(5)]private string attributes;
    [SerializeField] [Multiline(9)]private string description;
    public int cost;
    public ISellable s_item;
    
    public void ActiveInstaller(IPressable activable)
    {
        GetComponent<Button>().onClick.AddListener(activable.Active);
    }
    public void PassiveInstaller(IConstantable passivable)
    {
        passivable.Passive();
    }
    public void SellInstaller(ISellable sellable)
    {
        s_item = sellable;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        DescPanelScript.Switch(true);
        DescPanelScript.Install(name, attributes, description, cost.ToString());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DescPanelScript.Switch(false);
    }

    public void InstallParameters(Item item)
    {
        name = item.name;
        attributes = item.attributes;
        description = item.description;
        cost = item.cost;
    }
    /*
    public void SecondStart()
    {
        player = GetComponentInParent<InventoryHUD>().player;
        StartCoroutine("ID" + id);
        GetComponent<Button>().onClick.AddListener(Active);
    }
    private void Active()
    {
        StartCoroutine("ActiveID" + id);
    }
    public void Delete()
    {
        StartCoroutine("DeleteID" + id);
    }


    //Apple
    private void ID1()
    {
        player.hpRegen += 1;
    }
    public void ActiveID1()
    {
        player.ManaChecker(100);
        GetComponent<Image>().sprite = null;
        Destroy(this);
    }
    public void DeleteID1()
    {
        player.hpRegen -= 1;
    }


    //Ring Of Protection
    public void ID2()
    {
        player.ArmorInstaller(2);
    }
    public void ActiveID2() { }
    public void DeleteID2()
    {
        player.ArmorInstaller(-2);
    }

    //Ring of regeneration
    public void ID3()
    {
        player.hpRegen += 2;
    }
    public void ActiveID3() { }
    public void DeleteID3()
    {
        player.hpRegen -= 2;
    }

    //Ring of Strength
    public void ID4() { player.StrengthInstaller(6); }
    public void ActiveID4() { }
    public void DeleteID4() { player.StrengthInstaller(-6); }

    //Ring of Agility
    public void ID5() { player.AgilityInstaller(6); }
    public void ActiveID5() { }
    public void DeleteID5() { player.IntelligenceInstaller(-6); }

    //Ring of Intelligence
    public void ID6() { player.IntelligenceInstaller(6); }
    public void ActiveID6() { }
    public void DeleteID6() { player.IntelligenceInstaller(-6); }

    //Ring of Health
    public void ID7() { player.hpRegen += 7; }
    public void ActiveID7() { }
    public void DeleteID7() { player.hpRegen -= 7; }

    //Ring of Mana
    public void ID8() { player.manaRegen += 3; }
    public void ActiveID8() { }
    public void DeleteID8() { player.manaRegen -= 3; }

    //Soul Ring

    //small potion of health

    //small potion of mana

    //medium potion of health

    //medium potion of mana

    //big potion of health

    //big potion of mana

    //tome of knowledge

    //Scepter of strength

    //scepter of agility

    //scepter of Intelligence

    //Point booster

    //boots of speed

    //gloves of haste

    //powertreads

    //aghanimsScepter

    //Perseverance

    //broadsword

    //sword of attack

    //Crystalis*/
}

