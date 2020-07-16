using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questComputerHandler : MonoBehaviour
{

    // [SerializeField]
    // [Range (1,4)]
    // private int questCounter;
    private bool tookAll = false;
    private ArrayList quests = new ArrayList();
    private bool showTakenQuests = false;
    private float counterFadeOut = 0;
    [SerializeField]
    SpriteRenderer sprite;
	private float spriteAlpha = 0;
    // Use this for initialization
    void Start()
    {
        //dodanie zadan z listy statycznej do listy w komputerze
        StaticQuestList.makeList();
        foreach (Quest quest in StaticQuestList.questList)
        {
            if(quest.getCodeName() == "101" || quest.getCodeName()== "102")
            {
                quests.Add(quest);
            }
        }
        Debug.Log("Liczba questów: "+ quests.Count);
		if(sprite!=null)
		{
			sprite.color = new Vector4(sprite.color.r,sprite.color.g,sprite.color.b,spriteAlpha);
		}
    }

    // Update is called once per frame
    void Update()
    {
        if (showTakenQuests)
        {
            counterFadeOut += Time.deltaTime;
            string questPresentation = "";
            foreach (Quest quest in quests)
            {
                questPresentation += "<color=" + quest.getQuestColor() + ">" + quest.getQuestName() + "</color>" + "<br>";
                questPresentation = questPresentation.Replace("<br>", "\n");
            }
            GameObject.FindGameObjectWithTag("_questPresentation").GetComponent<Text>().text = questPresentation;
            if (counterFadeOut >= 2f)
            {
                GameObject.FindGameObjectWithTag("_questPresentation").GetComponent<Text>().text = "";
            }
        }
        else
        {
            GameObject.FindGameObjectWithTag("_questPresentation").GetComponent<Text>().text = "";
        }
		if(sprite!=null)
		{
			sprite.color = new Vector4(sprite.color.r,sprite.color.g,sprite.color.b,Mathf.Lerp(sprite.color.a,spriteAlpha,0.1f));
		}
    }
    public void takeQuests()
    {
        if (!tookAll)
        {
            foreach (Quest quest in quests)
            {
                GameObject.FindGameObjectWithTag("_questList").GetComponent<QuestController>().addNewQuest(quest);
            }
            tookAll = true;
            showTakenQuests = true;
        }
    }
    public void returnQuests()
    {
        int completedQuestIndex = 0;
        int completedQuestCounter = 0;
        ArrayList quests = GameObject.FindGameObjectWithTag("_questList").GetComponent<QuestController>().getQuestList();
        if (tookAll)
        {
            foreach (Quest quest in quests)
            {
                if (quest.completed())
                {
                    Debug.Log(completedQuestCounter);
                    completedQuestIndex = completedQuestCounter;
                }
                completedQuestCounter++;
            }
            Quest quest1 = (Quest)quests[completedQuestIndex];
            if (quest1.completed())
            {
                GameObject.FindGameObjectWithTag("_questList").GetComponent<QuestController>().removeAt(completedQuestIndex);
            }

        }
    }
    public bool getTookAll()
    {
        return tookAll;
    }
	public void setSpriteAlpha(float spriteAlpha)
	{
		this.spriteAlpha = spriteAlpha;
	}
}
