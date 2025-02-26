using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;

public class CameraFader : MonoBehaviour
{
    private Material fadeMaterial;

    // Start is called before the first frame update
    void Start()
    {
     fadeMaterial = GetComponent<MeshRenderer>().material;
        FadeIn();
    }

    public void FadeIn()
    {
        Tween.MaterialColor(fadeMaterial, new Color(0, 0, 0, 0), new Color(0, 0, 0, 1), 2f);
    }

    public void FadeOut()
    {
        Tween.MaterialColor(fadeMaterial, new Color(0, 0, 0, 1), new Color(0, 0, 0, 0), 2f);
    }

    public void FadeToScene(float fadeTime, string sceneName)
    {
        Tween.MaterialColor(fadeMaterial, new Color(0, 0, 0, 0), new Color(0, 0, 0, 1), 2f).OnComplete(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        });
    }


}
