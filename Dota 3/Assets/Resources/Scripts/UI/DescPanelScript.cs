using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescPanelScript : MonoBehaviour
{
    public Vector3 vec;
    [SerializeField] private static Text name;
    [SerializeField] private static Text attributes;
    [SerializeField] private static Text description;
    [SerializeField] private static Text cost;
    private static GameObject panel;
    void Awake()
    {
        name = transform.GetChild(0).GetComponent<Text>();
        attributes = transform.GetChild(1).GetComponent<Text>();
        description = transform.GetChild(2).GetComponent<Text>();
        cost = transform.GetChild(3).GetComponent<Text>();
        panel = gameObject;
        Switch(false);
    }

    public static void Install(string _name, string _attributes, string _description, string _cost)
    {
        name.text = _name;
        attributes.text = _attributes;
        description.text = _description;
        cost.text = "Cost: " + _cost;
    }

    public static void Switch(bool state)
    {
        panel.SetActive(state);
    }
}
