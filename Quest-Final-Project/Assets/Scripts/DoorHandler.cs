using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{

    public Animator doorAnimator;
    public GameObject doorBlocker;
    public bool[] completedTasks;
    public GameState gameManager;

    public void Start()
    {
        completedTasks = gameManager.getTasks();

    }

    // Update is called once per frame
    void Update()
    {
        // First we will check if all of the tasks are complete' 
        if(checkDoor())
        {
            doorAnimator.Play("Opening");
            doorBlocker.gameObject.SetActive(false);
        }
    }
    // Function to check the door state
    private bool checkDoor()
    {
        completedTasks = gameManager.getTasks();

        foreach (bool task in completedTasks)
        {
            if(task == false)
            {
                return false;
            }
        }
        return true;
    }
}
