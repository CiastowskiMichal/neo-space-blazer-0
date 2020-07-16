using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickingItems : MonoBehaviour
{

    //[SerializeField]
    //Button addElements;
    [SerializeField]
    GameObject pickedTemplate;
    private static ArrayList pickedItemList = new ArrayList();
    float timeToDissolve = 0;
    GameObject objectToDissolve;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        int counter = 0;
        if (pickedItemList.Count > 0)
        {
            objectToDissolve = (GameObject)pickedItemList[0];
            foreach (GameObject pickedItem in pickedItemList)
            {
                //pickedItem.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, Mathf.Lerp(pickedItem.GetComponent<RectTransform>().anchoredPosition.y, 5 + 20000/Screen.height * counter, 0.05f), 0);
                counter++;
            }
            timeToDissolve += Time.deltaTime;
            if (timeToDissolve > 2)
            {
                objectToDissolve.GetComponent<Text>().color =
                new Vector4(
                    objectToDissolve.GetComponent<Text>().color.r,
                    objectToDissolve.GetComponent<Text>().color.g,
                    objectToDissolve.GetComponent<Text>().color.b,
                    Mathf.Lerp(objectToDissolve.GetComponent<Text>().color.a, 0, 0.1f));
                objectToDissolve.GetComponentInChildren<Image>().color =
                new Vector4(
                    objectToDissolve.GetComponentInChildren<Image>().color.r,
                    objectToDissolve.GetComponentInChildren<Image>().color.g,
                    objectToDissolve.GetComponentInChildren<Image>().color.b,
                    Mathf.Lerp(objectToDissolve.GetComponentInChildren<Image>().color.a, 0, 0.1f));
                if (objectToDissolve.GetComponent<Text>().color.a < 0.01f)
                {
                    objectToDissolve.GetComponent<RectTransform>().sizeDelta = new Vector2(160,Mathf.Lerp(objectToDissolve.GetComponent<RectTransform>().sizeDelta.y,0,0.05f));
                    if (objectToDissolve.GetComponent<RectTransform>().sizeDelta.y < 0.1f)
                    {
                        removeFirstElement();
                        timeToDissolve = 0;
                    }

                }

            }
        }

    }

    void removeFirstElement()
    {
        if (pickedItemList.Count > 0)
        {
            GameObject toDelete = (GameObject)pickedItemList[0];
            pickedItemList.RemoveAt(0);
            Destroy(toDelete);
        }
    }
    public void addNewToList(RandomItemGenerator createdItem)
    {
        GameObject inheritedItem = Instantiate(pickedTemplate);
        inheritedItem.transform.SetParent(GameObject.FindGameObjectWithTag("_pickedList").transform, false);
        inheritedItem.transform.SetAsFirstSibling();
        //inheritedItem.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 5 + 20000/Screen.height * pickedItemList.Count, 0);
        Color myColor = new Color();
        ColorUtility.TryParseHtmlString(createdItem.getQuality(), out myColor);
        inheritedItem.GetComponent<Text>().color = myColor;
        inheritedItem.GetComponent<Text>().text = createdItem.getFullName();
        inheritedItem.GetComponentInChildren<Image>().color = myColor;
        pickedItemList.Add(inheritedItem);
        GameObject.FindGameObjectWithTag("_xpBar").GetComponent<ExperienceBarView>().addExperience(45);
    }
}
