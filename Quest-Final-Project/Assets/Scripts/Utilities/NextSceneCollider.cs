using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Extending from my sceneloader class, so I can just make use of its methods. 
public class NextSceneCollider : SceneLoader
{
    // This class will help me manage the loading of the next scene, Specefically for when the user walks through the collider. 
    public void OnTriggerEnter(Collider other)
    {
        LoadNextScene();
    }
}
