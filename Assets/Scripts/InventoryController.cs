using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{

    [SerializeField]
    GameObject toInstatiate;
    private static ArrayList pickedItemList = new ArrayList();
    private static ArrayList inventoryList = new ArrayList();
    private static ArrayList itemsFittedList = new ArrayList();
    [SerializeField]
    Button deleteLastEngram;
    // Use this for initialization
    void Start()
    {
        deleteLastEngram.onClick.AddListener(removeFirst);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addNewToList(RandomItemGenerator createdItem)
    {
        GameObject inheritedItem = Instantiate(toInstatiate);
        inheritedItem.transform.SetParent(GameObject.FindGameObjectWithTag("_inventoryList").transform, false);
        inheritedItem.transform.SetAsFirstSibling();
        inheritedItem.GetComponent<ItemManagement>().setRandomItem(createdItem);
        Color myColor = new Color();
        ColorUtility.TryParseHtmlString(createdItem.getQuality(), out myColor);
        //child.GetComponent<Image>().color = myColor;
        //inheritedItem.GetComponent<RectTransform>().anchoredPosition = new Vector3(120, -30 - 43500 / Screen.height * pickedItemList.Count, 0);
        foreach (Transform child in inheritedItem.transform)
        {
            //Debug.Log(child.name);
            switch (child.name)
            {
                case "ItemImage":
                    break;

                case "GradientFrame":
                    child.GetComponent<Image>().color = myColor;
                    break;

                case "ItemName":
                    child.GetComponent<Text>().text = createdItem.getFullName();
                    child.GetComponent<Text>().color = new Vector4(myColor.r + 0.2f, myColor.g + 0.2f, myColor.b + 0.2f, 1);
                    break;

                case "ItemDesc":
                    child.GetComponent<Text>().text = createdItem.getItemTypeDescription();
                    child.GetComponent<Text>().color = new Vector4(myColor.r + 0.2f, myColor.g + 0.2f, myColor.b + 0.2f, 1);
                    break;

                case "ItemStrength":
                    child.GetComponent<Text>().text = string.Format("{0}", createdItem.getItemStrength());
                    child.GetComponent<Text>().color = new Vector4(myColor.r + 0.2f, myColor.g + 0.2f, myColor.b + 0.2f, 1);
                    break;

                default:
                    break;
            }
        }
        //pickedItemList.Insert(0, inheritedItem);
        inventoryList.Insert(0, createdItem);
        //allItemsPicked.Insert(0,createdItem);
        if (transform.childCount > 9)
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(240, 60 * transform.childCount);
        }
        GameObject.FindGameObjectWithTag("_inventoryScroll").GetComponent<ScrollRect>().normalizedPosition = new Vector2(0, 1);


    }
    public void removeFirst()
    {
        if (transform.childCount >= 0)
        {
            if (transform.childCount > 9)
            {
                GetComponent<RectTransform>().sizeDelta = new Vector2(240, 60 * transform.childCount);
            }
            inventoryList.RemoveAt(0);
            pickedItemList.RemoveAt(0);
            Destroy(transform.GetChild(0).gameObject);
        }
    }
    public RandomItemGenerator getObject(int index)
    {
        return (RandomItemGenerator)inventoryList[index];
    }
    public void removeAt(int index)
    {
        if (transform.childCount >= index)
        {
            if (transform.childCount > 9)
            {
                GetComponent<RectTransform>().sizeDelta = new Vector2(240, 60 * transform.childCount);
            }
            inventoryList.RemoveAt(index);
            //pickedItemList.RemoveAt(index);
            Destroy(transform.GetChild(index).gameObject);
        }
    }
    public void sendToInventorySlot(int index, string equipmentToTag, string equipmentFromTag)
    {

        //Debug.Log(GameObject.FindGameObjectWithTag(equipmentToTag).transform.childCount);
        //Debug.Log(transform.GetChild(index).transform.gameObject.GetComponent<ItemManagement>().getRid().getFullName());
        GameObject toTransfer = transform.GetChild(index).transform.gameObject;
        if (toTransfer.transform.parent.tag == equipmentFromTag)
        {
            toTransfer.transform.SetParent(GameObject.FindGameObjectWithTag(equipmentToTag).transform);
            toTransfer.transform.SetAsFirstSibling();
            checkTypePresence((RandomItemGenerator)inventoryList[index]);
            itemsFittedList.Add((RandomItemGenerator)inventoryList[index]);
            inventoryList.RemoveAt(index);

            //pickedItemList.RemoveAt(index);
            if (GameObject.FindGameObjectWithTag(equipmentToTag).transform.childCount == 2)
            {
                GameObject switchItems = GameObject.FindGameObjectWithTag(equipmentToTag).transform.GetChild(1).transform.gameObject;
                switchItems.transform.SetParent(GameObject.FindGameObjectWithTag(equipmentFromTag).transform);
                switchItems.transform.SetSiblingIndex(index);
                inventoryList.Insert(index, switchItems.GetComponent<ItemManagement>().getRid());

                //pickedItemList.Insert(index, switchItems);
            }
            if (transform.childCount > 9)
            {
                GetComponent<RectTransform>().sizeDelta = new Vector2(240, 60 * transform.childCount);
            }
        }
    }
    private void checkTypePresence(RandomItemGenerator itemGenerator)
    {
        //ArrayList container
        int counter = 0;
        int index = 0;
        foreach (RandomItemGenerator item in itemsFittedList)
        {
            if (item.getItemType() == itemGenerator.getItemType())
            {
                counter++;
                break;
            }
            index++;
        }
        if (counter > 0)
        {
            itemsFittedList.RemoveAt(index);
        }
    }
    public ArrayList getFittedItems()
    {
        return itemsFittedList;
    }
}
