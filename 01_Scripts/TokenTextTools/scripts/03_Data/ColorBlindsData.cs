using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Colorblind
{
    BASE,
    DEUTERANOPIA,
    PROTANOPIA,
    TRITANOPIA
}

[System.Serializable]
public class ColorBlindsData
{
    public Colorblind colorblindness;
    public Color selectedColor;
}
