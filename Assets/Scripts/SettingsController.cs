using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsController : MonoBehaviour {

	private Animator animSettings, animCredits;
	private bool isSettings = false, isCredits = false;


	void Start()
	{
		animSettings = gameObject.GetComponent<Animator>();
		animSettings.enabled = false;
		animCredits = GameObject.Find("Credits_Panel").GetComponent<Animator>();
		animCredits.enabled = false;
	}
	public void SettingsOn()
	{
		if(!isSettings)
		{
			if(isCredits)
			{
				isCredits = false;
				animCredits.Play("Settings_Panel_Out");
			}
			else
			{
				animSettings.enabled = true;
				animSettings.Play("Settings_Panel_On");
				isSettings = true;
			}
		}
		else
		{
			animSettings.enabled = true;
			animSettings.Play("Settings_Panel_Out");
			isSettings = false;
		}
	}
	public void CreditsOn()
	{
		animSettings.Play("Settings_Panel_Out");
		isSettings = false;
		animCredits.enabled = true;
		isCredits = true;
		animCredits.Play("Settings_Panel_On");
	}
}