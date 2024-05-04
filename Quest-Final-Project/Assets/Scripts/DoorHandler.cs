using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{

    public Animator doorAnimator;
    public GameObject doorBlocker;
    public ArrayList tasks = new ArrayList();
    public GameState gameManager;

    public void Start()
    {
        tasks = gameManager.getTasks();

    }

    // Update is called once per frame
    void Update()
    {
        // First we will check if all of the tasks are complete' This should let me just add more tasks later on
        if(checkDoor())
        {
            doorAnimator.Play("Opening");
            doorBlocker.gameObject.SetActive(false);
        }
    }
    // Function to check the door state
    private bool checkDoor()
    {
        tasks = gameManager.getTasks();

        foreach (bool task in tasks)
        {
            //Debug.Log(task);
            if(task == false)
            {
                return false;
            }
        }
        return true;
    }
}
