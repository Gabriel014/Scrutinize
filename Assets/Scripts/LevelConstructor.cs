using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelConstructor : MonoBehaviour {
	public int foodsNumber, itensNumber, trapsNumber, bossNumber;
	public List<GameObject> foods,itens, traps, boss;
	[SerializeField]
	List<int> objectsToSort;
	[SerializeField]
	List<GameObject> selectedObjects;
	public List <float> positionsX,positionsY;

	// Use this for initialization
	void Start () 
	{
		objectsToSort = new List<int>(){foodsNumber, itensNumber, trapsNumber, bossNumber};
		selectedObjects = new List<GameObject>(){};

		for (int i=0; i < objectsToSort.Count; i++)
		{
			for(int j=0; j<objectsToSort[i]; j++)
			{
				switch(i)
				{
				case 0:
					selectedObjects.Add(foods[Random.Range(0,itens.Count)]);
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
		SortList();
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
		InstantiateObjects();
	}

	void InstantiateObjects()
	{
		for(int i=0; i<selectedObjects.Count;i++){
			GameObject temp = Instantiate(selectedObjects[i]) as GameObject;
			temp.transform.parent = GameObject.Find("Canvas").transform;
			temp.GetComponent<RectTransform>().localPosition = new Vector2(positionsX[i],positionsY[i]);
			selectedObjects[i]=temp;
		}
	}
}
