using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    private GameObject player;  // Assign the player GameObject in the Inspector
    public float movementSpeed = 2.0f;  // Adjust the movement speed as needed

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        // Check if the player GameObject is assigned
        if (player != null)
        {
            // Calculate the direction from this object to the player
            Vector3 directionToPlayer = player.transform.position - transform.position;

            // Calculate the rotation to look at the player
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);

            // Smoothly rotate the object to face the player
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * movementSpeed);

            // Move the object forward
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("Player reference is not assigned. Assign the player GameObject in the Inspector.");
        }
    }
}
