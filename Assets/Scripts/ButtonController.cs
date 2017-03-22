using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {
	public List<int> index;
	public List<string> selectedCats;
	public List<Image> catThumb;
	public List<Sprite> catSprites;
	bool isOnList;
	public static string cat1, cat2, cat3;


	public void Pressed(string card) //string contém 4 numeros sendo força, agilidade, fofura e ID respectivamente.
	{
		isOnList = false;
		for(int i = 0; i < 3; i++)
		{
			if(index[i] == int.Parse(card.Substring(3)))//procura se o card já está na lista
			{
				isOnList = true;//indica que o carda ja está na lista
				index[i] = 0; // se ele já está na lista e foi clicado novamene, significa que foi desmarcado. Logo, tem que ser removido;
				selectedCats[i] = "";
				catThumb[i].GetComponent<Image>().sprite=catSprites[0]; //zera a thumbnail da hud nesta posição
				break; //finaliza o evento
			}
		}
		if(!isOnList)//se o card nao está na lista
		{
			for(int i = 0; i < 3; i++) 
			{
				if(index[i]==0)//procura-se um espaço vazio
				{
					index[i] = int.Parse(card.Substring(3));// e adiciona-se este card na lista
					selectedCats[i] = card.Substring(0,4);
					print(i+" index "+selectedCats[i]);
					catThumb[i].GetComponent<Image>().sprite=catSprites[int.Parse(card.Substring(3))];//coloca a thumbnail do personagem que foi selecionado;
					break;
				}
			}
		}
	}
		

	public void ConfirmSelection()
	{
		cat1 = selectedCats[0];
		cat2 = selectedCats[1];
		cat3 = selectedCats[2];

	}

}
