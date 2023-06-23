using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnglesTools
{
    /// <summary>
    /// The circle constant. Defined as the circumference of a circle divided by its radius. Equivalent to 2*pi
    /// </summary>
    public const float TAU = 6.28318530717959f;

    /// <summary>
    /// An obscure circle constant. Defined as the circumference of a circle divided by its diameter. Equivalent to 0.5*tau
    /// </summary>
    public const float PI = 3.14159265359f;


    /// <summary>
    /// Convert a angle from Degree To Radians
    /// </summary>
    /// <param name="degree"> the angle in degree</param>
    /// <returns> the value of the angle in radian </returns>
    public static float ConvertDegreeToRadians(float degree)
    {
        return degree * Mathf.Deg2Rad;
    }

    /// <summary>
    /// Convert a angle from Radians to Degree
    /// </summary>
    /// <param name="radians"> the angle in radian </param>
    /// <returns> the value of the angle in degree </returns>
    public static float ConvertRadiansToDegree(float radians)
    {
        return radians * Mathf.Rad2Deg;
    }

    /// <summary>
    /// Get the position with a decal of angle degree
    /// </summary>
    /// <param name="pos"> A position </param>
    /// <param name="angle"> the angle decal </param>
    /// <returns>The new position</returns>
    public static Vector3 GetDecalByAngle(Vector3 pos, float angle)
    {
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        return rotation * pos;
    }

    /// <summary>
    ///  Return the rotation of angle degrees
    /// </summary>
    /// <param name="angle"> the angle of rotation </param>
    /// <returns> </returns>
    public static Quaternion GetDecalRotation(float angle)
    {
        Quaternion rotation = Quaternion.identity;
        return Quaternion.Euler(0, 0, angle);
    }

    /// <summary>
    /// Invert the rotation of an object
    /// </summary>
    /// <param name="angle">the angle of rotation</param>
    /// <returns></returns>
    public static Quaternion GetInverseStarDecalRotation(float angle)
    {
        Quaternion rotation = Quaternion.identity;
        return Quaternion.Euler(0, 0, -angle);
    }

    /// <summary>
    /// Get the new position of an object after rotate this object from an specific rotation
    /// </summary>
    /// <param name="newPos">Current position of the object</param>
    /// <param name="rotation">Angle of rotation the user want to apply on the object</param>
    /// <returns>The new position of the object after its rotation</returns>
    public static Vector3 GetDecalPositionByVector3(Vector3 newPos, Quaternion rotation)
    {
        return rotation * newPos;
    }

    /// <summary>
    /// Get the angle between two elements
    /// </summary>
    /// <param name="objectA">Transform of the first object</param>
    /// <param name="objectB">Transform of the second object</param>
    /// <returns>the angle between those two elements</returns>
    public static float AngleBtwElement(Transform objectA, Transform objectB)
    {
        Vector3 dirTowardsOtherObject = (objectA.position - objectB.position).normalized;

        float dotProduct = Vector3.Dot(dirTowardsOtherObject, objectB.forward);

        return Mathf.Acos(dotProduct) * Mathf.Rad2Deg;
    }

    /// <summary>Returns the direction of the input angle, as a normalized vector</summary>
    /// <param name="aRad">The input angle, in radians</param>
    /// <seealso cref="MathfsExtensions.Angle"/>
    public static Vector2 AngToDir(float aRad) => new Vector2(Mathf.Cos(aRad), Mathf.Sin(aRad));

    /// <summary>Returns the angle of the input vector, in radians. You can also use <c>myVector.Angle()</c></summary>
    /// <param name="vec">The vector to get the angle of. It does not have to be normalized</param>
    /// <seealso cref="MathfsExtensions.Angle"/>
    public static float DirToAng(Vector2 vec) => Mathf.Atan2(vec.y, vec.x);

    /// <summary>Returns a 2D orientation from a vector, representing the X axis</summary>
    /// <param name="v">The direction to create a 2D orientation from (does not have to be normalized)</param>
    public static Quaternion DirToOrientation(Vector2 v)
    {
        v.Normalize();
        v.x += 1;
        v.Normalize();
        return new Quaternion(0, 0, v.y, v.x);
    }

    /// <summary>Returns the signed angle between <c>a</c> and <c>b</c>, in the range -tau/2 to tau/2 (-pi to pi)</summary>
    public static float SignedAngle(Vector2 a, Vector2 b) =>
        AngleBetween(a, b) * Mathf.Sign(VectorsMethods.Determinant(a, b)); // -tau/2 to tau/2

    /// <summary>Returns the shortest angle between <c>a</c> and <c>b</c>, in the range 0 to tau/2 (0 to pi)</summary>
    public static float AngleBetween(Vector2 a, Vector2 b) =>
        Mathf.Acos(MathfExtensions.ClampNeg1to1(Vector2.Dot(a.normalized, b.normalized)));

    /// <inheritdoc cref="AngleBetween(Vector2,Vector2)"/>
    public static float AngleBetween(Vector3 a, Vector3 b) =>
        Mathf.Acos(MathfExtensions.ClampNeg1to1(Vector3.Dot(a.normalized, b.normalized)));

    /// <summary>Returns the clockwise angle between <c>from</c> and <c>to</c>, in the range 0 to tau (0 to 2*pi)</summary>
    public static float AngleFromToCW(Vector2 from, Vector2 to) => VectorsMethods.Determinant(from, to) < 0
        ? AngleBetween(from, to)
        : TAU - AngleBetween(from, to);

    /// <summary>Returns the counterclockwise angle between <c>from</c> and <c>to</c>, in the range 0 to tau (0 to 2*pi)</summary>
    public static float AngleFromToCCW(Vector2 from, Vector2 to) => VectorsMethods.Determinant(from, to) > 0
        ? AngleBetween(from, to)
        : TAU - AngleBetween(from, to);
    
    // Méthode pour obtenir l'angle entre deux vecteurs en degrés
    public static float AngleBetweenVectors(this Transform transform, Vector3 vector1, Vector3 vector2) {
        return Vector3.Angle(vector1, vector2);
    }

    // Méthode pour obtenir l'angle d'inclinaison d'un Transform par rapport à un plan horizontal
    public static float GetInclinationAngle(this Transform transform) {
        Vector3 up = transform.up;
        return Mathf.Rad2Deg * Mathf.Acos(up.y);
    }

    // Méthode pour obtenir l'angle de direction d'un Transform par rapport à un plan horizontal
    public static float GetDirectionAngle(this Transform transform) {
        Vector3 forward = transform.forward;
        forward.y = 0f;
        forward = forward.normalized;
        float angle = Mathf.Atan2(forward.z, forward.x);
        angle *= Mathf.Rad2Deg;
        if (angle < 0f) angle += 360f;
        return angle;
    }

    // Méthode pour obtenir l'angle de direction d'un Transform par rapport à un autre Transform
    public static float GetAngleToTarget(this Transform transform, Transform target) {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        if (angle < 0f) angle += 360f;
        return angle;
    }
    
    // Méthode pour obtenir l'angle entre deux vecteurs en degrés
    public static float GetAngleBetweenVectors(this Vector3 vector1, Vector3 vector2) {
        float dotProduct = Vector3.Dot(vector1.normalized, vector2.normalized);
        float angle = Mathf.Acos(dotProduct);
        return ConvertRadiansToDegree(angle);
    }

    // Méthode pour obtenir l'angle entre deux points en degrés
    public static float GetAngleBetweenPoints(this Vector2 point1, Vector2 point2) {
        Vector2 direction = point2 - point1;
        float angle = Mathf.Atan2(direction.y, direction.x);
        return ConvertRadiansToDegree(angle);
    }

    // Méthode pour obtenir le vecteur direction d'un angle en degrés
    public static Vector3 GetDirectionFromAngle(this float angle) {
        float radians = ConvertDegreeToRadians(angle);
        Vector3 direction = new Vector3(Mathf.Cos(radians), 0f, Mathf.Sin(radians));
        return direction.normalized;
    }

    // Méthode pour obtenir l'angle entre deux Transform en degrés
    public static float GetAngleBetweenTransforms(this Transform transform1, Transform transform2) {
        Vector3 direction = transform2.position - transform1.position;
        float angle = Mathf.Atan2(direction.x, direction.z);
        return ConvertRadiansToDegree(angle);
    }

}