using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public CameraFader cameraFader;

    public void LoadScenarioScene()
    { 
     cameraFader.FadeToScene(3f, "ScenariosV3");
    }

    public void LoadStartEndScene()
    {
        cameraFader.FadeToScene(3f, "StartEndV7");
    }


    public void SceneChangerScenarios()
    {
        SceneManager.LoadScene("ScenariosV3");
    }

    public void SceneChangerStartEnd()
    {
        SceneManager.LoadScene("StartEndV7");
    }
}
