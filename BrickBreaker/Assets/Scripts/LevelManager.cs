using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    int breakableBlocks;

    BrickBreakerSceneManager sceneManager;

    private void Start()
    {
        sceneManager = FindObjectOfType<BrickBreakerSceneManager>();
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            sceneManager.LoadNextScene();
        }
    }
}
