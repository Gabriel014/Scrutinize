using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;


public class BackKey : MonoBehaviour
{

    public string sceneToLoad;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (SceneManager.GetActiveScene().buildIndex == 1) Application.Quit();
            else LoadAScene(sceneToLoad);
        }
    }

    public void LoadAScene(string sceneToLoad)
    {
        StartCoroutine(LoadNewScene(sceneToLoad));
    }

    IEnumerator LoadNewScene(string sceneToLoad)
    {
        //espera x segundos em caso do carregamento ser muito rapido
        //yield return new WaitForSeconds(3);

        //inicia o fade
        float fadeTime = gameObject.GetComponent<Fade>().BeginFade(1);

        //espera o fade terminar para carregar a cena seguinte
        yield return new WaitForSeconds(fadeTime);

        SceneManager.LoadScene(sceneToLoad);
    }

}