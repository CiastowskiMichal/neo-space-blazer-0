using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemParamentersContainer : MonoBehaviour
{

    private RandomItemGenerator randomItemGenerator;
    private bool isPlayer = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setDestroyer(bool boolean)
    {
        isPlayer = boolean;
    }
    public void setItem(RandomItemGenerator createdRig)
    {
        randomItemGenerator = createdRig;
    }
    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        if (isPlayer)
        {
            GameObject.FindGameObjectWithTag("_pickedList").GetComponent<PickingItems>().addNewToList(randomItemGenerator);
            GameObject.FindGameObjectWithTag("_inventoryList").GetComponent<InventoryController>().addNewToList(randomItemGenerator);
        }

    }
}
