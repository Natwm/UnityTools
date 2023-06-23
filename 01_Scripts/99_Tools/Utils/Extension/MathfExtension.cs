using System;
using System.Linq;
using UnityEngine;

public static class MathfExtensions
{
    /// <summary>
    /// Clamp an angle between two value
    /// </summary>
    /// <param name="angle">the rurrent value of the angle</param>
    /// <param name="min">min value of the angle</param>
    /// <param name="max">max value of the angle</param>
    /// <returns></returns>
    public static float ClampAngle(float angle, float min, float max)
    {
        while (angle < -360f || angle > 360f)
        {
            if (angle < -360f)
            {
                angle += 360f;
            }
            else if (angle > 360f)
            {
                angle -= 360f;
            }
        }

        return Mathf.Clamp(angle, min, max);
    }

    
    public static float ApplyGravity(float speed, float gravity, float maxSpeed)
    {
        return Mathf.Max(-maxSpeed, speed - gravity * Time.deltaTime);
    }

    public static float AccelerateSpeed(float speed, float acceleration, float maxSpeed, bool negative)
    {
        if (negative)
        {
            return Mathf.Max(-maxSpeed, speed - acceleration * Time.deltaTime);
        }

        return Mathf.Min(maxSpeed, speed + acceleration * Time.deltaTime);
    }

    public static float DecelerateSpeed(float speed, float deceleration)
    {
        if (speed > 0f)
        {
            return Mathf.Max(0f, speed - deceleration * Time.deltaTime);
        }

        return Mathf.Min(0f, speed + deceleration * Time.deltaTime);
    }

    #region Min & Max

    /// <summary>
    /// Return the min value between two float variables
    /// </summary>
    /// <param name="a">First variable</param>
    /// <param name="b">Second variable</param>
    /// <returns>return the min value from the param</returns>
    public static float Min(float a, float b) => a < b ? a : b;

    /// <summary>
    /// Return the min value between three float variables
    /// </summary>
    /// <param name="a">First variable</param>
    /// <param name="b">Second variable</param>
    /// <param name="c">Third variable</param>
    /// <returns></returns>
    public static float Min(float a, float b, float c) => Min(Min(a, b), c);

    /// <summary>
    /// Return the min value between four float variables
    /// </summary>
    /// <param name="a">First variable</param>
    /// <param name="b">Second variable</param>
    /// <param name="c">Third variable</param>
    /// <param name="d">forth variable</param>
    /// <returns></returns>
    public static float Min(float a, float b, float c, float d) => Min(Min(a, b), Min(c, d));

    /// <summary>
    ///  Return the max value between two float variables
    /// </summary>
    /// <param name="a">First variable</param>
    /// <param name="b">Second variable</param>
    /// <returns></returns>
    public static float Max(float a, float b) => a > b ? a : b;

    /// <summary>
    ///  Return the max value between three float variables
    /// </summary>
    /// <param name="a">First variable</param>
    /// <param name="b">Second variable</param>
    /// <param name="c">Third variable</param>
    /// <returns></returns>
    public static float Max(float a, float b, float c) => Max(Max(a, b), c);

    /// <summary>
    ///  Return the max value between four float variables
    /// </summary>
    /// <param name="a">First variable</param>
    /// <param name="b">Second variable</param>
    /// <param name="c">Third variable</param>
    /// <param name="d">forth variable</param>
    /// <returns></returns>
    public static float Max(float a, float b, float c, float d) => Max(Max(a, b), Max(c, d));


    /// <summary>
    /// Return the min value between two int variables
    /// </summary>
    /// <param name="a">First variable</param>
    /// <param name="b">Second variable</param>
    /// <returns></returns>
    public static int Min(int a, int b) => a < b ? a : b;

    /// <summary>
    /// Return the min value between three int variables
    /// </summary>
    /// <param name="a">First variable</param>
    /// <param name="b">Second variable</param>
    /// <param name="c">Third variable</param>
    /// <returns></returns>
    public static int Min(int a, int b, int c) => Min(Min(a, b), c);

    /// <summary>
    /// Return the min value between four int variables
    /// </summary>
    /// <param name="a">First variable</param>
    /// <param name="b">Second variable</param>
    /// <param name="c">Third variable</param>
    /// <param name="d">forth variable</param>
    /// <returns></returns>
    public static int Min(int a, int b, int c, int d) => Min(Min(a, b), Min(c, d));

    /// <summary>
    /// Return the max value between two int variables
    /// </summary>
    /// <param name="a">First variable</param>
    /// <param name="b">Second variable</param>
    /// <returns></returns>
    public static int Max(int a, int b) => a > b ? a : b;

    /// <summary>
    /// Return the max value between three int variables
    /// </summary>
    /// <param name="a">First variable</param>
    /// <param name="b">Second variable</param>
    /// <param name="c">Third variable</param>
    /// <returns></returns>
    public static int Max(int a, int b, int c) => Max(Max(a, b), c);

    /// <summary>
    /// Return the max value between four int variables
    /// </summary>
    /// <param name="a">First variable</param>
    /// <param name="b">Second variable</param>
    /// <param name="c">Third variable</param>
    /// <param name="d">forth variable</param>
    /// <returns></returns>
    public static int Max(int a, int b, int c, int d) => Max(Max(a, b), Max(c, d));

    /// <summary>
    /// Return the min float value from a list
    /// </summary>
    /// <param name="values">List of value</param>
    /// <returns>The min value from this list</returns>
    public static float Min(float[] values) => values.Min();

    /// <summary>
    /// Return the max float value from a list
    /// </summary>
    /// <param name="values">List of value</param>
    /// <returns>The min value from this list</returns>
    public static float Max(float[] values) => values.Max();

    /// <summary>
    /// Return the min int value from a list
    /// </summary>
    /// <param name="values">List of value</param>
    /// <returns>The min value from this list</returns>
    public static int Min(int[] values) => values.Min();

    /// <summary>
    /// Return the max int value from a list
    /// </summary>
    /// <param name="values">List of value</param>
    /// <returns>The min value from this list</returns>
    public static int Max(int[] values) => values.Max();

    /// <summary>
    /// Return the min float value from a vector2
    /// </summary>
    /// <param name="v">Selected Vector</param>
    /// <returns>The min value from this vector</returns>
    public static float Min(Vector2 v) => Min(v.x, v.y);

    /// <summary>
    /// Return the max float value from a vector2
    /// </summary>
    /// <param name="v">Selected Vector</param>
    /// <returns>The min value from this vector</returns>
    public static float Max(Vector2 v) => Max(v.x, v.y);

    /// <summary>
    /// Return the min float value from a vector3
    /// </summary>
    /// <param name="v">Selected Vector</param>
    /// <returns>The min value from this vector</returns>
    public static float Min(Vector3 v) => Min(v.x, v.y, v.z);

    /// <summary>
    /// Return the max float value from a vector2
    /// </summary>
    /// <param name="v">Selected Vector</param>
    /// <returns>The min value from this vector</returns>
    public static float Max(Vector3 v) => Max(v.x, v.y, v.z);

    /// <summary>
    /// Return the min float value from a vector4
    /// </summary>
    /// <param name="v">Selected Vector</param>
    /// <returns>The min value from this vector</returns>
    public static float Min(Vector4 v) => Min(v.x, v.y, v.z, v.w);

    /// <summary>
    /// Return the min float value from a vector4
    /// </summary>
    /// <param name="v">Selected Vector</param>
    /// <returns>The min value from this vector</returns>
    public static float Max(Vector4 v) => Max(v.x, v.y, v.w);

    #endregion

    #region Value & Vector interpolation

    /// <summary>
    /// Blends between a and b, based on the t-value. When t = 0 it returns a, when t = 1 it returns b, and any values between are blended linearly
    /// </summary>
    /// <param name="a">The start value, when t is 0</param>
    /// <param name="b">The start value, when t is 1</param>
    /// <param name="t">The t-value from 0 to 1 representing position along the lerp</param>
    public static float Lerp(float a, float b, float t) => (1f - t) * a + t * b;

    /// <summary>
    /// Blends between a and b of each component, based on the t-value of each component in the t-vector. When t = 0 it returns a, when t = 1 it returns b, and any values between are blended linearly
    /// </summary>
    /// <param name="a">The start value, when t is 0</param>
    /// <param name="b">The start value, when t is 1</param>
    /// <param name="t">The t-values from 0 to 1 representing position along the lerp</param>
    public static Vector2 Lerp(Vector2 a, Vector2 b, Vector2 t) =>
        new Vector2(Lerp(a.x, b.x, t.x), Lerp(a.y, b.y, t.y));

    /// <inheritdoc cref="Mathfs.Lerp(Vector2,Vector2,Vector2)"/>
    public static Vector3 Lerp(Vector3 a, Vector3 b, Vector3 t) =>
        new Vector3(Lerp(a.x, b.x, t.x), Lerp(a.y, b.y, t.y), Lerp(a.z, b.z, t.z));

    /// <inheritdoc cref="Mathfs.Lerp(Vector2,Vector2,Vector2)"/>
    public static Vector4 Lerp(Vector4 a, Vector4 b, Vector4 t) => new Vector4(Lerp(a.x, b.x, t.x), Lerp(a.y, b.y, t.y),
        Lerp(a.z, b.z, t.z), Lerp(a.w, b.w, t.w));

    /// <summary>
    /// Linearly blends between two rectangles, moving and resizing from the center. Note: this lerp is unclamped
    /// </summary>
    /// <param name="a">The start value, when t is 0</param>
    /// <param name="b">The start value, when t is 1</param>
    /// <param name="t">The t-values from 0 to 1 representing position along the lerp</param>
    public static Rect Lerp(Rect a, Rect b, float t)
    {
        Vector2 center = Vector2.LerpUnclamped(a.center, b.center, t);
        Vector2 size = Vector2.LerpUnclamped(a.size, b.size, t);
        return new Rect(default, size) { center = center };
    }

    /// <summary>
    /// Given a value between a and b, returns its normalized location in that range, as a t-value (interpolant) from 0 to 1
    /// </summary>
    /// <param name="a">The start of the range, where it would return 0</param>
    /// <param name="b">The end of the range, where it would return 1</param>
    /// <param name="value">A value between a and b. Note: values outside this range are still valid, and will be extrapolated</param>
    public static float InverseLerp(float a, float b, float value) => (value - a) / (b - a);

    /// <summary>
    /// Given a value between a and b, returns its normalized location in that range, as a t-value (interpolant) from 0 to 1.
    /// This safe version returns 0 if a == b, instead of a division by zero
    /// </summary>
    /// <param name="a">The start of the range, where it would return 0</param>
    /// <param name="b">The end of the range, where it would return 1</param>
    /// <param name="value">A value between a and b. Note: values outside this range are still valid, and will be extrapolated</param>
    public static float InverseLerpSafe(float a, float b, float value)
    {
        float den = b - a;
        if (den == 0)
            return 0;
        return (value - a) / den;
    }

    /// <summary>
    /// Given values between a and b in each component, returns their normalized locations in the given ranges, as t-values (interpolants) from 0 to 1
    /// </summary>
    /// <param name="a">The start of the ranges, where it would return 0</param>
    /// <param name="b">The end of the ranges, where it would return 1</param>
    /// <param name="v">A value between a and b. Note: values outside this range are still valid, and will be extrapolated</param>
    public static Vector2 InverseLerp(Vector2 a, Vector2 b, Vector2 v) =>
        new Vector2((v.x - a.x) / (b.x - a.x), (v.y - a.y) / (b.y - a.y));

    /// <inheritdoc cref="Mathfs.InverseLerp(Vector2,Vector2,Vector2)"/>
    public static Vector3 InverseLerp(Vector3 a, Vector3 b, Vector3 v) => new Vector3((v.x - a.x) / (b.x - a.x),
        (v.y - a.y) / (b.y - a.y), (v.z - a.z) / (b.z - a.z));

    /// <inheritdoc cref="Mathfs.InverseLerp(Vector2,Vector2,Vector2)"/>
    public static Vector4 InverseLerp(Vector4 a, Vector4 b, Vector4 v) => new Vector4((v.x - a.x) / (b.x - a.x),
        (v.y - a.y) / (b.y - a.y), (v.z - a.z) / (b.z - a.z), (v.w - a.w) / (b.w - a.w));

    #endregion
    
    /// <summary>Clamps the value between -1 and 1</summary>
    public static float ClampNeg1to1( float value ) => value < -1f ? -1f : value > 1f ? 1f : value;
    
    // <summary>Repeats the given value in the interval specified by length</summary>
    public static float Repeat( float value, float length ) => Mathf.Clamp( value - Mathf.Floor( value / length ) * length, 0.0f, length );
}