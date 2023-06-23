using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BoolExtension 
{
    /// <summary>
    /// Toggles the given boolean item and returns the toggled value.
    /// </summary>
    /// <param name="item">Item to be toggled.</param>
    /// <returns>The toggled value.</returns>
    public static bool Toggle(this bool item)
    {
        return !item;
    }
    
    /// <summary>
    /// Converts the given boolean value to integer.
    /// </summary>
    /// <param name="item">The boolean variable.</param>
    /// <returns>Returns 1 if true , 0 otherwise.</returns>
    public static int ToInt(this bool item)
    {
        return item ? 1 : 0;
    }
    
    /// <summary>
    /// Returns "Yes" or "No" based on the given boolean value.
    /// </summary>
    /// <param name="item">The boolean value.</param>
    /// <returns>Yes if the given value is true otherwise No.</returns>
    public static string ToYesNo(this bool item)
    {
        return item? "Yes" : "No";
    }
}
