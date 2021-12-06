using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BM : MonoBehaviour
{
    

    [SerializeField] AudioClip MainSong ; 
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        mainBackgroundMusic();
    }

    // Update is called once per frame
    void Update()
    {

        

    }

    void mainBackgroundMusic()
    {
        audioSource.PlayOneShot(MainSong);
        Debug.Log("started THE AUDIO"); 
    }

}
