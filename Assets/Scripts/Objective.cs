using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasa Objective pozwalająca instancjować nowe obiekty typu Objective,
/// uzywane w obiekcie Quest do tworzenia list celów w zadaniu
/// </summary>
public class Objective
{

    // Nazwa celu
    private string objectiveName;
    // Nazwa taga obiektu, który ma zostac znaleziony w scenie i brany pod uwage
    private string objectiveTargetTag;
    // Licznik wykonania lub znalezienia celu w scenie
    private int objectiveTargetCount;
    // Typ celu: zbieranie, interakcja, unieszkodliwienie
    private string objectiveType;
    private int counter;
    private bool isCompleted;
    private string fullObjectiveName;


    // / <summary>
    // / Konstruktor Objective przyjmujacy nazwe oraz
    // / </summary>
    // / <param name="name">Nazwa celu: 'Znajdź 10 elementów','Włącz urządzenie','Unieszkodliw przeciwnika'</param>
    // / <param name="type">Typ celu, uzywane nazwy: 'fetch','interact','takedown'</param>
    /// <summary>
    /// 
    /// </summary>
    /// <param name="name">Nazwa celu: 'Znajdź 10 elementów','Włącz urządzenie','Unieszkodliw przeciwnika'</param>
    /// <param name="type">Typ celu, uzywane nazwy: 'fetch','interact','takedown'</param>
    /// <param name="tag">Identyfikator gameobjectu, ktory jest podnoszony</param>
    /// <param name="count">ilosc podniesien wymaganych do ukonczenia</param>
    public Objective(string name, string type, string tag, int count)
    {
        this.objectiveName = name;
        this.objectiveType = type;
        this.objectiveTargetTag = tag;
        this.objectiveTargetCount = count;
        this.counter = 0;
        isCompleted = false;
        setFullObjectiveName(0);
    }
    public string getObjectiveTargetTag()
    {
        return objectiveTargetTag;
    }
    public int getObjectiveTargetCount()
    {
        return objectiveTargetCount;
    }
    public void setObjectiveTargetTag(string name)
    {
        this.objectiveTargetTag = name;
    }
    public void setObjectiveTargetCount(int count)
    {
        this.objectiveTargetCount = count;
    }
    public string getObjectiveName()
    {
        return objectiveName;
    }
    public void setFullObjectiveName(int i)
    {
        counter = i;
        if (counter >= getObjectiveTargetCount())
        {
            isCompleted = true;
            fullObjectiveName = getObjectiveName() + ": " + "Zakończono";
        }
        else
        {
            fullObjectiveName = getObjectiveName() + ": " + getCounter() + " z " + getObjectiveTargetCount();
        }
    }
    public string getFullObjectiveName()
    {
        return fullObjectiveName;
    }
    public int getCounter()
    {
        return counter;
    }
    public bool completed()
    {
        return isCompleted;
    }
}
