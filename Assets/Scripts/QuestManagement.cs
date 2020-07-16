using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManagement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Button>().onClick.AddListener(showQuest);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void showQuest()
	{
		transform.GetComponentInParent<QuestController>().showQuest(transform.GetSiblingIndex());
	}
}
