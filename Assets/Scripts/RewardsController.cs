using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardsController : MonoBehaviour {
	string type;
	public float speed;
	bool move=false;
	int status=0;
	public Transform initialPosition;
	public void ShowCard(string cardType)
	{
		//tipo de carta posto no prefab.
		status=1;
		move=true;
		type=cardType;
		initialPosition=gameObject.GetComponent<Transform>();
		StartCoroutine(AnimationStart());
	}

	void Update()
	{
		if(move&&status==1)
		{
			float step = speed+Time.deltaTime;
			transform.position=Vector3.MoveTowards(initialPosition.position,new Vector3(0,0,0),step);
		}
		else if(move&&status==-1)
		{
			float step = speed+Time.deltaTime;
			transform.position=Vector3.MoveTowards(transform.position,initialPosition.position,step);

		}
		if((transform.position==new Vector3(0,0,0))&&status==1){
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
			move=false;		}

	}
	public void TurnBack(){
		status=-1;
		move=true;
	}
}
