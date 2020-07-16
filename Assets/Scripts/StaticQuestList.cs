using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticQuestList{
	public static ArrayList questList = new ArrayList();
    public static void makeList()
    {
Quest quest = new Quest("Uszkodzony silnik", "main","101");
        quest.addObjectiveToList("Znajdź 3 kawałki stali", "fetch", "_itemQuest1", 3);
        quest.addObjectiveToList("Znajdź 4 kawałki platyny", "fetch", "_itemQuest2", 4);
        quest.addObjectiveToList("Znajdź 2 kawałki złota", "fetch", "_itemQuest3", 2);
        questList.Add(quest);

        quest = new Quest("Dodatkowe pieniądze", "side","102");
        quest.addObjectiveToList("Znajdź złom", "fetch", "_itemQuest4", 5);
        quest.addObjectiveToList("Znajdź plastik", "fetch", "_itemQuest5", 5);
        questList.Add(quest);

        quest = new Quest("Lokalne artefakty", "side","103");
        quest.addObjectiveToList("Pamiątki", "fetch", "_itemQuest6", 2);
        quest.addObjectiveToList("", "fetch", "_itemQuest7", 5);
        questList.Add(quest);
    }
}
