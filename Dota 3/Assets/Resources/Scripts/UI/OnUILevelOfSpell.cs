using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnUILevelOfSpell : MonoBehaviour
{
    private int level = 0;
    Text textLevel;
    private void Start()
    {
        textLevel = GetComponent<Text>();
    }
    public void LevelUp()
    {
        level++;
        textLevel.text = level.ToString();
    }
}
