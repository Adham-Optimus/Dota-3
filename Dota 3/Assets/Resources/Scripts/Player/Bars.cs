using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bars : MonoBehaviour
{
    [SerializeField]PlayerScript player;
    private Image hpBar;
    private Image manaBar;
    void Start()
    {
        hpBar = transform.GetChild(0).GetComponent<Image>();
        manaBar = transform.GetChild(1).GetComponent<Image>();  
    }

    

    private void FixedUpdate()
    {
        manaBar.fillAmount = player.percentOfMana;
        hpBar.fillAmount = player.percentOfHP;
    }
}
