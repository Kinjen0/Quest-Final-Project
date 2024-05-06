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
        if(gameManager.checkAllComplete())
        {
            doorAnimator.Play("Opening");
            doorBlocker.gameObject.SetActive(false);
        }
    }

}
