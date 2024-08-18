using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextSceneOnInput : MonoBehaviour
{
    void Update()
    {
        // Check if any key is pressed or if the mouse is clicked
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            // Load the next scene in the build order
            SceneManager.LoadScene(2);
        }
    }
}

