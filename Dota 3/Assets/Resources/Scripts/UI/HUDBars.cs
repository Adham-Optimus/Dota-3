using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDBars : MonoBehaviour
{
    [SerializeField] PlayerScript player;
    Image hpBar;
    Image manaBar;

    Text textHpBar;
    Text textManaBar;

    Text textHpRegen;
    Text textManaRegen;
    void Start()
    {
        hpBar = transform.GetChild(0).GetComponent<Image>();
        manaBar = transform.GetChild(1).GetComponent<Image>();

        textHpBar = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        textManaBar = transform.GetChild(1).GetChild(0).GetComponent<Text>();

        textHpRegen = transform.GetChild(0).GetChild(1).GetComponent<Text>() ;
        textManaRegen = transform.GetChild(1).GetChild(1).GetComponent<Text>() ;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hpBar.fillAmount = player.percentOfHP;
        manaBar.fillAmount = player.percentOfMana;

        textHpBar.text = (int)player.hp + "/" + (int)player.maxhp;
        textManaBar.text = (int)player.mana + "/" + (int)player.maxMana;

        textHpRegen.text = "+" + (int)player.hpRegen;
        textManaRegen.text = "+" + (int)player.manaRegen;
    }
}
