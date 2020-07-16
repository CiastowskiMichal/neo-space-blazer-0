using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemManagement : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    private bool isNameVisible = false;
    private bool isPickedFromInventory = false;
    private Vector2 localPoint = new Vector2();
    private RandomItemGenerator randomItem;
    // Use this for initialization
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(swapItem);
    }

    // Update is called once per frame
    void Update()
    {
        if (isNameVisible)
        {
            //Debug.Log(getInfo());
        }
        if (isPickedFromInventory)
        {
            //RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.FindGameObjectWithTag("_mainCanvas").GetComponent<RectTransform>(), Input.mousePosition, Camera.current, out localPoint);
            //transform.position = localPoint;
            //Debug.Log(localPoint);

        }
    }
    void swapItem()
    {
        //Debug.Log(transform.GetSiblingIndex());
        //RandomItemGenerator rid = transform.GetComponentInParent<InventoryController>().getObject(transform.GetSiblingIndex());
        switch (randomItem.getItemType())
        {
            case 0:
                transform.GetComponentInParent<InventoryController>().sendToInventorySlot(transform.GetSiblingIndex(), "_helmetTag", "_inventoryList");
                break;
            case 1:
                transform.GetComponentInParent<InventoryController>().sendToInventorySlot(transform.GetSiblingIndex(), "_armorTag", "_inventoryList");
                break;
            case 2:
                transform.GetComponentInParent<InventoryController>().sendToInventorySlot(transform.GetSiblingIndex(), "_weapon1Tag", "_inventoryList");
                break;
            case 3:
                transform.GetComponentInParent<InventoryController>().sendToInventorySlot(transform.GetSiblingIndex(), "_weapon2Tag", "_inventoryList");
                break;
            case 4:
                transform.GetComponentInParent<InventoryController>().sendToInventorySlot(transform.GetSiblingIndex(), "_mod1Tag", "_inventoryList");
                break;
            case 5:
                transform.GetComponentInParent<InventoryController>().sendToInventorySlot(transform.GetSiblingIndex(), "_mod2Tag", "_inventoryList");
                break;
            case 6:
                transform.GetComponentInParent<InventoryController>().sendToInventorySlot(transform.GetSiblingIndex(), "_mod3Tag", "_inventoryList");
                break;
            default:
                break;
        }

    }
    string getInfo()
    {
        return randomItem.getFullName();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isNameVisible = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isNameVisible = false;
    }
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        isPickedFromInventory = true;
        //transform.SetParent(GameObject.FindGameObjectWithTag("_inventoryPanel").transform);
    }
    public void setRandomItem(RandomItemGenerator rid)
    {
        randomItem = rid;
    }
    public RandomItemGenerator getRid()
    {
        return randomItem;
    }
}
