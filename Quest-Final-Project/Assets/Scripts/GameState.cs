using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public ArrayList tasks = new ArrayList() { false, false};

    public ArrayList getTasks()
    {
        return tasks;
    }

    public void markTaskComplete(int i)
    {
        tasks[i] = true;
        // Else do nothing, its invalid
    }
}
