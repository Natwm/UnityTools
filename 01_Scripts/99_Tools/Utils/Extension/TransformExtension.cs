using UnityEngine;

/// <summary>
/// Script extension of the Transform Class.
/// </summary>
public static class TransformExtension
{
	/// <summary>
	/// Reset the transform of a GameObject
	/// </summary>
	/// <param name="t">Selected transform</param>
	public static void ResetTransform(this Transform t)
	{
		t.position = Vector3.zero;
		t.localPosition = Vector3.one;
		t.rotation = Quaternion.identity;
	}
    
    #region On X vector
    /// <summary>
	/// Create a new Transform from the given Transform with a new value for its x coordinate.
	/// </summary>
	/// <param name="t">The source Transform</param>
	/// <param name="x">The new x value</param>
	/// <returns>A new Transform</returns>
    public static Transform ChangeX( this Transform t, float x)
    {
        t.position = new Vector3(x, t.position.y, t.position.z);
        return t;
    }

    /// <summary>
	/// Create a new Transform from the given Transform with a value added to its x coordinate.
	/// </summary>
	/// <param name="t">The source Transform</param>
	/// <param name="x">The value added to the x coordinate</param>
	/// <returns>A new Transform</returns>
    public static Transform IncreaseX(this Transform t, float x)
    {
        t.position = new Vector3(t.position.x + x, t.position.y, t.position.z);
        return t;
    }
    /// <summary>
    /// Create a new Transform from the given Transform with a value reduced to its x coordinate.
    /// </summary>
    /// <param name="t">The source Transform</param>
    /// <param name="x">The value added to the x coordinate</param>
    /// <returns>A new Transform</returns>
    public static Transform DecreaseX(this Transform t, float x)
    {
	    t.position = new Vector3(t.position.x - x, t.position.y, t.position.z);
	    return t;
    }

    /// <summary>
	/// Create a new Transform from the given Transform with its x coordinate multiplied.
	/// </summary>
	/// <param name="t">The source Transform</param>
	/// <param name="x">The multiplier value</param>
	/// <returns>A new Transform</returns>
    public static Transform multiplyX(this Transform t, float x)
    {
        t.position = new Vector3(t.position.x * x, t.position.y, t.position.z);
        return t;
    }
    
    /// <summary>
    /// Create a new Transform from the given Transform with its x coordinate multiplied.
    /// </summary>
    /// <param name="t">The source Transform</param>
    /// <param name="x">The divider value</param>
    /// <returns>A new Transform</returns>
    public static Transform DivideX(this Transform t, float x)
    {
	    t.position = new Vector3(t.position.x / x, t.position.y, t.position.z);
	    return t;
    }

    #endregion

    #region On Y vector
    /// <summary>
	/// Create a new Transform from the given Transform with a new value for its y coordinate.
	/// </summary>
	/// <param name="t">The source Transform</param>
	/// <param name="y">The new y value</param>
	/// <returns>A new Transform</returns>
    public static Transform ChangeY(this Transform t, float y)
    {
        t.position = new Vector3(t.position.x,y, t.position.z);
        return t;
    }

    /// <summary>
	/// Create a new Transform from the given Transform with a value added to its y coordinate.
	/// </summary>
	/// <param name="t">The source Transform</param>
	/// <param name="y">The value added to the y coordinate</param>
	/// <returns>A new Transform</returns>
    public static Transform IncreaseY(this Transform t, float y)
    {
        t.position = new Vector3(t.position.x, t.position.y + y, t.position.z);
        return t;
    }
    
    /// <summary>
    /// Create a new Transform from the given Transform with a value reduced to its y coordinate.
    /// </summary>
    /// <param name="t">The source Transform</param>
    /// <param name="y">The value added to the y coordinate</param>
    /// <returns>A new Transform</returns>
    public static Transform DecreaseY(this Transform t, float y)
    {
	    t.position = new Vector3(t.position.x, t.position.y - y, t.position.z);
	    return t;
    }

    /// <summary>
	/// Create a new Transform from the given Transform with its y coordinate multiplied.
	/// </summary>
	/// <param name="t">The source Transform</param>
	/// <param name="y">The multiplier value</param>
	/// <returns>A new Transform</returns>
    public static Transform multiplyY(this Transform t, float y)
    {
        t.position = new Vector3(t.position.x, t.position.y * y, t.position.z);
        return t;
    }
    
    /// <summary>
    /// Create a new Transform from the given Transform with its x coordinate multiplied.
    /// </summary>
    /// <param name="t">The source Transform</param>
    /// <param name="y">The divider value</param>
    /// <returns>A new Transform</returns>
    public static Transform DivideY(this Transform t, float y)
    {
	    t.position = new Vector3(t.position.x, t.position.y / y, t.position.z);
	    return t;
    }

    #endregion

    #region On Z vector
    /// <summary>
	/// Create a new Transform from the given Transform with a new value for its z coordinate.
	/// </summary>
	/// <param name="t">The source Transform</param>
	/// <param name="z">The new z value</param>
	/// <returns>A new Transform</returns>
    public static Transform ChangeZ(this Transform t, float z)
    {
        t.position = new Vector3(t.position.x, t.position.y, z);
        return t;
    }

    /// <summary>
	/// Create a new Transform from the given Transform with a value added to its z coordinate.
	/// </summary>
	/// <param name="t">The source Transform</param>
	/// <param name="z">The value added to the z coordinate</param>
	/// <returns>A new Transform</returns>
    public static Transform IncreaseZ(this Transform t, float z)
    {
        t.position = new Vector3(t.position.x, t.position.y, t.position.z + z);
        return t;
    }
    
    /// <summary>
    /// Create a new Transform from the given Transform with a value reduce to its z coordinate.
    /// </summary>
    /// <param name="t">The source Transform</param>
    /// <param name="z">The value added to the z coordinate</param>
    /// <returns>A new Transform</returns>
    public static Transform DecreaseZ(this Transform t, float z)
    {
	    t.position = new Vector3(t.position.x, t.position.y, t.position.z - z);
	    return t;
    }

    /// <summary>
	/// Create a new Transform from the given Transform with its z coordinate multiplied.
	/// </summary>
	/// <param name="t">The source Transform</param>
	/// <param name="z">The multiplier value</param>
	/// <returns>A new Transform</returns>
    public static Transform multiplyZ(this Transform t, float z)
    {
        t.position = new Vector3(t.position.x, t.position.y, t.position.z * z);
        return t;
    }
    
    /// <summary>
    /// Create a new Transform from the given Transform with its x coordinate multiplied.
    /// </summary>
    /// <param name="t">The source Transform</param>
    /// <param name="z">The divider value</param>
    /// <returns>A new Transform</returns>
    public static Transform DivideZ(this Transform t, float z)
    {
	    t.position = new Vector3(t.position.x, t.position.y, t.position.z / z);
	    return t;
    }

    #endregion
    
    /// <summary>
    /// Check if two objects if facing
    /// </summary>
    /// <param name="objectA">transform of the first gameObject</param>
    /// <param name="objectB">transform of the second gameObject</param>
    /// <returns>If those transform are facing.</returns>
    public static bool IsTwoVectorIsFacing(Transform objectA, Transform objectB, float threshold = 0.1f)
    {
	    Vector3 dirTowardsOtherObject = (objectA.position - objectB.position).normalized;

	    float dotProduct = Vector3.Dot(dirTowardsOtherObject,objectB.forward );
	    
	    return dotProduct > threshold;
    }

    // Methode pour faire pivoter un Transform vers un point de l'espace donné avec une vitesse donnée
    public static void LookAtPoint(this Transform transform, Vector3 targetPoint, float speed) {
	    Vector3 direction = targetPoint - transform.position;
	    Quaternion rotation = Quaternion.LookRotation(direction);
	    transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

    // Methode pour faire pivoter un Transform vers un autre Transform avec une vitesse donnée
    public static void LookAtTransform(this Transform transform, Transform targetTransform, float speed) {
	    Vector3 direction = targetTransform.position - transform.position;
	    Quaternion rotation = Quaternion.LookRotation(direction);
	    transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
    
    // Methode pour attacher un Transform à un autre Transform en maintenant sa position relative
    public static void AttachToTransform(this Transform transform, Transform parentTransform) {
	    Vector3 positionOffset = transform.position - parentTransform.position;
	    Quaternion rotationOffset = Quaternion.Inverse(parentTransform.rotation) * transform.rotation;
	    transform.parent = parentTransform;
	    transform.localRotation = rotationOffset;
	    transform.localPosition = positionOffset;
    }

    // Methode pour détacher un Transform de son parent et le laisser à sa position relative actuelle
    public static void DetachFromParent(this Transform transform) {
	    Transform parent = transform.parent;
	    if (parent != null) {
		    Vector3 position = transform.position;
		    Quaternion rotation = transform.rotation;
		    transform.parent = null;
		    transform.position = position;
		    transform.rotation = rotation;
	    }
    }
    
    // Méthode pour obtenir la distance entre deux Transforms
    public static float DistanceTo(this Transform transform, Transform otherTransform) {
	    return Vector3.Distance(transform.position, otherTransform.position);
    }

    // Méthode pour déplacer un Transform vers un autre Transform avec une vitesse donnée
    public static void MoveTowardsTransform(this Transform transform, Transform targetTransform, float speed) {
	    transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, speed * Time.deltaTime);
    }

    // Méthode pour faire suivre un Transform à un autre Transform en gardant une distance constante
    public static void FollowTransform(this Transform transform, Transform targetTransform, float distance) {
	    Vector3 targetPosition = targetTransform.position - targetTransform.forward * distance;
	    transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
	    transform.LookAt(targetTransform);
    }
    
    // Méthode pour faire suivre un Transform à un autre Transform avec une vitesse donnée
    public static void FollowTransformWithSpeed(this Transform transform, Transform targetTransform, float speed) {
	    Vector3 targetPosition = targetTransform.position;
	    Vector3 direction = targetPosition - transform.position;
	    transform.position += direction.normalized * speed * Time.deltaTime;
	    transform.LookAt(targetTransform);
    }

    // Méthode pour obtenir l'angle entre la direction d'un Transform et un autre point de l'espace
    public static float AngleTo(this Transform transform, Vector3 targetPoint) {
	    Vector3 direction = targetPoint - transform.position;
	    return Vector3.Angle(transform.forward, direction);
    }

    // Méthode pour obtenir l'angle entre la direction d'un Transform et un autre Transform
    public static float AngleTo(this Transform transform, Transform targetTransform) {
	    Vector3 direction = targetTransform.position - transform.position;
	    return Vector3.Angle(transform.forward, direction);
    }
    


    // Méthode pour faire pivoter un Transform autour d'un point donné avec une vitesse donnée et une amplitude donnée
    public static void OscillateAroundPoint(this Transform transform, Vector3 point, Vector3 axis, float speed, float amplitude) {
	    transform.RotateAround(point, axis, speed * Time.deltaTime);
	    transform.localPosition = transform.localPosition.normalized * amplitude;
    }

    // Méthode pour obtenir l'angle entre la direction d'un Transform et un point donné
    public static float AngleToPoint(this Transform transform, Vector3 point) {
	    Vector3 direction = point - transform.position;
	    return Vector3.Angle(transform.forward, direction);
    }

    // Méthode pour obtenir l'angle entre la direction d'un Transform et un autre Transform
    public static float AngleToTransform(this Transform transform, Transform targetTransform) {
	    Vector3 direction = targetTransform.position - transform.position;
	    return Vector3.Angle(transform.forward, direction);
    }

    #region Rotation

    // Méthode pour tourner un Transform vers un autre Transform avec une vitesse donnée
    public static void RotateTowardsTransform(this Transform transform, Transform targetTransform, float speed) {
	    Vector3 direction = (targetTransform.position - transform.position).normalized;
	    Quaternion targetRotation = Quaternion.LookRotation(direction);
	    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }

    // Méthode pour tourner un Transform vers une direction donnée avec une vitesse donnée
    public static void RotateTowardsDirection(this Transform transform, Vector3 direction, float speed) {
	    Quaternion targetRotation = Quaternion.LookRotation(direction);
	    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }
    
    // Méthode pour faire tourner un Transform autour d'un point donné avec une vitesse donnée
    public static void RotateAroundPoint(this Transform transform, Vector3 point, Vector3 axis, float speed) {
	    transform.RotateAround(point, axis, speed * Time.deltaTime);
    }
    
    // Methode pour faire tourner un Transform sur un axe donné avec une vitesse donnée
    public static void RotateAroundAxis(this Transform transform, Vector3 axis, float angle, float speed) {
	    Quaternion rotation = Quaternion.AngleAxis(angle * speed * Time.deltaTime, axis);
	    transform.rotation = rotation * transform.rotation;
    }
    
    // Méthode pour obtenir l'angle de rotation autour de l'axe Y d'un Transform
    public static float GetYRotationAngle(this Transform transform) {
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        return eulerRotation.y;
    }

    // Méthode pour obtenir l'angle de rotation autour de l'axe X d'un Transform
    public static float GetXRotationAngle(this Transform transform) {
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        return eulerRotation.x;
    }

    // Méthode pour obtenir l'angle de rotation autour de l'axe Z d'un Transform
    public static float GetZRotationAngle(this Transform transform) {
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        return eulerRotation.z;
    }

    // Méthode pour effectuer une rotation autour de l'axe Y d'un Transform
    public static void RotateY(this Transform transform, float angle) {
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        eulerRotation.y += angle;
        transform.rotation = Quaternion.Euler(eulerRotation);
    }

    // Méthode pour effectuer une rotation autour de l'axe X d'un Transform
    public static void RotateX(this Transform transform, float angle) {
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        eulerRotation.x += angle;
        transform.rotation = Quaternion.Euler(eulerRotation);
    }

    // Méthode pour effectuer une rotation autour de l'axe Z d'un Transform
    public static void RotateZ(this Transform transform, float angle) {
        Vector3 eulerRotation = transform.rotation.eulerAngles;
        eulerRotation.z += angle;
        transform.rotation = Quaternion.Euler(eulerRotation);
    }

    // Méthode pour faire tourner un Transform vers une cible en utilisant une rotation douce
    public static void SmoothLookAt(this Transform transform, Vector3 target, float speed) {
        Vector3 direction = target - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }

    #endregion
    
}