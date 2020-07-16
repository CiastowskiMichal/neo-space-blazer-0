using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBarView : MonoBehaviour
{

    [SerializeField] Button btnAddExp;

    [Range(0, 1)]
    [SerializeField] float state;
    private GameObject barView;
    private float minimumValue = 0;
    private int maximumValue = 1000;
    private int currentValue;
    private float visibleValue;
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 currPos;
    private Text levelString;
    private Text experienceString;
    private int levelValue = 1;
    // Use this for initialization
    void Start()
    {
        /* FIND EXPERIENCE BAR */
        btnAddExp.onClick.AddListener(delegate { addExperience(90); });
        barView = GameObject.FindGameObjectWithTag("_xpBar");
        currentValue = (int)(state * maximumValue);
        Debug.Log(currentValue);
        /* WRITE 0...1 VALUE TO MASK BAR */
        barView.GetComponent<Image>().fillAmount = loadState(currentValue, maximumValue);
        /* ASSIGMENT VALUES OF LEVEL AND EXPERIENCE TO STRINGS */
        levelString = GameObject.FindGameObjectWithTag("_xpLevel").GetComponent<Text>();
        experienceString = GameObject.FindGameObjectWithTag("_xpValue").GetComponent<Text>();
        visibleValue = currentValue;
        experienceString.text = string.Format("Doświadczenie: {0}", currentValue);
        levelString.text = string.Format("Poziom: {0}",levelValue);
    }

    // Update is called once per frame
    void Update()
    {
        /* CALCULATE SMOOTH TRANSITION FROM VISIBLE VALUE TO ACTUAL VALUE OF EXPERIENCE */
        visibleValue = Mathf.Lerp(visibleValue, currentValue, 0.05f);
        /* WRITE 0...1 VALUE TO MASK BAR */
        barView.GetComponent<Image>().fillAmount = loadState(visibleValue, maximumValue);
        /* ASSIGMENT VALUES OF LEVEL AND EXPERIENCE TO STRINGS */
        experienceString.text = string.Format("Doświadczenie: {0}", roundFloat(visibleValue));
        levelString.text = string.Format("Poziom: {0}",levelValue);
        valueController(currentValue);

    }
    float loadState(float curr, float max)
    {
        return curr / max;
    }
    public void addExperience(int addValue)
    {
        currentValue += addValue;
        //Debug.Log(RandomItemGenerator.getRandomColor() + " " + RandomItemGenerator.arrayTest());
    }
    int roundFloat(float notRounded)
    {
        int rounded = (int)notRounded;
        if (notRounded - rounded >= 0.5f)
        {
            return rounded + 1;
        }
        else
        {
            return rounded;
        }
    }
    void valueController(int currentValue)
    {
        if (currentValue >= maximumValue)
        {
            currentValue = this.currentValue - maximumValue;
            this.currentValue = currentValue;
            maximumValue += 500;
            levelValue += 1;
        }
    }
}
