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
            else if (typeof(T).Equals(typeof(double)))
            {
                var element = (float)Convert.ChangeType(value, typeof(float));

                PlayerPrefs.SetFloat(key, element);
                return true;
            }
            else if (typeof(T).Equals(typeof(string)))
            {
                var element = (string)Convert.ChangeType(value, typeof(string));

                PlayerPrefs.SetString(key, element);
                return true;
            }
            else if (typeof(T).Equals(typeof(bool)))
            {
                var element = (bool)Convert.ChangeType(value, typeof(bool));

                PlayerPrefs.SetInt(key, element ? 1:0);
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
            else if (typeof(T).Equals(typeof(double)))
            {
                value = (T)Convert.ChangeType(PlayerPrefs.GetFloat(key), typeof(T));
                return true;
            }
            else if (typeof(T).Equals(typeof(string)))
            {
                value = (T)Convert.ChangeType(PlayerPrefs.GetString(key), typeof(T));
                return true;
            }
            else if (typeof(T).Equals(typeof(bool)))
            {
                value = (T)Convert.ChangeType(PlayerPrefs.GetInt(key), typeof(T));
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
    /// Delete the value for the selected key
    /// </summary>
    /// <param name="key">The selected key</param>
    /// <returns>Key existed and was deleted</returns>
    public static bool DeleteValue(string key)
    {
        if (!PlayerPrefs.HasKey(key))
        {
            return false;
        }
        PlayerPrefs.DeleteKey(key);
        return true;
    }
    
    /// <summary>
    /// Adds the specified value to the existing value associated with the given key.
    /// If the key does not exist, it creates a new entry with the provided value.
    /// </summary>
    /// <param name="key">The key associated with the value.</param>
    /// <param name="value">The value to be added.</param>
    /// <typeparam name="T">The type of the value (must be int, float, or double).</typeparam>
    /// <exception cref="ArgumentException">Thrown if T is not int, float, or double.</exception>
    public static void AddValue<T>(string key, T value) where T : struct, System.IConvertible
    {
        if (typeof(T) == typeof(int) || typeof(T) == typeof(float) || typeof(T) == typeof(double))
        {
            if (!GetValue<T>(key, out T data))
                SetValue<T>(key, value);
            else
            {
                if (typeof(T) == typeof(int))
                {
                    int result = Convert.ToInt32(value) + Convert.ToInt32(data);
                    SetValue<T>(key, (T)Convert.ChangeType(result, typeof(T)));
                }
                else if (typeof(T) == typeof(float))
                {
                    float result = Convert.ToSingle(value) + Convert.ToSingle(data);
                    SetValue<T>(key, (T)Convert.ChangeType(result, typeof(T)));
                }
                else if (typeof(T) == typeof(double))
                {
                    double result = Convert.ToDouble(value) + Convert.ToDouble(data);
                    SetValue<T>(key, (T)Convert.ChangeType(result, typeof(T)));
                }
            }
        }
        else
        {
            throw new ArgumentException("T must be int, float, or double.");
        }
    }

    /// <summary>
    /// Reduces the specified value from the existing value associated with the given key.
    /// If the key does not exist, it creates a new entry with the provided value (treated as negative).
    /// </summary>
    /// <param name="key">The key associated with the value.</param>
    /// <param name="value">The value to be subtracted.</param>
    /// <typeparam name="T">The type of the value (must be int, float, or double).</typeparam>
    /// <exception cref="ArgumentException">Thrown if T is not int, float, or double.</exception>
    public static void ReduceValue<T>(string key, T value) where T : struct, System.IConvertible
    {
        if (typeof(T) == typeof(int) || typeof(T) == typeof(float) || typeof(T) == typeof(double))
        {
            if (!GetValue<T>(key, out T data))
                SetValue<T>(key, value);
            else
            {
                if (typeof(T) == typeof(int))
                {
                    int result = Convert.ToInt32(value) - Convert.ToInt32(data);
                    SetValue<T>(key, (T)Convert.ChangeType(result, typeof(T)));
                }
                else if (typeof(T) == typeof(float))
                {
                    float result = Convert.ToSingle(value) - Convert.ToSingle(data);
                    SetValue<T>(key, (T)Convert.ChangeType(result, typeof(T)));
                }
                else if (typeof(T) == typeof(double))
                {
                    double result = Convert.ToDouble(value) - Convert.ToDouble(data);
                    SetValue<T>(key, (T)Convert.ChangeType(result, typeof(T)));
                }
            }
        }
        else
        {
            throw new ArgumentException("T must be int, float, or double.");
        }
    }
 
    /// <summary>
    /// Multiplies the specified value with the existing value associated with the given key.
    /// If the key does not exist, it creates a new entry with the provided value.
    /// </summary>
    /// <param name="key">The key associated with the value.</param>
    /// <param name="value">The value to be multiplied.</param>
    /// <typeparam name="T">The type of the value (must be int, float, or double).</typeparam>
    /// <exception cref="ArgumentException">Thrown if T is not int, float, or double.</exception>
    public static void MultiplyValue<T>(string key, T value) where T : struct, System.IConvertible
    {
        if (typeof(T) == typeof(int) || typeof(T) == typeof(float) || typeof(T) == typeof(double))
        {
            if (!GetValue<T>(key, out T data))
                SetValue<T>(key, value);
            else
            {
                if (typeof(T) == typeof(int))
                {
                    int result = Convert.ToInt32(value) * Convert.ToInt32(data);
                    SetValue<T>(key, (T)Convert.ChangeType(result, typeof(T)));
                }
                else if (typeof(T) == typeof(float))
                {
                    float result = Convert.ToSingle(value) * Convert.ToSingle(data);
                    SetValue<T>(key, (T)Convert.ChangeType(result, typeof(T)));
                }
                else if (typeof(T) == typeof(double))
                {
                    double result = Convert.ToDouble(value) * Convert.ToDouble(data);
                    SetValue<T>(key, (T)Convert.ChangeType(result, typeof(T)));
                }
            }
        }
        else
        {
            throw new ArgumentException("T must be int, float, or double.");
        }
    }
    
    /// <summary>
    /// Divides the existing value associated with the given key by the specified value.
    /// If the key does not exist, it creates a new entry with the provided value (treated as the divisor).
    /// </summary>
    /// <param name="key">The key associated with the value.</param>
    /// <param name="value">The value to be used as the divisor.</param>
    /// <typeparam name="T">The type of the value (must be int, float, or double).</typeparam>
    /// <exception cref="ArgumentException">Thrown if T is not int, float, or double.</exception>
    public static void DivideValue<T>(string key, T value) where T : struct, System.IConvertible
    {
        if (typeof(T) == typeof(int) || typeof(T) == typeof(float) || typeof(T) == typeof(double))
        {
            if (!GetValue<T>(key, out T data))
                SetValue<T>(key, value);
            else
            {
                if (typeof(T) == typeof(int))
                {
                    int result = Convert.ToInt32(value) / Convert.ToInt32(data);
                    SetValue<T>(key, (T)Convert.ChangeType(result, typeof(T)));
                }
                else if (typeof(T) == typeof(float))
                {
                    float result = Convert.ToSingle(value) / Convert.ToSingle(data);
                    SetValue<T>(key, (T)Convert.ChangeType(result, typeof(T)));
                }
                else if (typeof(T) == typeof(double))
                {
                    double result = Convert.ToDouble(value) / Convert.ToDouble(data);
                    SetValue<T>(key, (T)Convert.ChangeType(result, typeof(T)));
                }
            }
        }
        else
        {
            throw new ArgumentException("T must be int, float, or double.");
        }
    }
    
    public static void SetValueIfGreater<T>(string key, T value) where T : struct, System.IConvertible
    {
        if (typeof(T) == typeof(int) || typeof(T) == typeof(float) || typeof(T) == typeof(double))
        {
            if (!GetValue<T>(key, out T data))
                SetValue<T>(key, value);
            else
            {
                if (typeof(T) == typeof(int))
                {
                    int result = Convert.ToInt32(value);
                    int dataValue = Convert.ToInt32(data);
                    if(dataValue < result)
                        SetValue<T>(key, (T)Convert.ChangeType(result, typeof(T)));
                    return;
                }
                else if (typeof(T) == typeof(float))
                {
                    float resultFloat = Convert.ToSingle(value);
                    float fDataValue = Convert.ToSingle(data);
                    if(fDataValue < resultFloat)
                        SetValue<T>(key, (T)Convert.ChangeType(resultFloat, typeof(T)));
                    return;
                }
                else if (typeof(T) == typeof(double))
                {
                    double resultFloat = Convert.ToDouble(value);
                    double dDataValue = Convert.ToDouble(data);
                    if(dDataValue < resultFloat)
                        SetValue<T>(key, (T)Convert.ChangeType(resultFloat, typeof(T)));
                    return;
                }
            }
        }
        else
        {
            throw new ArgumentException("T must be int, float, or double.");
        }
    }
}