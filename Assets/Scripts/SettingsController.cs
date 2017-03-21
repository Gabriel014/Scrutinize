using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingsController : MonoBehaviour {

	private Animator anim;
	private bool isSettings = false;
	public List<Button>otherButtons;

	void Start()
	{
		anim = gameObject.GetComponent<Animator>();
		anim.enabled = false;

	}
	public void SettingsOn()
	{
		if(!isSettings)
		{
			foreach (Button item in otherButtons)
			{
				item.GetComponent<Button>().interactable = false;
			}
			anim.enabled = true;
			anim.Play("Settings_Panel_On");
			isSettings = true;
		
		}
		else
		{
			foreach (Button item in otherButtons)
			{
				item.GetComponent<Button>().interactable = true;
			}
			anim.enabled = true;
			anim.Play("Settings_Panel_Out");
			isSettings = false;
		}
	}
}