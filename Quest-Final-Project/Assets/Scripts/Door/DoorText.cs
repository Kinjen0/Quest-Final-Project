using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class DoorText : MonoBehaviour
{
    // This code will handle the operations of the door text, and its rendering. 

    public string headerText;
    public string completeText;

    public Text text; 

    public GameState gameState;

    private ArrayList taskList = new ArrayList();

    public string task1;
    public string task2;
    public string task3;

    public void Start()
    {
        taskList = gameState.getTasks();
    }

    public void Update()
    {
        taskList = gameState.getTasks();
        // Two seperate variables to make them independant, basically two pointers method, but a lot simpler. 
        int counter = 0;
        int number = 1;

        // If not everything is done, we can start off the text with a default header, otherwise paste the congradulations text
        if (!gameState.checkAllComplete())
        {
            text.text = headerText;
        }
        else
        {
            text.text = completeText;
        }

        // It is probably not the most efficient, but it will let me check and display each task, can be made a switch statement for more efficiency later on. 
        foreach(bool task in taskList)
        {
            if (!task)
            {
                if(counter == 0)
                {
                    text.text += "\n" + number + ": " + task1;
                    number++;

                }
                if (counter == 1)
                {
                    text.text += "\n" + number + ": " + task2;
                    number++;

                }
                if (counter == 2)
                {
                    text.text += "\n" + number + ": " + task3;
                    number++;

                }
            }
            // Increase counter EVERY itteration so that we can get the correct task listing. 
            counter++;

        }

    }



}
