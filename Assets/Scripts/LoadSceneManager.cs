using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
	private bool ok = false;
	public bool isSplash;
    public static string sceneToLoad;      //cena para ser carregada
    
    public Text loadingText; 
	public float textAnimSpeed = 1.1f;//texto de loading


	void Start()
	{
		if(isSplash) sceneToLoad = "01a Menu";
		StartCoroutine(LoadNewScene());
	}
    void Update()
    {
         // inicia a corotina para a mudança de cena

         // aterna a transparencia da fonte
         loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time,textAnimSpeed));
    }
    
    // Corrotina para carregar a proxima cena
	IEnumerator LoadNewScene( )
    {

		// async para carregar todos os assets da proxima cena
		if(isSplash) yield return new WaitForSeconds(3);
		if(!isSplash)yield return new WaitForSeconds(2);

		//começa a carregar a cena
		StartCoroutine(SyncOperation());
		//espera a cena carregar até certo ponto
		yield return new WaitUntil(() => ok==true);
		//inicia o fade
		float fadeTime = gameObject.GetComponent<Fade>().BeginFade(1);
		//espera o fade terminar para carregar a cena seguinte
		yield return new WaitForSeconds(fadeTime);
		//ok para iniciar a cena
		ok=false;
    }

	IEnumerator SyncOperation()
	{
		//cria o processo
		AsyncOperation async = SceneManager.LoadSceneAsync(sceneToLoad);
		//mesmo que a cena esteja carregada, nao inicia imediatamente
		async.allowSceneActivation = false;

		while (async.progress<0.9f)
		{
			//para a unity nao travar
			yield return null;
		}
		//ok para iniciar o fade
		ok=true;
		//espera o ok para carregar a cena
		yield return new WaitUntil(()=>ok==false);
		//muda a cena
		async.allowSceneActivation = true;
	}
}
