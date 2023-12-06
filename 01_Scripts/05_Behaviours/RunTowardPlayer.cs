using System;
using System.Collections;
using System.Collections.Generic;
using Tool;
using UnityEngine;

public class RunTowardPlayer : MonoBehaviour
{
    
    private Vector3 direction;
    private float currentSpeed;
    [MinMaxSlider(1,20)][SerializeField]private MinMax speedLimit;

    
    enum RelativeDirection
    {
        Right,
        Left,
        Up,
        Down
    }
    
    public bool facePlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        if (facePlayer)
            RotateTowardPlayer();
        direction = GameObject.FindWithTag("Player").transform.position - transform.position;
        currentSpeed = Mathf.Clamp(direction.magnitude, speedLimit.Min,speedLimit.Max);
    }

    private void Update()
    {
        Vector3 movement = direction.normalized * currentSpeed * Time.deltaTime;

        if (facePlayer)
        {
            movement = GetDirectionVector() * currentSpeed * Time.deltaTime;
        }
        transform.Translate(movement);
    }

    private void RotateTowardPlayer()
    {
            // Obtenir la direction vers le joueur
            Vector3 direction = GameObject.FindWithTag("Player").transform.position - transform.position;
            direction.z = 0f; // Ignorer l'axe Z

            if (direction != Vector3.zero)
            {
                // Rotation uniquement autour de l'axe Z pour faire face au joueur
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

                // Appliquer la rotation à l'objet en conservant les rotations X et Y
                transform.rotation = targetRotation;
            }
    }

    private void OnEnable()
    {
        direction = GameObject.FindWithTag("Player").transform.position - transform.position;
        currentSpeed = Mathf.Clamp(direction.magnitude, speedLimit.Min,speedLimit.Max);
    }

    public Vector2 GetDirectionVector()
    {
        return Vector2.right;
    }
    
    RelativeDirection GetRelativeDirection(Vector2 objectPosition, Vector2 playerPosition)
    {
        float xDifference = objectPosition.x - playerPosition.x;
        float yDifference = objectPosition.y - playerPosition.y;

        if (Mathf.Abs(xDifference) > Mathf.Abs(yDifference))
        {
            if (xDifference > 0)
            {
                return RelativeDirection.Right;
            }
            else
            {
                return RelativeDirection.Left;
            }
        }
        else
        {
            if (yDifference > 0)
            {
                return RelativeDirection.Up;
            }
            else
            {
                return RelativeDirection.Down;
            }
        }
    }
}
