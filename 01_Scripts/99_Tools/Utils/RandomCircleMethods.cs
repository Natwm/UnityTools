using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomCircleMethods 
{
    /// <summary>
    /// Get a random position in a specific Circle of circle Size radius
    /// </summary>
    /// <param name="circleSize"> the radius of the circle</param>
    /// <returns> A Random point </returns>
    public static Vector2 PointInsideAUnitCircle(float circleSize)
    {
        return Random.insideUnitCircle * circleSize;
    }

    /// <summary>
    /// Get a random position on a specific Circle of circleSize radius
    /// </summary>
    /// <param name="circleSize"> the radius of the circle</param>
    /// <returns> A Random point </returns>
    public static Vector2 PointOnAUnitCircle(float circleSize)
    {
        return Random.onUnitSphere * circleSize;
    }

    /// <summary>
    /// Get a random position in a specific Sphere of circleSize radius
    /// </summary>
    /// <param name="circleSize"> the radius of the Sphere</param>
    /// <returns> A Random point </returns>
    public static Vector2 PointInsideAUnitSphere(float circleSize)
    {
        return Random.insideUnitSphere * circleSize;
    }
}