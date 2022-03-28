using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] PlayerScript player;
    public Button button;
    public Image image;
    Image imageOfCooldown;
    Button sellButton;

    public float cooldown = 0;
    public float maxCooldown = 0;

    public bool hasItem;
    //public bool can
    private void Awake()
    {
        imageOfCooldown = GetComponentInChildren<Image>();
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        sellButton = transform.GetChild(1).GetComponent<Button>();
    }
    public void AddItemToSlot(Item item)
    {
        
    }


    private void FixedUpdate()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            imageOfCooldown.fillAmount = cooldown / maxCooldown;
        }
    }

    private void NullingItem()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (image.sprite != null & Input.GetMouseButton(1))
        {
            sellButton.gameObject.SetActive(true);
        }
    }
}
