using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public string sceneToRestart = "YourSceneName"; // Replace with your actual scene name

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming you have a "Player" tag on your player object
        {
            SceneManager.LoadScene(sceneToRestart);
        }
    }
}
