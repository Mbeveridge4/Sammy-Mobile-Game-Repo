using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SammySpline : MonoBehaviour
{
    [SerializeField] private float interpolateAmount;
    [SerializeField] private float timer;
    [SerializeField] private int flyDirection;
    private bool notFirstMove = true;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private Transform pointC;
    [SerializeField] private Transform pointD;
    [SerializeField] private Transform pointABCD;
   
    void Update()
    {
        if (timer <= 0)
        { 
        interpolateAmount = (interpolateAmount + Time.deltaTime / 2) % 1f;
        }
        timer -= Time.deltaTime;
        if (flyDirection == 0 && timer <= 0)
        {
            pointABCD.position = CubicLerp(pointD.position, pointB.position, pointC.position, pointA.position, interpolateAmount);
            if (interpolateAmount >= 0.99f)
            {
                flyDirection = 1;
                interpolateAmount = 0;
                timer = 1;
                if (notFirstMove)
                {
                    Flip();
                }
                else
                {
                    notFirstMove = true;
                }
            }
        }
        if (flyDirection == 1 && timer <= 0)
        {
            pointABCD.position = CubicLerp(pointA.position, pointB.position, pointC.position, pointD.position, interpolateAmount);
            if (interpolateAmount >= 0.99f)
            {
                flyDirection = 0;
                interpolateAmount = 0;
                timer = 1;
                if (notFirstMove)
                {
                    Flip();
                }
                else
                {
                    notFirstMove = true;
                }
            }
        }
      
      
    }

    private Vector3 QuadraticLerp(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 ab = Vector3.Lerp(a, b, t);
        Vector3 bc = Vector3.Lerp(b, c, t);
        return Vector3.Lerp(ab, bc, interpolateAmount);
    }

    private Vector3 CubicLerp(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        Vector3 ab_bc = QuadraticLerp(a, b, c, t);
        Vector3 bc_cd = QuadraticLerp(b, c, d, t);
        return Vector3.Lerp(ab_bc, bc_cd, interpolateAmount);
    }

    public void Flip()
    {
        // takes the current scale vector from unity for sammy's sprite and stores it in a variable
        Vector3 currentScale = gameObject.transform.localScale;
        // multiplies the x scale value by -1 to flip it
        currentScale.x *= -1;
        // updates the scale vector in unity to the new values
        gameObject.transform.localScale = currentScale;

    }
}
