using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void LoadExperimentOne()
    {
        SceneManager.LoadScene("ExperimentOne");
    }

    public void LoadExperimentTwo()
    {
        SceneManager.LoadScene("ExperimentTwo");
    }

    public void LoadExperimentThree()
    {
        SceneManager.LoadScene("ExperimentThree");
    }

    public void LoadExperimental()
    {
        SceneManager.LoadScene("Experimental");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
