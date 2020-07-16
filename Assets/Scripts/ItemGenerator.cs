using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemGenerator
{
    private string subjectName;
    private string complementName;
    private string qualityColor;
    private int itemType;
    private int itemStrength;
    private bool fitted;
    private int subjectNameIndex, complementNameIndex, qualityColorIndex;

    public RandomItemGenerator()
    {
        itemType = Random.Range(0, 7);
        subjectName = randomSubject();
        complementName = randomComplement();
        qualityColor = randomColor();
        itemStrength = Random.Range(9, 20);
        fitted = false;
    }
    public RandomItemGenerator(int itemType, int subjectNameIndex, int complementNameIndex, int qualityColorIndex, int itemStrength)
    {
        this.itemType = itemType;
        subjectName = specificSubject(subjectNameIndex);
        complementName = specificComplement(complementNameIndex);
        qualityColor = StaticNames.qualityColors[qualityColorIndex];
        this.itemStrength = itemStrength;

    }
    public string getFullName()
    {
        return string.Format("{0} {1}", subjectName, complementName);
    }
    public string getQuality()
    {
        return qualityColor;
    }
    public int getItemType()
    {
        return itemType;
    }
    public int getItemStrength()
    {
        return itemStrength;
    }
    public string getItemTypeDescription()
    {
        return StaticNames.typeDescription[itemType];
    }
    private string randomColor()
    {
        int quality = Random.Range(0, StaticNames.qualityColors.Length);
        return StaticNames.qualityColors[quality];
    }
    private string randomSubject()
    {
        switch (itemType)
        {
            case 0:
                return StaticNames.subjectHelmetNames[Random.Range(0, StaticNames.subjectHelmetNames.Length)];

            case 1:
                return StaticNames.subjectArmorNames[Random.Range(0, StaticNames.subjectArmorNames.Length)];

            case 2:
                return StaticNames.subjectWeapon1Names[Random.Range(0, StaticNames.subjectWeapon1Names.Length)];

            case 3:
                return StaticNames.subjectWeapon2Names[Random.Range(0, StaticNames.subjectWeapon2Names.Length)];

            case 4:
                return StaticNames.subjectMod1Names[Random.Range(0, StaticNames.subjectMod1Names.Length)];

            case 5:
                return StaticNames.subjectMod2Names[Random.Range(0, StaticNames.subjectMod2Names.Length)];

            case 6:
                return StaticNames.subjectMod3Names[Random.Range(0, StaticNames.subjectMod3Names.Length)];

            default:
                return "0";
        }
    }
    private string randomComplement()
    {
        int name = Random.Range(0, StaticNames.complementNames.Length);
        return StaticNames.complementNames[name];
    }
    private string specificSubject(int index)
    {
        switch (itemType)
        {
            case 0:
                return StaticNames.subjectHelmetNames[index];

            case 1:
                return StaticNames.subjectArmorNames[index];

            case 2:
                return StaticNames.subjectWeapon1Names[index];

            case 3:
                return StaticNames.subjectWeapon2Names[index];

            case 4:
                return StaticNames.subjectMod1Names[index];

            case 5:
                return StaticNames.subjectMod2Names[index];

            case 6:
                return StaticNames.subjectMod3Names[index];

            default:
                return "0";
        }
    }
    private string specificComplement(int index)
    {
        return StaticNames.complementNames[index];
    }
    public string arrayTest()
    {
        ArrayList arr1 = new ArrayList();
        arr1.Add("1");
        arr1.Add("2");
        arr1.Add("3");
        string ost = "";
        ost += arr1[0];
        ost += " ";
        arr1.RemoveAt(0);
        ost += arr1[0];
        return ost;
    }
    public bool getFitted()
    {
        return this.fitted;
    }

    public void isFitted(bool fitted)
    {
        this.fitted = fitted;
    }
    public string exportItem()
    {
        return itemType+"$"+subjectNameIndex+"$"+complementNameIndex+"$"+qualityColorIndex+"$"+itemStrength+"%";
    }
}
