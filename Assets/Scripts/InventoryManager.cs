using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {
	public List<GameObject> itens;
	[HideInInspector]
	public List<int> index;
	public GameObject item1,item2,item3;
	public Sprite inventoryBg;
	// Use this for initialization
	void Start ()
	{
		itens = new List<GameObject>(){item1,item2,item3};
		index = new List<int>(){0,0,0};
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddItem(GameObject item)
	{
		bool added = false;
		for(int i = 0; i<itens.Count; i++)
		{
			if(index[i]==0&&!added)
			{
				itens[i].GetComponent<Image>().sprite=item.GetComponent<Image>().sprite;
				itens[i].GetComponent<BagItemController>().EffectSet(item,i);
				index[i]=1;
				added=true;
				break;
			}
		}
	}


}