using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardsController : MonoBehaviour {
	string type;
	public float speed;
	bool move=false;
	public Transform initialPosition;
	public void ShowCard(string cardType)
	{
		//tipo de carta posto no prefab.
		move=true;
		type=cardType;
		initialPosition=gameObject.GetComponent<Transform>();
        transform.SetSiblingIndex(10);
        StartCoroutine(AnimationStart());
	}

	void Update()
	{
		if(move)
		{
			float step = speed+Time.deltaTime;
			transform.position=Vector3.MoveTowards(initialPosition.position,new Vector3(0,0,0),step);
		}

		if(transform.position==new Vector3(0,0,0)){
			gameObject.GetComponent<Animator>().enabled=true;
			gameObject.GetComponent<Animator>().Play("bossAnimation");
			
		}
        				
	}
	IEnumerator AnimationStart()
	{
		if(type=="food")
		{
		}
		if(type=="item")
		{
		}
		if(type=="trap")
		{

		}
		if(type=="boss")
		{
			yield return new WaitForSeconds(2);
			GameObject.Find("Test Button").GetComponent<TestManager>().BattleManager(gameObject);//aciona o script do TestManager e coloca como referencia esse GameObject
			move=false;
		}

	}
	public void TurnBack(){
		move=true;
	}
}
