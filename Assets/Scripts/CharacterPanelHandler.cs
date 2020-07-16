using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPanelHandler : MonoBehaviour {
	[SerializeField]
	RectTransform menu;
	private bool isVisible = false;
	[SerializeField]
	Button showMenu;
	

	// Use this for initialization
	void Start () {
		showMenu.onClick.AddListener(showCharacterPanel);
		menu.anchoredPosition = new Vector2(0,-800);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("SwitchCharacterTab"))
		{
			showCharacterPanel();
			foreach(Transform child in GameObject.FindGameObjectWithTag("_questDetails").transform)
			{
				Destroy(child.gameObject);
			}
		}
	}
	void showCharacterPanel()
	{
		
		if(isVisible)
		{
			//Time.timeScale = 1;
			menu.anchoredPosition = new Vector2(0, -800);
			isVisible = false;
		}
		else
		{
			//Time.timeScale = 0;
			menu.anchoredPosition = new Vector2(0, 0);
			isVisible = true;
		}
	}
}
