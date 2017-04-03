using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour {
	public GameObject dicePrefab;
	public List<GameObject> catDices,bossDices;
	public List<Sprite> diceSides;
	float catDiceposition,bossDiceposition;
    public Text testResult;
	Transform t;
	///<summary>type ="test" "boss" ou "player", <para></para>
	///diceNumber = numero de dados,<para></para>
	///diceInfos = valores dos dados,<para></para>
	///testDif = dificuldade do teste (maior dado para o boss) </summary>
	public void RollDices(string type, int diceNumber, string diceInfos, int testDif){
		
		t=GameObject.Find("Canvas").GetComponent<Transform>();
		if(type=="player"||type=="test")StartCoroutine(StartRollPlayer(type, diceNumber,diceInfos,testDif));
		if(type=="boss")StartCoroutine(StartRollBoss(diceNumber,diceInfos,testDif));
	}

	public IEnumerator StartRollPlayer(string type, int diceNumber, string diceInfos, int testDif)
	{
		if(type=="player")yield return new WaitForSeconds(3);
        catDiceposition = 7;
		catDices.Clear();
		for(int i = 0; i < diceNumber; i++)
		{
			catDices.Add(dicePrefab);
		}
		for(int i = 0; i < catDices.Count; i++)
		{
			
			catDices[i] = Instantiate(Resources.Load("Dice"),new Vector3(catDiceposition,-4.3f,1),Quaternion.identity,t) as GameObject;
			catDices[i].transform.localScale= new Vector3(30,30,1);
	
			catDiceposition-=1.6f;

			yield return new WaitForSeconds(1);

			catDices[i].GetComponent<Animator>().enabled=false;
			catDices[i].GetComponent<Image>().sprite = diceSides[int.Parse(diceInfos.Substring(i,1))-1];

		}

		yield return new WaitForSeconds(0.5f);

		for(int i = 0; i < catDices.Count; i++)
		{
			if(int.Parse(diceInfos.Substring(i,1))>=testDif) catDices[i].GetComponent<Image>().color = new Color32 (0,195,0,255);
			else catDices[i].GetComponent<Image>().color = new Color32 (195,0,0,255);
		}

        testResult.enabled = true;
		GameObject.Find("Cats_HUD").GetComponent<CatUIController>().LifechangeAnimation();
        print(catDices.Count);
		print("numero de dados: "+diceNumber+"; rolagens: "+diceInfos);
	}
	public IEnumerator StartRollBoss(int diceNumber, string diceInfos, int testDif)
	{

		bossDiceposition = -7;
		bossDices.Clear();
		for(int i = 0; i < diceNumber; i++)
		{
			bossDices.Add(dicePrefab);
		}
		for(int i = 0; i < bossDices.Count; i++)
		{

			bossDices[i] = Instantiate(Resources.Load("Dice"),new Vector3(bossDiceposition,-4.3f,1),Quaternion.identity,t) as GameObject;
			bossDices[i].transform.localScale= new Vector3(30,30,1);

			bossDiceposition+=1.6f;

			yield return new WaitForSeconds(1);

			bossDices[i].GetComponent<Animator>().enabled=false;
			bossDices[i].GetComponent<Image>().sprite = diceSides[int.Parse(diceInfos.Substring(i,1))-1];
		}

		yield return new WaitForSeconds(0.5f);
			
		for(int i = 0; i < bossDices.Count; i++)
		{
			if(int.Parse(diceInfos.Substring(i,1))>=testDif) bossDices[i].GetComponent<Image>().color = new Color32 (0,195,0,255);
		}
	}
}

