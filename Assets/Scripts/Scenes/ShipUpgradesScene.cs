using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipUpgradesScene : MonoBehaviour, ILevelTransition
{
    public void OpenLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
