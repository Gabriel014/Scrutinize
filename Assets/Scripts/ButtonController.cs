using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {
	bool pressed = false;


	public void Pressed()
	{
		if (!pressed)
		{
			
			CharSelector.contPlayer+=1;
			pressed = true;
			gameObject.GetComponent<Image>().color = new Color32 (71,71,71,255);
		}
		else 
		{
			CharSelector.contPlayer-=1;
			pressed = false;
			gameObject.GetComponent<Image>().color = new Color32 (255,255,255,255);
		}
	}
	void Update()
	{
		if(CharSelector.contPlayer==3&&!pressed)
		{
			gameObject.GetComponent<Button>().interactable = false;
		}
		else
		{
			gameObject.GetComponent<Button>().interactable = true;
		}
	}

}
