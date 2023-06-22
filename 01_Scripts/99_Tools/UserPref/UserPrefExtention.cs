using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Extension for the UserPref extension
/// </summary>
public static class UserPrefExtention
{
    /// <summary>
    /// Set a player pref
    /// </summary>
    /// <param name="key">The selected key</param>
    /// <param name="value">The value of the selected key</param>
    /// <typeparam name="T">This parameter can be a Int, a Float, a bool or a string</typeparam>
    /// <returns>return if the assignment have worked</returns>
    public static bool SetValue<T>(string key, T value)
    {
        try
        {
            if (typeof(T).Equals(typeof(float)))
            {
                var element = (float)Convert.ChangeType(value, typeof(float));

                PlayerPrefs.SetFloat(key, element);
                return true;
            }
            else if (typeof(T).Equals(typeof(int)))
            {
                var element = (int)Convert.ChangeType(value, typeof(int));

                PlayerPrefs.SetInt(key, element);
                return true;
            }
            else if (typeof(T).Equals(typeof(string)))
            {
                var element = (string)Convert.ChangeType(value, typeof(string));

                PlayerPrefs.SetString(key, element);
                return true;
            }

            return false;
        }
        catch
        {
            Debug.LogError("The object isn't a Button element");
            return false;
        }
    }

    /// <summary>
    /// Get the value from the selected key
    /// </summary>
    /// <param name="key">The selected key</param>
    /// <param name="value">The value of the selected key</param>
    /// <typeparam name="T">This parameter can be a Int, a Float, a bool or a string</typeparam>
    /// <returns>Get the value from the selected key</returns>
    public static bool GetValue<T>(string key, out T value)
    {
        value = default;

        if (!PlayerPrefs.HasKey(key))
        {
            return false;
        }

        try
        {
            if (typeof(T).Equals(typeof(float)))
            {
                value = (T)Convert.ChangeType(PlayerPrefs.GetFloat(key), typeof(T));
                return true;
            }
            else if (typeof(T).Equals(typeof(int)))
            {
                value = (T)Convert.ChangeType(PlayerPrefs.GetInt(key), typeof(T));
                return true;
            }
            else if (typeof(T).Equals(typeof(string)))
            {
                value = (T)Convert.ChangeType(PlayerPrefs.GetString(key), typeof(T));
                return true;
            }

            return false;
        }
        catch
        {
            Debug.LogError("The object isn't a Button element");
            return false;
        }
    }
}