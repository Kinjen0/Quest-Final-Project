using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateStack : MonoBehaviour
{
    // Reusing the RockStack code for the plates, However I do not want the plates to require a specefic order, so there is no order checking

    // Idea for this came from the textbook
    public Transform plateStackLocations;
    public List<Transform> plateLocations;

    // Int to track the number of stacked objects we currently have. 
    private int plateCount = 0; 

    // Audiosource to hold the sound to be played when a rock is stacked
    public AudioSource platePlaceSound;


    public GameState gameState;

    // Testing bool, to make my life easier. 
    public bool isDone = false;
    // Load up all of the plate locations
    public void Start()
    {
        foreach (Transform child in plateStackLocations)
        {

            plateLocations.Add(child);
        }
    }

    public void Update()
    {
        if(isDone)
        {
            gameState.markTaskComplete(2);
        }
        if(plateCount >= plateLocations.Count)
        {
            gameState.markTaskComplete(2);
        }
    }

    // This will handle the specefic logic between snapping the object to each position. 
    public void OnTriggerEnter(Collider other)
    {
        // If the object is a Plate, and it hasnt been placed, AND it has been washed. 
        if (other.gameObject.tag == "Plate" && other.gameObject.GetComponent<Plate>().isPlaced == false && other.gameObject.GetComponent<Plate>().plateWashed == true)
        {
            GameObject plate = other.gameObject;
            // If the count of rocks is less than the number of plate locations we can continue. 
            if (plateCount < plateLocations.Count)
            {
                // Start by forcing it to let go, then move it into position with the switch statement
                plate.gameObject.GetComponent<Plate>().ForceLetGo();

                plate.transform.position = plateLocations[plateCount].position;
                plate.transform.rotation = plateLocations[plateCount].rotation;

                plate.gameObject.GetComponent<Plate>().isPlaced = true;
                // Hopefully disable the grabbable component. Does not currently work
                // Try this https://forum.unity.com/threads/how-remove-script-via-script.414896/
                // Specefically destroy the component
                Destroy(plate.gameObject.GetComponent<OVRGrabbable>());
                //plate.gameObject.GetComponent<OVRGrabbable>().enabled = false;
                Debug.Log("placed Plate");
                plateCount++;
                // Now set the rock to kinnematic to stop its interactions. 
                plate.GetComponent<Rigidbody>().isKinematic = true;
                platePlaceSound.Play();    
            }
            else
            {
                gameState.markTaskComplete(2);
            }
        }

        
    }
}
