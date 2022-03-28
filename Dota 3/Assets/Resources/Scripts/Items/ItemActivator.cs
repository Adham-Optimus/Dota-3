using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActivator : MonoBehaviour
{
    /*public abstract void ItemInstaller(PlayerScript player, Item item, ItemActivator itemActivator, int cost);
    public abstract void Active();
    public abstract void Passive(); 
    public abstract void SellItem();*/
}

public interface IPressable
{
    public void Active();
}

public interface IConstantable
{
    public void Passive();
}

public interface ISellable
{
    public void SellItem();
}

public interface IDamagable
{
    public void TakeDamage(float damage, bool isMagic);
}