using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConstructor : MonoBehaviour {
	public int foodsNumber, itensNumber, trapsNumber, bossNumber;// quantidade de cada item na fase
	public List<GameObject> foods,itens, traps, boss;// lista com os prefabs de cada tipo de carta
	[SerializeField]
	List<int> objectsToSort;//lista com os numeros de  objetos que serão selecionados na fase
	[SerializeField]
	List<GameObject> selectedObjects;//lista com os objetos selecinados
	public List <float> positionsX,positionsY;//posições de cada objeto tanto no x quanto no y

	// Use this for initialization
	void Start () 
	{
		objectsToSort = new List<int>(){foodsNumber, itensNumber, trapsNumber, bossNumber};//a quantidade de cada objeto será adicionada em um lista para assim selecionar todos de uma só vez 
		selectedObjects = new List<GameObject>(){};//limpa a lista de objetos selecionados

		for (int i=0; i < objectsToSort.Count; i++)//para cada tipo de objeto
		{
			for(int j=0; j<objectsToSort[i]; j++)//enquanto a quantidade de objetos selecinados for menor que o total informado em foodsNumber, itensNumber, trapsNumber e bossNumber
			{
				switch(i)//adiciona um prefab random respectivo
				{
				case 0:
					selectedObjects.Add(foods[Random.Range(0,foods.Count)]);
					break;
				case 1:
					selectedObjects.Add(itens[Random.Range(0,itens.Count)]);
					break;
				case 2:
					selectedObjects.Add(traps[Random.Range(0,traps.Count)]);	
					break;
				case 3:
					selectedObjects.Add(boss[Random.Range(0,boss.Count)]);	
					break;
				}
			}
		}
		SortList();//randomiza a lista
	}

	void SortList()
	{
		for(int i = 0; i<selectedObjects.Count;i++)
		{
			GameObject temp = selectedObjects[i];
			int randomIndex = Random.Range(i, selectedObjects.Count);
			selectedObjects[i] = selectedObjects[randomIndex];
			selectedObjects[randomIndex] = temp;
		}
		InstantiateObjects();//istancia os objetos, coloca na hierarquia e na posição correta
	}

	void InstantiateObjects()
	{
		for(int i=0; i<selectedObjects.Count;i++){
			GameObject temp = Instantiate(selectedObjects[i]) as GameObject;
			temp.transform.SetParent(GameObject.Find("rewardCards").transform,true);
			temp.GetComponent<RectTransform>().localPosition = new Vector2(positionsX[i],positionsY[i]);
			selectedObjects[i]=temp;
		}
	}
}
