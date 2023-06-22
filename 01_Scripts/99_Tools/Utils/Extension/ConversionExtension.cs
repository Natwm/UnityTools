using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConversionExtension 
{
#region IntTo

    /// <summary>
    /// Converts an int to float
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static float ToFloat(this int value)
    {
        return (float) value;
    }

    /// <summary>
    /// Converts an int to decimal
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static decimal ToDecimal(this int value)
    {
        return (decimal) value;
    }

    /// <summary>
    /// Converts an int to a char
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static char ToChar(this int value)
    {
        return Convert.ToChar(value);
    }

    // IntTo

    #endregion

    #region StringTo

    #region ToInt

    /// <summary>
    /// Converts a string to an int
    /// </summary>
    /// <param name="value">value to convert</param>
    /// <param name="defaultValue">default value if could not convert</param>
    public static int ToInt(this string value, int defaultValue)
    {
        // exit if null
        if (string.IsNullOrEmpty(value))
            return defaultValue;

        // convert
        int rVal;
        return int.TryParse(value, out rVal) ? rVal : defaultValue;
    }

    // ToInt

    #endregion

    #region ToLong

    /// <summary>
    /// Converts a string to an long
    /// </summary>
    /// <param name="value">value to convert</param>
    /// <param name="defaultValue">default value if could not convert</param>
    public static long ToLong(this string value, long defaultValue)
    {
        // exit if null
        if (string.IsNullOrEmpty(value))
            return defaultValue;

        // convert
        long rVal;
        return long.TryParse(value, out rVal) ? rVal : defaultValue;
    }

    // ToLong

    #endregion
    

    #region ToDecimal

    /// <summary>
    /// Converts a string to a decimal
    /// </summary>
    /// <param name="value">value to convert</param>
    /// <param name="defaultValue">default value if could not convert</param>
    public static decimal ToDecimal(this string value, decimal defaultValue)
    {
        // exit if null
        if (string.IsNullOrEmpty(value))
            return defaultValue;

        // convert
        decimal rVal;
        return decimal.TryParse(value, out rVal) ? rVal : defaultValue;
    }

    // ToDecimal

    #endregion

    #region ToDouble

    /// <summary>
    /// Converts a string to a decimal
    /// </summary>
    /// <param name="value">value to convert</param>
    /// <param name="defaultValue">default value if could not convert</param>
    public static double ToDouble(this string value, double defaultValue)
    {
        // exit if null
        if (string.IsNullOrEmpty(value))
            return defaultValue;

        // convert
        double rVal;
        return double.TryParse(value, out rVal) ? rVal : defaultValue;
    }

    // ToDouble

    #endregion

    #region ToFloat

    /// <summary>
    /// Converts a string to a float
    /// </summary>
    /// <param name="value">value to convert</param>
    /// <param name="defaultValue">default value if could not convert</param>
    public static float ToFloat(this string value, float defaultValue)
    {
        // exit if null
        if (string.IsNullOrEmpty(value))
            return defaultValue;

        // convert
        float rVal;
        return float.TryParse(value, out rVal) ? rVal : defaultValue;
    }

    // ToFloat

    #endregion

    #region ToBool

    /// <summary>
    /// Converts a string to a bool
    /// </summary>
    /// <param name="value">value to convert</param>
    /// <param name="defaultValue">default value if could not convert</param>
    public static bool ToBool(this string value, bool defaultValue)
    {
        // exit if null
        if (string.IsNullOrEmpty(value))
            return defaultValue;

        // convert
        bool rVal;
        return bool.TryParse(value, out rVal) ? rVal : defaultValue;
    }

    // ToBool

    #endregion

    #region ToDateTime

    /// <summary>
    /// Converts a string to a datetime
    /// </summary>
    /// <param name="value">value to convert</param>
    /// <param name="defaultValue">default value if could not convert</param>
    public static DateTime ToDateTime(this string value, DateTime defaultValue)
    {
        // exit if null
        if (string.IsNullOrEmpty(value))
            return defaultValue;

        // convert
        DateTime rVal;
        return DateTime.TryParse(value, out rVal) ? rVal : defaultValue;
    }

    // ToDateTime

    #endregion

    // StringTo

    #endregion

    #region ByteTo

    /// <summary>
    /// Converts a byte to an int
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int ToInt(this byte value)
    {
        return Convert.ToInt32(value);
    }

    /// <summary>
    /// Converts a byte to a long
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static long ToLong(this byte value)
    {
        return Convert.ToInt64(value);
    }

    /// <summary>
    /// Converts a byte to a double
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static double ToDouble(this byte value)
    {
        return Convert.ToDouble(value);
    }

    // ByteTo

    #endregion

    #region BytesTo

    /// <summary>
    /// Converts a byte array to a base64 string
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static string ToBase64(this byte[] data)
    {
        return Convert.ToBase64String(data);
    }

    /// <summary>
    /// Converts a bas64 string to a byte array
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static byte[] FromBase64(this string data)
    {
        return Convert.FromBase64String(data);
    }

    // BytesTo

    #endregion

    #region GenericConversions


    #region To

    /// <summary>
    /// Converts to a new type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static T To <T>(this IConvertible obj)
    {
        return (T) Convert.ChangeType(obj, typeof(T));
    }

    // To

    #endregion

    #region ToOrNull

    /// <summary>
    /// Converts to a new object, or returns null if couldn't convert
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static T ToOrNull<T> (this IConvertible obj) where T : class
    {
        try
        {
            return To<T>(obj);
        }
        catch (Exception excep)
        {
            // handle conversion exceptions by returning default
            if (excep is InvalidCastException || excep is ArgumentNullException)
                return null;

            // everything else gets rethrown
            throw;
        }
    }

    // ToOrNull
    #endregion

    // GenericConversions

    #endregion
}
