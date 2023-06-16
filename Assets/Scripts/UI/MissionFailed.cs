using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
using FMOD.Studio;

public class MissionFailed : MonoBehaviour
{
    public EventReference clickStart;
    private EventInstance startInstance; // Instancja dŸwiêku FMOD

    public EventReference click;
    private EventInstance clickInstance;
    public void BackToMainMenu()
    {
        startInstance = RuntimeManager.CreateInstance(click);
        startInstance.start();
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        clickInstance = RuntimeManager.CreateInstance(clickStart);
        clickInstance.start();
        SceneManager.LoadScene("Krystian");
    }
}
