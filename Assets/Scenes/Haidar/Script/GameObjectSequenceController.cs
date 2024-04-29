using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSequenceController : MonoBehaviour
{
    public GameObject[] gameObjects; // Array of game objects to control
    private int currentIndex = 0; // Index of currently active game object

    // Method to activate game objects sequentially starting from a specified index
    public void ActivateNextGameObject(int startIndex)
    {
        // Ensure startIndex is within a valid range
        if (startIndex >= 0 && startIndex < gameObjects.Length)
        {
            // Deactivate all game objects except the one at startIndex
            for (int i = 0; i < gameObjects.Length; i++)
            {
                if (i != startIndex)
                {
                    gameObjects[i].SetActive(false);
                }
            }

            // Activate the game object at startIndex
            gameObjects[startIndex].SetActive(true);
        }
    }
}
