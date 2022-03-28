using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusSpellScript : MonoBehaviour
{
    [SerializeField] PlayerScript player;
    GameObject firstPlus;
    GameObject secondPlus;
    GameObject thirdPlus;
    GameObject fourthPlus;

    [SerializeField] Text firstSpellLevel;
    [SerializeField] Text secondSpellLevel;
    [SerializeField] Text thirdSpellLevel;
    [SerializeField] Text fourthSpellLevel; 

    private int plussesLevel = 0;

    void Start()
    {
        firstPlus = transform.GetChild(0).gameObject;
        secondPlus = transform.GetChild(1).gameObject;
        thirdPlus = transform.GetChild(2).gameObject;
        fourthPlus = transform.GetChild(3).gameObject;
    }

    public void FirstPlus()
    {
        if (player.firstSpelllevel < 5)
        {
            player.firstSpelllevel += 1;
            if (player.firstSpelllevel == 1) firstSpellLevel.GetComponentInParent<Image>().color = Color.white;
            plussesLevel++;
            firstSpellLevel.text = player.firstSpelllevel.ToString();
            if (plussesLevel >= player.level) { gameObject.SetActive(false); }
            if (player.firstSpelllevel == 4) { Destroy(firstPlus); }
        }
    }
    public void SecondPlus()
    {
        if (player.secondSpelllevel < 5)
        {
            player.secondSpelllevel += 1;
            if (player.secondSpelllevel == 1) secondSpellLevel.GetComponentInParent<Image>().color = Color.white;
            plussesLevel++;
            secondSpellLevel.text = player.secondSpelllevel.ToString();
            if (plussesLevel == player.level) { gameObject.SetActive(false); }
            if (player.secondSpelllevel == 4) { Destroy(secondPlus); }
        }
    }

    public void ThirdPlus()
    {
        if (player.thirdSpelllevel < 5)
        {
            player.thirdSpelllevel += 1;
            if (player.thirdSpelllevel == 1) thirdSpellLevel.GetComponentInParent<Image>().color = Color.white;
            plussesLevel++;
            thirdSpellLevel.text = player.thirdSpelllevel.ToString();
            if (plussesLevel == player.level) { gameObject.SetActive(false); }
            if (player.thirdSpelllevel == 4) { Destroy(thirdPlus); }
        }
    }

    public void FourthPlus()
    {
        if (player.fourthSpelllevel < 5)
        {
            player.fourthSpelllevel += 1;
            if (player.fourthSpelllevel == 1) fourthSpellLevel.GetComponentInParent<Image>().color = Color.white;
            plussesLevel++;
            fourthSpellLevel.text = player.fourthSpelllevel.ToString();
            if (plussesLevel == player.level) { gameObject.SetActive(false); }
            if (player.fourthSpelllevel == 4) { Destroy(fourthPlus); }
        }
    }
}