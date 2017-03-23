using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceRoll : MonoBehaviour {
	public GameObject dicePrefab;
	public List<GameObject> dices;
	public List<Sprite> diceSides;
	float position = 7;

	public void StartRoll(int diceNumber, string diceInfos)
	{
		dices.Clear();
		for(int i = 0; i < diceNumber; i++)
		{
			dices.Add(dicePrefab);
		}
		for(int i = 0; i < dices.Count; i++)
		{
			dices[i] = Instantiate(Resources.Load("Dice")) as GameObject;
			dices[i].transform.parent = GameObject.Find("Canvas").transform;
			dices[i].transform.localScale= new Vector3(60,60,1);
			dices[i].transform.position= new Vector3(position,-4,1);
			position-=1.5f;
			dices[i].GetComponent<Image>().sprite = diceSides[int.Parse(diceInfos.Substring(i,1))-1];
		}

		print(dices.Count);
		print("numero de dados: "+diceNumber+"; rolagens: "+diceInfos);

	}
}
