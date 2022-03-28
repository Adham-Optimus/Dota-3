using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    [SerializeField] GameObject g;
    public void OpenTheShop()
    {
        g.SetActive(!g.activeSelf);
    }
}
