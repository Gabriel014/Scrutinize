using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharSelector : MonoBehaviour {
	public static int contPlayer=0;
	public Button goButton;
	public Text cardsRemaining;
	// Use this for initialization
	void  Start ()
	{
		contPlayer=0;
	}

	void Update()
	{
		if (contPlayer==3)goButton.GetComponent<Button>().interactable = true;
		else goButton.GetComponent<Button>().interactable = false;
		cardsRemaining.text = "Cards Remaining: "+(3-contPlayer);
	}
}
