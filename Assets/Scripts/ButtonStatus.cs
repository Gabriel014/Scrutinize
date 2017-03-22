using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonStatus : MonoBehaviour {
	bool pressed = false;

	public void Pressed() //string contém 4 numeros sendo força, agilidade, fofura i ID respectivamente.
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
		if(CharSelector.contPlayer==3&&!pressed)GetComponent<Button>().interactable = false;
		else GetComponent<Button>().interactable = true;
	}
}
