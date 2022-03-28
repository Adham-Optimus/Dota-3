using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtributesPanelScript : MonoBehaviour
{
    [SerializeField] PlayerScript player;

    [Header("Spells")]
    [SerializeField] GameObject firstSpell;
    [SerializeField] GameObject secondSpell;
    [SerializeField] GameObject thirdSpell;
    [SerializeField] GameObject fourthSpell;

    Image firstButtonImage;
    Image secondButtonImage;
    Image thirdButtonImage;
    Image fourthButtonImage;

    public Text attackDamageText;
    public Text armorText;
    public Text strengthText;
    public Text agilityText;
    public Text intelligenceText;
    public Text descriptionText;

    [Header("Cooldowns")]
    private float firstButtonCooldown = 0;
    public float firstButtonOfMaxCooldown;
    private float secondButtonCooldown = 0;
    public float secondButtonOfMaxCooldown;
    private float thirdButtonCooldown = 0;
    public float thirdButtonOfMaxCooldown;
    private float fourthButtonCooldown = 0;
    public float fourthButtonOfMaxCooldown;

    void Awake()
    {
        firstButtonImage =  transform.GetChild(0).GetChild(0).GetComponent<Image>();
        secondButtonImage = transform.GetChild(1).GetChild(0).GetComponent<Image>();
        thirdButtonImage =  transform.GetChild(2).GetChild(0).GetComponent<Image>();
        fourthButtonImage = transform.GetChild(3).GetChild(0).GetComponent<Image>();
        attackDamageText =  transform.GetChild(4).GetComponent<Text>(); 
        armorText =        transform.GetChild(5).GetComponent<Text>();
        strengthText =     transform.GetChild(6).GetComponent<Text>();    
        agilityText =      transform.GetChild(7).GetComponent<Text>(); 
        intelligenceText = transform.GetChild(8).GetComponent<Text>();
        descriptionText =  transform.GetChild(9).GetComponent<Text>();
    }

    
    public void FirstSpell()
    {
        switch (player.firstSpelllevel)
        {
            case 1: firstButtonOfMaxCooldown = 15; break;
            case 2: firstButtonOfMaxCooldown = 13; break;
            case 3: firstButtonOfMaxCooldown = 11; break;
            case 4: firstButtonOfMaxCooldown = 9; break;
        }
        if (firstButtonCooldown <= 0 & player.firstSpelllevel > 0)
        {
            Instantiate(firstSpell, player.transform);
            player.ManaInstaller(-90);
            firstButtonCooldown = firstButtonOfMaxCooldown;
        }
    }
    public void SecondSpell()
    {
        switch (player.secondSpelllevel)
        {
            case 1: secondButtonOfMaxCooldown = 16; break;
            case 2: secondButtonOfMaxCooldown = 14; break;
            case 3: secondButtonOfMaxCooldown = 12; break;
            case 4: secondButtonOfMaxCooldown = 10; break;
        }
        if (secondButtonCooldown <= 0 & player.secondSpelllevel > 0)
        {
            Instantiate(secondSpell, player.transform);
            player.ManaInstaller(-100);
            secondButtonCooldown = secondButtonOfMaxCooldown;
        }
    }
    public void ThirdSpell()
    {
        switch (player.thirdSpelllevel)
        {
            case 1: thirdButtonOfMaxCooldown = 15; break;
            case 2: thirdButtonOfMaxCooldown = 13; break;
            case 3: thirdButtonOfMaxCooldown = 11; break;
            case 4: thirdButtonOfMaxCooldown = 9; break;
        }
        if (thirdButtonCooldown <= 0 & player.thirdSpelllevel > 0)
        {
            Instantiate(thirdSpell, player.transform);
            player.ManaInstaller(-95);
            thirdButtonCooldown = thirdButtonOfMaxCooldown;
        }
    }
    public void FourthSpell()
    {
        switch (player.fourthSpelllevel)
        {
            case 1: fourthButtonOfMaxCooldown = 7; break;
            case 2: fourthButtonOfMaxCooldown = 6; break;
            case 3: fourthButtonOfMaxCooldown = 5; break;
            case 4: fourthButtonOfMaxCooldown = 4; break;
        }
        if (fourthButtonCooldown <= 0 & player.fourthSpelllevel > 0)
        {
            Instantiate(fourthSpell, player.transform);
            player.ManaInstaller(-80);
            fourthButtonCooldown = fourthButtonOfMaxCooldown;
        }
    }

    private void FixedUpdate()
    {
        if (firstButtonCooldown > 0) { firstButtonCooldown -= 1 * Time.deltaTime;   firstButtonImage.fillAmount = firstButtonCooldown / firstButtonOfMaxCooldown; }
        if (secondButtonCooldown > 0) { secondButtonCooldown -= 1* Time.deltaTime; secondButtonImage.fillAmount = secondButtonCooldown / secondButtonOfMaxCooldown; }
        if (thirdButtonCooldown > 0) { thirdButtonCooldown -= 1* Time.deltaTime;   thirdButtonImage.fillAmount = thirdButtonCooldown / thirdButtonOfMaxCooldown; }
        if (fourthButtonCooldown > 0) { fourthButtonCooldown -= 1* Time.deltaTime; fourthButtonImage.fillAmount = fourthButtonCooldown / fourthButtonOfMaxCooldown; }
    }
}
