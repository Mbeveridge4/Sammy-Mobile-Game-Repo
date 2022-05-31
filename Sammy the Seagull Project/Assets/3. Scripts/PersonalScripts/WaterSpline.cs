using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpline : MonoBehaviour
{
    [SerializeField] private float interpolateAmount;
    
    [SerializeField] private int flyDirection;
    
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private Transform pointC;
    [SerializeField] private Transform pointD;
    [SerializeField] private Transform pointABCD;

    void Update()
    {
        
            interpolateAmount = (interpolateAmount + Time.deltaTime / 5) % 1f;
        
        
        if (flyDirection == 0 )
        {
            pointABCD.position = CubicLerp(pointD.position, pointB.position, pointC.position, pointA.position, interpolateAmount);
            if (interpolateAmount >= 0.99f)
            {
                flyDirection = 1;
                interpolateAmount = 0;
                
               
            }
        }
        if (flyDirection == 1 )
        {
            pointABCD.position = CubicLerp(pointA.position, pointB.position, pointC.position, pointD.position, interpolateAmount);
            if (interpolateAmount >= 0.99f)
            {
                flyDirection = 0;
                interpolateAmount = 0;
                
               
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

   
}
