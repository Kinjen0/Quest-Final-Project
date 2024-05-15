using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // This part of the script came from the template scripts. 
    public void LoadNextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        index = (index + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(index);
    }
}
