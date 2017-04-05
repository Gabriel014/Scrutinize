using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAnimationController : MonoBehaviour {
	private bool open=false;
	// Use this for initialization
	public void ChangeStatus()
	{
		if(!open)
		{
			gameObject.GetComponent<Animator>().SetBool("isOpen",true);
			open=true;
		}
		else{
			gameObject.GetComponent<Animator>().SetBool("isOpen",false);
			open=false;
		}
	}
}
