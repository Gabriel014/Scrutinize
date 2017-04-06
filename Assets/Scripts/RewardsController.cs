using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardsController : MonoBehaviour {
    [HideInInspector]
    public string type;
	public int subType;
	public float speed;
	bool move=false;
	float step;
	[HideInInspector]
	public Transform initialPosition;
	public Sprite cardImage;
    [Header("Audio Settings")]
    public AudioClip cardFlip;
    public AudioClip battleCry, diceRoll;
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
			step = speed*30*Time.deltaTime;
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
			yield return new WaitUntil(()=>Vector3.SqrMagnitude(transform.position - new Vector3(0,0,0))<0.0001);
			gameObject.GetComponent<Animator>().enabled=true;
			//gameObject.GetComponent<Animator>().SetBool("Flip", true);
			yield return new WaitUntil(()=>transform.eulerAngles.y>=89);
			gameObject.GetComponent<Image>().sprite=cardImage;
			yield return new WaitUntil(()=>transform.eulerAngles.y<=0.2);
			gameObject.GetComponent<Animator>().SetBool("ZoomCard",true);
			yield return new WaitUntil(()=>transform.localScale.y >=15f);
			gameObject.GetComponent<Animator>().SetBool("GoToBag", true);
			yield return new WaitUntil(()=>transform.localScale.y <=0.1f);
			gameObject.SetActive(false);
			//GameObject.Find("Inventory Button").GetComponent<InventoryManager>().AddItem(gameObject);
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
