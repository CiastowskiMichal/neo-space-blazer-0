using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributesController : MonoBehaviour
{
    private int strengthValue = 0;
    private int agilityValue = 0;
    private int armorValue = 0;
    private ArrayList fittedItemsList = new ArrayList();

    // Use this for initialization
    void Start()
    {
        foreach (Transform child in transform)
        {
            //Debug.Log(child.name);
            switch (child.name)
            {
                case "StrengthName":
                    child.GetComponent<Text>().text = "Siła";
                    break;

                case "StrengthValue":
                    child.GetComponent<Text>().text = "0";
                    break;

                case "AgilityName":
                    child.GetComponent<Text>().text = "Zręczność";
                    break;

                case "AgilityValue":
                    child.GetComponent<Text>().text = "0";
                    break;

                case "ArmorName":
                    child.GetComponent<Text>().text = "Ochrona";
                    break;

                case "ArmorValue":
                    child.GetComponent<Text>().text = "0";
                    break;

                default:
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(armorValue);
        strengthValue = 0;
        agilityValue = 0;
        armorValue = 0;
        fittedItemsList = GameObject.FindGameObjectWithTag("_inventoryList").GetComponent<InventoryController>().getFittedItems();
        foreach (RandomItemGenerator itemGenerator in fittedItemsList)
        {

            switch (itemGenerator.getItemType())
            {
                case 0:
                    armorValue += itemGenerator.getItemStrength();
                    break;

                case 1:
                    armorValue += itemGenerator.getItemStrength();
                    break;

                case 2:
                    strengthValue += itemGenerator.getItemStrength();
                    break;

                case 3:
                    agilityValue += itemGenerator.getItemStrength();
                    break;

                case 4:
                    strengthValue += itemGenerator.getItemStrength();
                    break;

                case 5:
                    agilityValue += itemGenerator.getItemStrength();
                    break;

                case 6:
                    armorValue += itemGenerator.getItemStrength();
                    break;

                default:
                    break;
            }
        }
        foreach (Transform child in transform)
        {
            //Debug.Log(child.name);
            switch (child.name)
            {
                case "StrengthValue":
                    child.GetComponent<Text>().text = string.Format("{0}", strengthValue);
                    break;

                case "AgilityValue":
                    child.GetComponent<Text>().text = string.Format("{0}", agilityValue);
                    break;

                case "ArmorValue":
                    child.GetComponent<Text>().text = string.Format("{0}", armorValue);
                    break;

                default:
                    break;
            }
        }
    }
}
