using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SammyAttack : MonoBehaviour
{
    public Transform firePosition;
    public GameObject projectile;

    public void Poop()
    {
        //creates a projectile at the fire position (both set in Unity GUI)
        Instantiate(projectile, firePosition.position, firePosition.rotation);

    }   
}
