using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// This class will represent a textpopup system for the objects in the game
public class TextPopup : MonoBehaviour
{
    // Strings to represent the different states that the textpop can be in
    public string defaultText;
    public string hoverText;
    public string promptText;

    // The public text object that will display the text, set in inspector
    public Text popupText;

    // Grabbable to allow for interactions
    public OVRGrabbable grabbable;

    public void Start()
    {
        popupText.text = defaultText;
        grabbable = GetComponent<OVRGrabbable>();
    }

    public void OnTriggerEnter(Collider other)
    {
        GameObject entered = other.gameObject;
        // If the hand enters, this will be a seperate small collider object attached to the players hand
        if(entered.tag == "PlayerHand")
        {
            popupText.text = hoverText;
        }
    }

    // On trigger exit
    public void OnTriggerExit(Collider other)
    {
        GameObject entered = other.gameObject;
        // If the players hand exits, we will want to display an additional propmpt text. 
        if(entered.tag == "PlayerHand")
        {
            popupText.text = promptText;
        }
    }


    //P

}
