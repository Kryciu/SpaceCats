using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
using FMOD.Studio;

public class SceneSoundController : MonoBehaviour
{



    public EventReference musicMenu;
    private EventInstance soundInstance; // Instancja dŸwiêku FMOD
    

    void Start()
    {
        
        soundInstance = RuntimeManager.CreateInstance(musicMenu);
        soundInstance.start();
    }

  

    void OnDestroy()
    {
        if (soundInstance.isValid())
        {
            soundInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            soundInstance.release();
        }
    }


    

   

}
