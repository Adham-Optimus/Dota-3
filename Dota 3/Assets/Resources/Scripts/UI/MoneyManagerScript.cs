using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManagerScript : MonoBehaviour
{
    [SerializeField]PlayerScript player;
    private Text moneyText;
    void Start()
    {
        moneyText = GetComponent<Text>();   
    }

    void FixedUpdate()
    {
        player.moneys += Time.deltaTime;
        moneyText.text = ((int)player.moneys).ToString();
    }
}
