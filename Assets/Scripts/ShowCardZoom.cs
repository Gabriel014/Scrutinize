using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCardZoom : MonoBehaviour {

	public void ChangeSprite(int cat)
	{
		switch(cat)
		{
		case 0:
			gameObject.GetComponent<Image>().sprite = ButtonController.catCard1;
			break;
		case 1:
			gameObject.GetComponent<Image>().sprite = ButtonController.catCard2;
			break;
		case 2:
			gameObject.GetComponent<Image>().sprite = ButtonController.catCard3;
			break;
		}
	}
}