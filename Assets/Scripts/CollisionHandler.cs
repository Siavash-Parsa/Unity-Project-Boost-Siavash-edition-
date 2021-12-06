using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float LevelDelay = 1f;
    [SerializeField] AudioClip Crash;
    [SerializeField] AudioClip Win;
    [SerializeField] ParticleSystem CrashParticles;


    bool isTransitioning = false ;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning) 
        { 
            return;
        }
        
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("this is Friendly you can touch it");
                break;
            case "Finish":
                StartSuccesSequence(); 
                break;
            default:
                StartCrashSequence();
                break;
        }
    }
    void StartSuccesSequence()
    {

       
        isTransitioning = true;
        audioSource.Stop(); 
        audioSource.PlayOneShot(Win);
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", LevelDelay);
       
    }
    
    
    void StartCrashSequence()
    {
        CrashParticles.Play();
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(Crash);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", LevelDelay);
        
    }
    
    
    void ReloadLevel()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        SceneManager.LoadScene(CurrentSceneIndex);
    }
    void NextLevel()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int NextSceneIndex = CurrentSceneIndex + 1;
        if (NextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            NextSceneIndex = 0; 
        }
        SceneManager.LoadScene(NextSceneIndex); 
    }


}
