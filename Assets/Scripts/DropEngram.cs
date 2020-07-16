using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DropEngram : MonoBehaviour
{

    [SerializeField]
    Button createEngram;
    [SerializeField]
    GameObject toInstatiate;
    // Use this for initialization
    void Start()
    {
        createEngram.onClick.AddListener(InstatiateEngram);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void InstatiateEngram()
    {
        RandomItemGenerator rig = new RandomItemGenerator();
        GameObject creation;
        creation = Instantiate(toInstatiate, transform.position, Random.rotation);
        Color myColor = new Color();
        ColorUtility.TryParseHtmlString(rig.getQuality(), out myColor);
        Vector4 engramColor = new Vector4(myColor.r, myColor.g, myColor.b, 1);
		creation.GetComponent<Renderer>().material.SetColor("_Color",engramColor);
		creation.GetComponentInChildren<Light>().color = engramColor;
		creation.GetComponent<ItemParamentersContainer>().setItem(rig);
    }
    
}
