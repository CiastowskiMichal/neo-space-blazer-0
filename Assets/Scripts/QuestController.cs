using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestController : MonoBehaviour
{

    [SerializeField]
    GameObject questToInstantiate;
    [SerializeField]
    GameObject objectiveToInstantiate;
    [SerializeField]

    private GameObject[] questBagCounter;

    private static ArrayList questList = new ArrayList();
    private int indexOfQuestInWidget = -1;
    private int oldIndexOfQuestWidget = -1;
    private bool isWidgetVisible = false;
    private bool isEnumerating = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnumerating)
        {
            foreach (Quest quest in questList)
            {
                foreach (Objective objective in quest.getObjectiveList())
                {
                    //int counter = 0;
                    //questBagCounter = GameObject.FindGameObjectWithTag("_questBag").transform.(GameObject[])FindObjectsOfType(typeof(GameObject));
                    //for (int i = 0; i < questBagCounter.Length; i++)
                    //    if (questBagCounter[i].name.Contains(objective.getObjectiveTargetTag()))
                    //    {
                    //        counter++;
                    //    }
                    //questBagCounter = GameObject.Find(objective.getObjectiveTargetTag());
                    objective.setFullObjectiveName(FindGameObjectsWithName(objective.getObjectiveTargetTag()));
                }
                quest.setFullQuestName();
            }
            if (isWidgetVisible)
            {
                if (questList.Count > 0)
                {
                    Quest tempQuest = (Quest)questList[indexOfQuestInWidget];
                    GameObject.FindGameObjectWithTag("_questWidget").GetComponent<Text>().text = returnQuestWidget(tempQuest);
                }

                // if (oldIndexOfQuestWidget != indexOfQuestInWidget)
                // {
                //     if (oldIndexOfQuestWidget > -1)
                //     {
                //         GameObject.FindGameObjectWithTag("_questList").transform.GetChild(oldIndexOfQuestWidget).gameObject.GetComponent<Image>().color = new Vector4(0.27f, 0.29f, 0.36f, 1);
                //     }
                //     GameObject.FindGameObjectWithTag("_questList").transform.GetChild(indexOfQuestInWidget).gameObject.GetComponent<Image>().color = new Vector4(1, 0, 0, 1);
                // }
            }
            else
            {
                GameObject.FindGameObjectWithTag("_questWidget").GetComponent<Text>().text = "";
                //GameObject.FindGameObjectWithTag("_questList").transform.GetChild(indexOfQuestInWidget).gameObject.GetComponent<Image>().color = new Vector4(1,0,0,1);
            }
        }
    }
    public void test()
    {
        Quest testQuest = new Quest("Wprowadzenie", "main","202");
        testQuest.addObjectiveToList("Znajdź 10 elementów", "fetch", "_lolXD", 10);
        testQuest.addObjectiveToList("Znajdź 20 elementów", "fetch", "_lolXD2", 20);
        addNewQuest(testQuest);
        //showQuest(0);
        testQuest = new Quest("Zbieractwo", "side","203");
        testQuest.addObjectiveToList("Uruchomione silniki", "fetch", "_lolXD", 5);
        addNewQuest(testQuest);
    }
    public void addNewQuest(Quest quest)
    {
        GameObject inheritedItem = Instantiate(questToInstantiate);
        inheritedItem.transform.SetParent(GameObject.FindGameObjectWithTag("_questList").transform, false);
        inheritedItem.transform.SetAsLastSibling();
        Color myColor = new Color();
        ColorUtility.TryParseHtmlString(quest.getQuestColor(), out myColor);
        foreach (Transform child in inheritedItem.transform)
        {
            switch (child.name)
            {
                case "ItemImage":
                    break;

                case "GradientFrame":
                    child.GetComponent<Image>().color = myColor;
                    break;

                case "ItemName":
                    child.GetComponent<Text>().text = quest.getQuestName();
                    child.GetComponent<Text>().color = new Vector4(myColor.r + 0.2f, myColor.g + 0.2f, myColor.b + 0.2f, 1);
                    break;

                case "ItemDesc":
                    child.GetComponent<Text>().text = quest.getQuestTypeName();
                    child.GetComponent<Text>().color = new Vector4(myColor.r + 0.2f, myColor.g + 0.2f, myColor.b + 0.2f, 1);
                    break;

                default:
                    break;
            }
        }
        questList.Add(quest);
    }
    public void showQuest(int index)
    {
        if (GameObject.FindGameObjectWithTag("_questDetails").transform.childCount > 0)
        {
            foreach (Transform child in GameObject.FindGameObjectWithTag("_questDetails").transform)
            {
                Destroy(child.gameObject);
            }
        }
        Quest quest = (Quest)questList[index];
        GameObject tempObjective = Instantiate(objectiveToInstantiate);
        tempObjective.transform.SetParent(GameObject.FindGameObjectWithTag("_questDetails").transform, false);
        tempObjective.GetComponent<Text>().text = quest.getQuestName() + " - Kliknij by śledzić";
        tempObjective.AddComponent<Button>();

        tempObjective.GetComponent<Button>().onClick.AddListener(delegate { getIndex(index); });
        tempObjective = Instantiate(objectiveToInstantiate);
        tempObjective.transform.SetParent(GameObject.FindGameObjectWithTag("_questDetails").transform, false);
        tempObjective.GetComponent<Text>().text = quest.getQuestDescription();

        foreach (Objective objective in quest.getObjectiveList())
        {
            tempObjective = Instantiate(objectiveToInstantiate);
            tempObjective.transform.SetParent(GameObject.FindGameObjectWithTag("_questDetails").transform, false);
            tempObjective.GetComponent<Text>().text = objective.getFullObjectiveName();
        }
    }
    void getIndex(int index)
    {
        if (indexOfQuestInWidget == oldIndexOfQuestWidget)
        {
            if (isWidgetVisible)
            {
                //Debug.Log(1);
                isWidgetVisible = false;
            }
            else
            {
                //Debug.Log(2);
                isWidgetVisible = true;
            }

            oldIndexOfQuestWidget = indexOfQuestInWidget;
        }
        else if (indexOfQuestInWidget == index)
        {
            if (isWidgetVisible)
            {
                //Debug.Log(3);
                isWidgetVisible = false;
            }
            else
            {
                //Debug.Log(4);
                isWidgetVisible = true;
            }

            oldIndexOfQuestWidget = indexOfQuestInWidget;
        }
        indexOfQuestInWidget = index;
        if (isWidgetVisible)
        {
            foreach (Transform child in GameObject.FindGameObjectWithTag("_questList").transform)
            {
                child.gameObject.GetComponent<Image>().color = new Vector4(0.27f, 0.29f, 0.36f, 1);
            }
            GameObject.FindGameObjectWithTag("_questList").transform.GetChild(index).gameObject.GetComponent<Image>().color = new Vector4(1, 0, 0, 1);
        }
        else
        {
            foreach (Transform child in GameObject.FindGameObjectWithTag("_questList").transform)
            {
                child.gameObject.GetComponent<Image>().color = new Vector4(0.27f, 0.29f, 0.36f, 1);
            }
        }
    }
    string returnQuestWidget(Quest quest)
    {
        string questString = "";
        questString = quest.getFullQuestName() + "<br>";
        foreach (Objective objective in quest.getObjectiveList())
        {
            questString += objective.getFullObjectiveName() + "<br>";
        }
        questString = questString.Replace("<br>", "\n");
        return questString;
    }
    int FindGameObjectsWithName(string name)
    {
        int counter = 0;
        foreach (Transform child in GameObject.FindGameObjectWithTag("_questBag").transform)
        {
            if (child.transform.name == name)
            {
                counter++;
            }
        }
        return counter;
    }
    public ArrayList getQuestList()
    {
        return questList;
    }
    public void setQuestList(ArrayList quests)
    {
        questList = quests;
    }
    public void removeAt(int index)
    {
        isEnumerating = true;
        if (transform.childCount >= index)
        {
            if (questList.Count > 9)
            {
                GetComponent<RectTransform>().sizeDelta = new Vector2(240, 60 * questList.Count);
            }
            questList.RemoveAt(index);
            //questList.RemoveAt(index);
            Destroy(transform.GetChild(index).gameObject);
        }
        isEnumerating = false;
    }

}
