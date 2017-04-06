using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardsController : MonoBehaviour {
    [HideInInspector]
    public string type;
	public int subType;
	public float speed;
	bool move=false;
	[HideInInspector]
	public Transform initialPosition;

    public AudioClip cardFlip, battleCry, diceRoll;
    public AudioSource audioToBePlayed;
	//bool samePosition;

	public void ShowCard(string cardType)
	{
        //tipo de carta posto no prefab.
        audioToBePlayed = GetComponent<AudioSource>();
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

//		if(transform.position==new Vector3(0,0,0)&&type=="boss"){
//			gameObject.GetComponent<Animator>().enabled=true;
//			gameObject.GetComponent<Animator>().Play("bossAnimation");
//			
//		}
        				
	}
	IEnumerator AnimationStart()
	{
		if(type=="food")
		{
		}
		if(type=="item")
		{
			GameObject.Find("Inventory Button").GetComponent<InventoryManager>().AddItem(gameObject);
		}
		if(type=="trap")
		{

		}
		if(type=="boss")
		{
			//yield return new WaitForSeconds(2);
			yield return new WaitUntil(()=>Vector3.SqrMagnitude(transform.position - new Vector3(0,0,0))<0.0001);
			GameObject.Find("Test Button").GetComponent<TestManager>().BattleManager(gameObject);//aciona o script do TestManager e coloca como referencia esse GameObject
			move=false;
			gameObject.GetComponent<Animator>().enabled=true;
			gameObject.GetComponent<Animator>().Play("bossAnimation");

            audioToBePlayed.clip = cardFlip;
            audioToBePlayed.PlayDelayed(0.15f);
            yield return new WaitForSeconds(0.4f);

            audioToBePlayed.clip = battleCry;
            audioToBePlayed.PlayDelayed(0.5f);
            yield return new WaitForSeconds(0.7f);

            audioToBePlayed.clip = diceRoll;
            audioToBePlayed.PlayDelayed(0.75f);
            
		}

	}
	public void TurnBack(){
		move=true;
	}
}
