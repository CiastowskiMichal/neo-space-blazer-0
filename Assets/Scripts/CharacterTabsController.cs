using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterTabsController : MonoBehaviour
{

    [SerializeField]
    Button questTabButton;
    [SerializeField]
    Button inventoryTabButton;
    [SerializeField]
    Button skillTabButton;
    [SerializeField]
    GameObject questTabPanel;
    [SerializeField]
    GameObject inventoryTabPanel;
    [SerializeField]
    GameObject skillTabPanel;
    private RectTransform questTabPanelTransform;
    private RectTransform inventoryTabPanelTransform;
    private RectTransform skillTabPanelTransform;


    // Use this for initialization
    void Start()
    {
        questTabPanelTransform = questTabPanel.GetComponent<RectTransform>();
        inventoryTabPanelTransform = inventoryTabPanel.GetComponent<RectTransform>();
        skillTabPanelTransform = skillTabPanel.GetComponent<RectTransform>();
		questTabPanelTransform.anchoredPosition = new Vector2(-1400, 0);
        inventoryTabPanelTransform.anchoredPosition = new Vector2(0, 0);
        skillTabPanelTransform.anchoredPosition = new Vector2(1400, 0);
        questTabButton.onClick.AddListener(updateQuestTab);
        inventoryTabButton.onClick.AddListener(updateInventoryTab);
        skillTabButton.onClick.AddListener(updateSkillTab);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void updateQuestTab()
    {
        questTabPanelTransform.anchoredPosition = new Vector2(0, 0);
        inventoryTabPanelTransform.anchoredPosition = new Vector2(1400, 0);
        skillTabPanelTransform.anchoredPosition = new Vector2(2800, 0);
    }
    void updateInventoryTab()
    {
        questTabPanelTransform.anchoredPosition = new Vector2(-1400, 0);
        inventoryTabPanelTransform.anchoredPosition = new Vector2(0, 0);
        skillTabPanelTransform.anchoredPosition = new Vector2(1400, 0);
    }
    void updateSkillTab()
    {
        questTabPanelTransform.anchoredPosition = new Vector2(-2800, 0);
        inventoryTabPanelTransform.anchoredPosition = new Vector2(-1400, 0);
        skillTabPanelTransform.anchoredPosition = new Vector2(0, 0);
    }
}
