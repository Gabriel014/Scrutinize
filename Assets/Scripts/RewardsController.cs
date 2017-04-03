using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardsController : MonoBehaviour {
	

	public void ShowCard(string cardType){//tipo de carta posto no prefab.
		if(cardType=="food")
		{
		}
		if(cardType=="item")
		{
			
		}
		if(cardType=="trap")
		{
			
		}
		if(cardType=="boss")
		{
			GameObject.Find("Test Button").GetComponent<TestManager>().BattleManager(gameObject);//aciona o script do TestManager e coloca como referencia esse GameObject
		}
	}
}
