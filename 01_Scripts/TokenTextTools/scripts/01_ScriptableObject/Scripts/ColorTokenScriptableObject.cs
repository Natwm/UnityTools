using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorToken", menuName = "Token/color", order = 0)]
public class ColorTokenScriptableObject : ScriptableObject
{
   [BoxGroup("Color")] public List<ColorBlindsData> selectedColor;
   
   public FontStyles style;
   public TMP_FontAsset myFont;
   public float size;

   public Color GetColor( Colorblind colorblindness = Colorblind.BASE)
   {
      return selectedColor.Where(color => color.colorblindness == colorblindness).ToList()[0].selectedColor;
   }
}
