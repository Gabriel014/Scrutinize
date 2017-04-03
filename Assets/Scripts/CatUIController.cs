using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatUIController : MonoBehaviour {
	public GameObject catThumb1,catThumb2, catThumb3, life1, life2, life3;
	bool change=false;
	// Use this for initialization
	void Start () 
	{
		
		catThumb1.GetComponent<Image>().sprite=ButtonController.catThumb1;
		catThumb2.GetComponent<Image>().sprite=ButtonController.catThumb2;
		catThumb3.GetComponent<Image>().sprite=ButtonController.catThumb3;
	
	}

	// Update is called once per frame
	public void LifechangeAnimation ()
	{
	
		StartCoroutine(Changelife());
	
	}

	IEnumerator Changelife()
	{
		
		change=true;
		yield return new WaitForSeconds(2);
		change=false;

		if(GameplayVariableHandler.cat1Life <= 0)catThumb1.GetComponent<Image>().CrossFadeColor(new Color32 (100,100,100,255),1,true,false);
		if(GameplayVariableHandler.cat2Life <= 0)catThumb2.GetComponent<Image>().CrossFadeColor(new Color32 (100,100,100,255),1,true,false);
		if(GameplayVariableHandler.cat3Life <= 0)catThumb3.GetComponent<Image>().CrossFadeColor(new Color32 (100,100,100,255),1,true,false);

	}

	void Update()
	{
	
		if(change)
		{
			life1.GetComponent<Image>().fillAmount = Mathf.Lerp(life1.GetComponent<Image>().fillAmount, GameplayVariableHandler.cat1Life / 4.00f,0.1f);
			life2.GetComponent<Image>().fillAmount = Mathf.Lerp(life2.GetComponent<Image>().fillAmount, GameplayVariableHandler.cat2Life / 4.00f,0.1f);
			life3.GetComponent<Image>().fillAmount = Mathf.Lerp(life3.GetComponent<Image>().fillAmount, GameplayVariableHandler.cat3Life / 4.00f,0.1f);
		}  
               
	}
}
