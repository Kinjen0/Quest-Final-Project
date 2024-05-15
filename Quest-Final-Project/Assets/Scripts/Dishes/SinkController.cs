using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkController : MonoBehaviour
{
    // So This system will allow me to control the partical system for the sink, So when the player enters the collider knob, it will start the playing, and then stop after 10 seconds.
    public ParticleSystem particle;

    // Animation controller to handle the turning of the sink faucet. 
    public Animator animator;

    // Counter for how long I want it to stay on
    public int activateTime;

    private AudioSource waterSound;

    public void Start()
    {
        waterSound = GetComponent<AudioSource>();
        // Start off with the animation for off playing
        animator.SetBool("IsOn", false);
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerHand")
        {
            // Stop all other coroutines and then start it again. 
            StopAllCoroutines();
            StartCoroutine(PlayWaterEffect());
        }
    }
    private IEnumerator PlayWaterEffect()
    {
        // First we want to play the effect. However, ONLY if they are not already playing. 
        // Only turn it on if its not already on. 
        if (!animator.GetBool("IsOn"))
        {
            animator.SetBool("IsOn", true);
        }
        if (!particle.isPlaying)
        {
            particle.Play();
        }
        if(!waterSound.isPlaying)
        {
            waterSound.Play();
        }

        // Next wait a few seconds
        yield return new WaitForSeconds(activateTime);
        animator.SetBool("IsOn", false);
        particle.Stop();
        waterSound.Stop();

    }
}
