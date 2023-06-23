using UnityEngine;

public static class RigidbodyExtensions {

    /// <summary>
    /// Applies a force to the Rigidbody at its center of mass.
    /// </summary>
    /// <param name="force">The force to be applied</param>
    /// <param name="mode">The force mode (default: ForceMode.Force)</param>
    public static void ApplyForce(this Rigidbody rigidbody, Vector3 force, ForceMode mode = ForceMode.Force) {
        rigidbody.AddForce(force, mode);
    }

    /// <summary>
    /// Applies a force to the Rigidbody at a specific position.
    /// </summary>
    /// <param name="force">The force to be applied</param>
    /// <param name="position">The position at which the force should be applied</param>
    /// <param name="mode">The force mode (default: ForceMode.Force)</param>
    public static void ApplyForceAtPosition(this Rigidbody rigidbody, Vector3 force, Vector3 position, ForceMode mode = ForceMode.Force) {
        rigidbody.AddForceAtPosition(force, position, mode);
    }

    /// <summary>
    /// Applies gravity force to the Rigidbody.
    /// </summary>
    public static void ApplyGravity(this Rigidbody rigidbody) {
        rigidbody.AddForce(Physics.gravity, ForceMode.Acceleration);
    }

    /// <summary>
    /// Applies an impulse to the Rigidbody at its center of mass.
    /// </summary>
    /// <param name="impulse">The impulse to be applied</param>
    public static void ApplyImpulse(this Rigidbody rigidbody, Vector3 impulse) {
        rigidbody.AddForce(impulse, ForceMode.Impulse);
    }

    /// <summary>
    /// Applies an impulse to the Rigidbody at a specific position.
    /// </summary>
    /// <param name="impulse">The impulse to be applied</param>
    /// <param name="position">The position at which the impulse should be applied</param>
    public static void ApplyImpulseAtPosition(this Rigidbody rigidbody, Vector3 impulse, Vector3 position) {
        rigidbody.AddForceAtPosition(impulse, position, ForceMode.Impulse);
    }

    /// <summary>
    /// Applies an instant rotation to the Rigidbody.
    /// </summary>
    /// <param name="rotation">The rotation to be applied</param>
    public static void ApplyRotation(this Rigidbody rigidbody, Quaternion rotation) {
        rigidbody.MoveRotation(rotation);
    }

    /// <summary>
    /// Applies an instant rotation around a specific point of the Rigidbody.
    /// </summary>
    /// <param name="rotation">The rotation to be applied</param>
    /// <param name="point">The point around which the rotation should occur</param>
    public static void ApplyRotationAround(this Rigidbody rigidbody, Quaternion rotation, Vector3 point) {
        Vector3 centerOfMassWorld = rigidbody.worldCenterOfMass;
        Vector3 pointFromCenterOfMass = point - centerOfMassWorld;
        Vector3 velocityAtPoint = rigidbody.GetPointVelocity(centerOfMassWorld) + Vector3.Cross(rigidbody.angularVelocity, pointFromCenterOfMass);
        Vector3 finalVelocityAtPoint = rotation * velocityAtPoint;
        Vector3 finalVelocity = rigidbody.velocity + (finalVelocityAtPoint - velocityAtPoint);
        Vector3 finalAngularVelocity = rigidbody.angularVelocity + (Vector3.Cross(pointFromCenterOfMass, finalVelocityAtPoint) - Vector3.Cross(pointFromCenterOfMass, velocityAtPoint));
        rigidbody.velocity = finalVelocity;
        rigidbody.angularVelocity = finalAngularVelocity;
    }

    /// <summary>
    /// Stops all movement of the Rigidbody.
    /// </summary>
    public static void StopMovement(this Rigidbody rigidbody) {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }
    
    
    /// <summary>
    /// Applies a force towards a specific point on the Rigidbody.
    /// </summary>
    /// <param name="point">The point towards which the force should be applied</param>
    /// <param name="forceMagnitude">The magnitude of the force</param>
    /// <param name="mode">The force mode (default: ForceMode.Force)</param>
    public static void ApplyForceTowards(this Rigidbody rigidbody, Vector3 point, float forceMagnitude, ForceMode mode = ForceMode.Force) {
        Vector3 forceDirection = (point - rigidbody.position).normalized;
        Vector3 force = forceDirection * forceMagnitude;
        rigidbody.AddForce(force, mode);
    }

    /// <summary>
    /// Applies a random force to the Rigidbody within a given magnitude range.
    /// </summary>
    /// <param name="minForceMagnitude">The minimum magnitude of the force</param>
    /// <param name="maxForceMagnitude">The maximum magnitude of the force</param>
    /// <param name="mode">The force mode (default: ForceMode.Force)</param>
    public static void ApplyRandomForce(this Rigidbody rigidbody, float minForceMagnitude, float maxForceMagnitude, ForceMode mode = ForceMode.Force) {
        Vector3 randomForce = Random.onUnitSphere * Random.Range(minForceMagnitude, maxForceMagnitude);
        rigidbody.AddForce(randomForce, mode);
    }

    /// <summary>
    /// Applies a torque to the Rigidbody.
    /// </summary>
    /// <param name="torque">The torque to be applied</param>
    /// <param name="mode">The force mode (default: ForceMode.Force)</param>
    public static void ApplyTorque(this Rigidbody rigidbody, Vector3 torque, ForceMode mode = ForceMode.Force) {
        rigidbody.AddTorque(torque, mode);
    }

    /// <summary>
    /// Stops the rotation of the Rigidbody.
    /// </summary>
    public static void StopRotation(this Rigidbody rigidbody) {
        rigidbody.angularVelocity = Vector3.zero;
    }

    /// <summary>
    /// Enables or disables gravity for the Rigidbody.
    /// </summary>
    /// <param name="enabled">Whether gravity should be enabled or disabled</param>
    public static void SetGravity(this Rigidbody rigidbody, bool enabled) {
        rigidbody.useGravity = enabled;
    }

    /// <summary>
    /// Sets the position of the Rigidbody.
    /// </summary>
    /// <param name="position">The new position</param>
    public static void SetPosition(this Rigidbody rigidbody, Vector3 position) {
        rigidbody.position = position;
    }

    /// <summary>
    /// Sets the rotation of the Rigidbody.
    /// </summary>
    /// <param name="rotation">The new rotation</param>
    public static void SetRotation(this Rigidbody rigidbody, Quaternion rotation) {
        rigidbody.rotation = rotation;
    }
}
