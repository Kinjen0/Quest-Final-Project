using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// So this class will help me manage the game music
public class MusicControler : MonoBehaviour
{
    public GameObject musicHolder;
    public List<AudioSource> songs;

    public AudioSource CurrentSong;
    public void Start()
    {
        // Fornow we will just manually set it up with a single song on loop
        CurrentSong.Play();
    }
}
