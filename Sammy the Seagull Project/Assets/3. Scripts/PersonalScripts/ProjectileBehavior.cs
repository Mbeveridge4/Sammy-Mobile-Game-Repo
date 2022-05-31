using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    //projectile speed
    public float Speed = 0.05f;
    //max lifetime of the projectile
    public float lifeTime = 2f;
    
    
    // Update is called once per frame
    public void Update()
    {
        //moves the projectile down
        transform.position = new Vector3(transform.position.x, transform.position.y + Speed);

        // counts down the lifetime
        lifeTime -= Time.deltaTime;

        //destroys the projectile when time is finished.
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }


    }
    
}
