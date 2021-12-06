using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    AudioSource audioSource ;
    Rigidbody rb ; 
    [SerializeField] float mainRotate = 1000f ; 
    [SerializeField] float mainThrust = 1000f ;
    [SerializeField] AudioClip MainEngine;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
        ProcessThrust(); 
        ProcessRotation();
    }
    
    
    
    
    
    void ProcessThrust()
    {
      if(Input.GetKey(KeyCode.Space))
      {
          rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
          if (!audioSource.isPlaying)
          {
                audioSource.PlayOneShot(MainEngine);
          }
          
      }
      else
       {
            audioSource.Stop();
       }
    }
    void ProcessRotation()
    {
     if(Input.GetKey(KeyCode.A))
      {
         RotationThrust(mainRotate);
      }
     else if(Input.GetKey(KeyCode.D))
      {
        RotationThrust(-mainRotate);
      }
    void RotationThrust(float FrameRotate) 
    {
        rb.freezeRotation = true ;
        transform.Rotate(Vector3.forward * FrameRotate * Time.deltaTime);
        rb.freezeRotation = false; 
        
        }
    }
}

