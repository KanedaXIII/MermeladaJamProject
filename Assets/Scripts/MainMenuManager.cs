using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void SetScene(string scn)
    {
        SceneManager.LoadScene(scn);
    }

    public void goToOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void GoToExit()
    {
        Application.Quit();
    }
}
