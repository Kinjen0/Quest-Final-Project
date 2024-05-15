using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // Start is called before the first frame update

    public ArrayList tasks = new ArrayList() { false, false, false};

    public ArrayList getTasks()
    {
        return tasks;
    }

    public bool checkAllComplete()
    {
        foreach (bool task in tasks)
        {
            //Debug.Log(task);
            if (task == false)
            {
                return false;
            }
        }
        return true;
    }

    public void markTaskComplete(int i)
    {
        tasks[i] = true;
        // Else do nothing, its invalid
    }
}
