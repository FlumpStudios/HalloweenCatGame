using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : MonoBehaviour
{
    const float SHRINK_SPEED = 0.1f;
    

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 1000))
        {
            GameObject hitObject = hitInfo.collider.gameObject;
            if (hitObject.name == "Ghost")
            {
                hitObject.transform.localScale = new Vector3(hitObject.transform.localScale.x - SHRINK_SPEED, hitObject.transform.localScale.y - SHRINK_SPEED, hitObject.transform.localScale.z - SHRINK_SPEED);
            }            
        }
    }
}
