using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarOnTower : MonoBehaviour
{
    private TowerScript tower;
    private Image hpBar;
    void Start()
    {
        tower = GetComponentInParent<TowerScript>();
        hpBar = GetComponent<Image>();
    }

    public void BarHP(float percentOfHp)
    {
        hpBar.fillAmount = percentOfHp;
    }
}
