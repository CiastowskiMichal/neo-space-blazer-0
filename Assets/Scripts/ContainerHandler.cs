using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerHandler : MonoBehaviour
{

    [SerializeField]
    GameObject toInstatiate;
    [SerializeField]
    [Range(1, 10)]
    private int howManyItems;
    private bool opened = false;
    [SerializeField]
    private bool questItem = false;
    [SerializeField]
    private string questItemTag;
    [SerializeField]
    SpriteRenderer sprite;
    private float spriteAlpha = 0;
    // Use this for initialization
    void Start()
    {
        if (sprite != null)
        {
            sprite.color = new Vector4(sprite.color.r, sprite.color.g, sprite.color.b, spriteAlpha);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sprite != null)
        {
            sprite.color = new Vector4(sprite.color.r, sprite.color.g, sprite.color.b, Mathf.Lerp(sprite.color.a, spriteAlpha, 0.1f));
        }
    }
    private void InstatiateLootHandler(int i)
    {
        RandomItemGenerator rig = new RandomItemGenerator();
        GameObject creation;
        creation = Instantiate(toInstatiate, new Vector3(transform.position.x, transform.position.y + 5 + i, transform.position.z), Random.rotation);
        Color myColor = new Color();
        ColorUtility.TryParseHtmlString(rig.getQuality(), out myColor);
        Vector4 engramColor = new Vector4(myColor.r, myColor.g, myColor.b, 1);
        creation.GetComponent<Renderer>().material.SetColor("_Color", engramColor);
        creation.GetComponentInChildren<Light>().color = engramColor;
        creation.GetComponent<ItemParamentersContainer>().setItem(rig);
        //return creation;
    }
    public void generateLoot()
    {
        if (!opened)
        {
            for (int i = 1; i <= howManyItems; i++)
            {
                InstatiateLootHandler(i);
            }
            if (questItem && questItemTag != null)
            {
                GameObject gameObject = new GameObject();
                gameObject.name = questItemTag;
                gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("_questBag").transform);
            }
            opened = true;
            sprite.color = new Vector4(1,0.4f,0.4f,sprite.color.a);
        }

    }
    public void setSpriteAlpha(float spriteAlpha)
    {
        this.spriteAlpha = spriteAlpha;
    }
}
