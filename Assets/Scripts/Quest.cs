using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///	Klasa Quest pozwalająca instancjować nowe obiekty typu Quest
/// </summary>
public class Quest
{

    private string questName;
    private ArrayList objectiveList = new ArrayList();
    private string questDescription;
//    private bool questCompleted;
    private string questType;
    private string questTypeColor;
    private string questTypeName;
    private string fullQuestName;
    private bool isCompleted;
    private string codeName;
    private int objectiveCompletedCounter;


    /// <param name="name">Nazwa zadania, podana jako string</param>
    /// <param name="type">Typ zadania, podawany jako string, spośród nazw 'main', 'side' oraz 'bounty'</param>
    public Quest(string name, string type, string code)
    {
        this.questName = name;
        //questCompleted = false;
        questDescription = "undefined";
        this.questType = type;
        questTypeColor = setQuestTypeColor(type);
        questTypeName = setQuestTypeName(type);
        fullQuestName = name;
        objectiveCompletedCounter = 0;
        isCompleted = false;
        this.codeName = code;

    }
    private string setQuestTypeColor(string type)
    {
        switch (type)
        {
            case "main":
                return "#FFD700";

            case "side":
                return "#C0C0C0";

            case "bounty":
                return "#CD853F";
            default:
                return "0";
        }
    }
    private string setQuestTypeName(string type)
    {
        switch (type)
        {
            case "main":
                return "Zadanie główne";

            case "side":
                return "Zadanie poboczne";

            case "bounty":
                return "Zlecenie";
            default:
                return "0";
        }
    }
    public string getQuestColor()
    {
        return questTypeColor;
    }
    public string getQuestName()
    {
        return questName;
    }
    public string getQuestTypeName()
    {
        return questTypeName;
    }
    public string getQuestDescription()
    {
        return questDescription;
    }
    /// <summary>
    /// Tworzenie nowego celu w zadaniu
    /// </summary>
    /// <param name="objectiveName">Nazwa celu: 'Znajdź 10 elementów','Włącz urządzenie','Unieszkodliw przeciwnika'</param>
    /// <param name="objectiveType">Typ celu, uzywane nazwy: 'fetch','interact','takedown'</param>
    /// <param name="objectiveTargetTag">Identyfikator gameobjectu, ktory jest podnoszony</param>
    /// <param name="objectiveTargetCount">ilosc podniesien wymaganych do ukonczenia</param>
    public void addObjectiveToList(string objectiveName, string objectiveType, string objectiveTargetTag, int objectiveTargetCount)
    {
        Objective objective = new Objective(objectiveName, objectiveType, objectiveTargetTag, objectiveTargetCount);
        // objective.setObjectiveTargetTag("_lolXD");
        // objective.setObjectiveTargetCount(3);
        objectiveList.Add(objective);
    }
    public ArrayList getObjectiveList()
    {
        return objectiveList;
    }
    public void setFullQuestName()
    {
        objectiveCompletedCounter = 0;
        foreach (Objective objective in objectiveList)
        {
            if(objective.completed())
            {
                objectiveCompletedCounter++;
            }
        }
        if(objectiveList.Count == objectiveCompletedCounter)
        {
            fullQuestName = questName + ": Zakończono";
            isCompleted = true;
        }
    }
    public string getFullQuestName()
    {
        return fullQuestName;
    }
    public bool completed()
    {
        return isCompleted;
    }
    public string getCodeName()
    {
        return codeName;
    }
}
