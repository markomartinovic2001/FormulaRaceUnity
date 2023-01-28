using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarChanger : MonoBehaviour
{
    public Image imageToChangeP1;
    public Image imageToChangeP2;
    public Sprite[] sprites;
    int currentCarP1Index = 3;
    int currentCarP2Index = 0;
    public GameObject FormulaP1;
    public GameObject FormulaP2;
    public Material[] newMaterialP1;
    public Material[] newMaterialP2;

    public void ChangeCarP1Next()
    {
        currentCarP1Index++;
        if (currentCarP1Index >= sprites.Length)
        {
            currentCarP1Index = 0;
        }
        imageToChangeP1.sprite = sprites[currentCarP1Index];
    }
    public void ChangeCarP1Previous()
    {
        if (currentCarP1Index <= 0)
        {
            currentCarP1Index = sprites.Length - 1;
        }
        else
        {
            currentCarP1Index -= 1;
        }
        imageToChangeP1.sprite = sprites[currentCarP1Index];
    }
    public void ChangeCarP2Next()
    {
        currentCarP2Index++;
        if (currentCarP2Index >= sprites.Length)
        {
            currentCarP2Index = 0;
        }
        imageToChangeP2.sprite = sprites[currentCarP2Index];
    }
    public void ChangeCarP2Previous()
    {
        if (currentCarP2Index <= 0)
        {
            currentCarP2Index = sprites.Length - 1;
        }
        else
        {
            currentCarP2Index -= 1;
        }
        imageToChangeP2.sprite = sprites[currentCarP2Index];
    }
        public void PickColors()
    {
        FormulaP1.GetComponent<Renderer>().material = newMaterialP1[currentCarP1Index];
        FormulaP2.GetComponent<Renderer>().material = newMaterialP2[currentCarP2Index];
    }
}