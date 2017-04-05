using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagItemController : MonoBehaviour {
	public Sprite inventoryBg;
	private int cardEffect, posicao;

	public void EffectSet(GameObject referencia,int index)
	{
		cardEffect = referencia.GetComponent<RewardsController>().subType;
		gameObject.GetComponent<Button>().interactable=true;
		posicao=index;

	}

	public void UseCard(){
		switch(cardEffect)
		{
		case 1:
			GameObject.Find("Main Camera").GetComponent<ArtifactsHandler>().diceBonusIncreaser(1);
			break;
		case 2:
			GameObject.Find("Main Camera").GetComponent<ArtifactsHandler>().bravenessNumericBonus(1);
			break;
		case 3:
			GameObject.Find("Main Camera").GetComponent<ArtifactsHandler>().agilityNumericBonus(1);
			break;
		case 4:
			GameObject.Find("Main Camera").GetComponent<ArtifactsHandler>().cutenessNumericBonus(1);
			break;
		case 5:
			GameObject.Find("Main Camera").GetComponent<ArtifactsHandler>().resetDisabledCat();
			break;
		case 6:
			GameObject.Find("Main Camera").GetComponent<ArtifactsHandler>().healLife(1);
			break;
		}
		gameObject.GetComponent<Image>().sprite=inventoryBg;
		gameObject.GetComponent<Button>().interactable=false;
		GameObject.Find("Inventory Button").GetComponent<InventoryManager>().index[posicao]=0;
	}

	public void ShowDetails(GameObject zoomImage)
	{
		if(gameObject.GetComponent<Button>().interactable==true&&Vector3.SqrMagnitude(new Vector3(1,1,1) - gameObject.GetComponent<Transform>().localScale)<0.1){
			zoomImage.GetComponent<Image>().sprite = gameObject.GetComponent<Image>().sprite;
			zoomImage.SetActive(true);
		}
	}
}
