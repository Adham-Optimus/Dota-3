using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MethodsForButtons : MonoBehaviour
{
    private InventoryHUD inv;
    void Start()
    {
        inv = GetComponent<InventoryHUD>();
    }

    public void FirstButton(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<Apple>();
                    return;
                }
            }
        }
    }
    public void SecondButton(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<RingOfProtection>();
                    return;
                }
            }
        }
    }
    public void ThirdButton(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<RingOfRegeneration>();
                    return;
                }
            }
        }
    }
    public void FourthButton(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<RingOfStrength>();
                    return;
                }
            }
        }
    }
    public void A5Button(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<RingOfAgility>();
                    return;
                }
            }
        }
    }
    public void A6Button(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<RingOfIntelligence>();
                    return;
                }
            }
        }
    }
    public void A7Button(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<RingOfHealth>();
                    return;
                }
            }
        }
    }
    public void A8Button(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<RingOfMana>();
                    return;
                }
            }
        }
    }
    public void A9Button(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<SoulRing>();
                    return;
                }
            }
        }
    }
    public void A10Button(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<SmallPotionOfMana>();
                    return;
                }
            }
        }
    }
    public void A11Button(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<SmallPotionOfHealth>();
                    return;
                }
            }
        }
    }
    public void A12Button(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<MediumPotionOfMana>();
                    return;
                }
            }
        }
    }
    public void A13Button(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<MediumPotionOfHealth>();
                    return;
                }
            }
        }
    }
    public void A14Button(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<BigPotionOfMana>();
                    return;
                }
            }
        }
    }
    public void A15Button(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<BigPotionOfHealth>();
                    return;
                }
            }
        }
    }
    public void A16Button(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<TomeOfKnowledge>();
                    return;
                }
            }
        }
    }
    public void A17Button(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<ScepterOfStrength>();
                    return;
                }
            }
        }
    }
    public void A18Button(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<ScepterOfAgility>();
                    return;
                }
            }
        }
    }
    public void A19Button(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<ScepterOfIntelligence>();
                    return;
                }
            }
        }
    }
    public void A20Button(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<PointBoosterScript>();
                    return;
                }
            }
        }
    }
    public void A21Button(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<BootsOfSpeed>();
                    return;
                }
            }
        }
    }
    public void A22Button(Item item)
    {
        if (item.cost <= inv.player.moneys)
        {
            for (int i = 0; i < inv.slots.Length; i++)
            {
                if (inv.slots[i].sprite == null)
                {
                    inv.player.moneys -= item.cost;
                    inv.slots[i].GetComponent<Item>().InstallParameters(item);
                    inv.slots[i].sprite = item.GetComponent<Image>().sprite;
                    inv.slots[i].gameObject.AddComponent<GlovesOfHaste>();
                    return;
                }
            }
        }
    }
}
