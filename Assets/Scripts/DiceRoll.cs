using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour {
	public GameObject dicePrefab;
	public List<GameObject> dices;
	public List<Sprite> diceSides;
	float position = 353;
    public Text testResult;

	public void RollDices(int diceNumber, string diceInfos, int testDif){
		
		StartCoroutine(StartRoll(diceNumber,diceInfos,testDif));
	}

	public IEnumerator StartRoll(int diceNumber, string diceInfos, int testDif)
	{
        position = 353;
		dices.Clear();
		for(int i = 0; i < diceNumber; i++)
		{
			dices.Add(dicePrefab);
		}
		for(int i = 0; i < dices.Count; i++)
		{
			
			dices[i] = Instantiate(Resources.Load("Dice")) as GameObject;
			//dices[i].transform.parent = GameObject.Find("Canvas").transform;
			dices[i].transform.SetParent(GameObject.Find("Canvas").transform,true);
			dices[i].transform.localScale= new Vector3(30,30,1);
			dices[i].GetComponent<RectTransform>().localPosition= new Vector3(position,-206,1);
			position-=90f;

			yield return new WaitForSeconds(1);

			dices[i].GetComponent<Animator>().enabled=false;
			dices[i].GetComponent<Image>().sprite = diceSides[int.Parse(diceInfos.Substring(i,1))-1];

			if(int.Parse(diceInfos.Substring(i,1))>=testDif) dices[i].GetComponent<Image>().color = new Color32 (146,255,118,255);
			else dices[i].GetComponent<Image>().color = new Color32 (255,118,118,255);
			}
        testResult.enabled = true;
        print(dices.Count);
		print("numero de dados: "+diceNumber+"; rolagens: "+diceInfos);

	}
}

