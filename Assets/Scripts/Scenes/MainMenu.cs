using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
using FMOD.Studio;



public class MainMenu : MonoBehaviour, ILevelTransition
{
    public EventReference clickStart;
    private EventInstance startInstance; // Instancja dŸwiêku FMOD

    public EventReference click;
    private EventInstance clickInstance;
    public void OpenLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);

    }

    public void OnClickStart()
    {
        startInstance = RuntimeManager.CreateInstance(clickStart);
        startInstance.start();
    }

    public void OnClickMap()
    {

        clickInstance = RuntimeManager.CreateInstance(click);
        clickInstance.start();

    }
}

