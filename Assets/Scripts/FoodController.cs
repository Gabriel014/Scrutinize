using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FoodController : MonoBehaviour {

	public int prizesCount,requestedPrizes;
	public Text prizesText;


	// Use this for initialization
	public void FindFood()
	{
		prizesCount+=1;
		prizesText.text=prizesCount+"/"+requestedPrizes;
	}
}
