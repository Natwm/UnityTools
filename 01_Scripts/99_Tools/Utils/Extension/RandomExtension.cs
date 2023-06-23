using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomExtension 
{
    public static float GetRandomValueBTW(int valueA, int valueB)
    {
        if (valueA > valueB)
        {
            Debug.LogError("A can't be smaller than B");
            return -1;
        }
        
        return Random.Range(valueA, valueB);
    }

    public static float GetRandomPositifWithMax(int maxValue)
    {
        return Random.Range(0, maxValue);
    }
    
    public static float GetRandomValueWhitBorne(int value)
    {
        return Random.Range(-value, value);
    }

    public static Vector3 GetRandomPositionIn3D()
    {
        return new Vector3(
            Random.Range(-100, 100),
            Random.Range(-100, 100),
            Random.Range(-100, 100)
        );
    }
    
    public static Vector2 GetRandomPositionIn2D()
    {
        return new Vector2(
            Random.Range(-100, 100),
            Random.Range(-100, 100)
        );
    }
    
    public static float NewRandomNumber(float lastNumber)
    {
        var randomNumber = Random.Range(0, 10);
        if (randomNumber == lastNumber)
        {
            randomNumber = Random.Range(0, 10);
        }
        return randomNumber;
    }
    
    public static float NewRandomNumber(float lastNumber, int maxAttempts)
    {
        float randomNumber = -1;
        for(int i=0; randomNumber == lastNumber && i < maxAttempts; i++)
        {
            randomNumber = Random.Range(0, 10);
        }
        return randomNumber;
    }
    
    public static Quaternion GetRandomRotation()
    {
        return Random.rotation;
    }

    public static Color GetRandomColor()
    {
        return Random.ColorHSV();
    }

}
