using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;


public class SceneManagerController : MonoBehaviour
{

 	public bool loadRequired;
    
    // Use this for initialization
    public void ReloadLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

	public void LoadAScene(string sceneToLoad)
    {
		StartCoroutine(LoadNewScene(sceneToLoad, loadRequired));
    }

	IEnumerator LoadNewScene(string sceneToLoad, bool loadRequired)
    {
        //espera x segundos em caso do carregamento ser muito rapido
        //yield return new WaitForSeconds(3);

        //inicia o fade
        float fadeTime = gameObject.GetComponent<Fade>().BeginFade(1);

        //espera o fade terminar para carregar a cena seguinte
        yield return new WaitForSeconds(fadeTime);

		if(loadRequired) 
		{
			LoadSceneManager.sceneToLoad = sceneToLoad;
			SceneManager.LoadScene("03 Loading");
		}
		else SceneManager.LoadScene(sceneToLoad);
    }

 }