using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour
{
    public GameObject testCard;
    GameObject[] mapButtons;
    int[] catList;
    public GameObject catCard;
    public int testStat;
    public int diceNumberRandomizer;
    public int testDif;
    public bool defined = false;
    public Text testText;
	int diceRoll, diceNumber;
	string catTested, diceInfo;
	int testSuccessCounter = 0; 
	int diceTestRoll;
	bool testSuccess = false;

    void Start()
    {
         mapButtons = GameObject.FindGameObjectsWithTag("Map Button");
    }

    public void TestGeneration(int currentLevel)
    {
        if (!defined) {
            testStat = Random.Range(0, 3); //0 = Braveness, 1 = Agility, 2 = Cuteness
        
            diceNumberRandomizer = Random.Range(currentLevel - 2, currentLevel + 1); //Randomizes the test dice amount
            if (diceNumberRandomizer < 1) diceNumberRandomizer = 1;

            testDif = Random.Range(2, 7); //Randomizes the test difficulty

            defined = true;

            ChangeButtonText(testStat);
            PlayTestAnimation(testStat);
        }
    }

    public void ChangeButtonText(int testStat)
    {
        Debug.Log(testStat);
        switch (testStat)
        {
            case 0: //braveness
                testText.text = "D:" + diceNumberRandomizer + "\nB:" + testDif;
                Debug.Log("Changing Text");
                break;

            case 1: //agility
                testText.text = "D:" + diceNumberRandomizer + "\nA:" + testDif;
                Debug.Log("Changing Text");
                break;

            case 2: //cuteness
                testText.text = "D:" + diceNumberRandomizer + "\nC:" + testDif;
                Debug.Log("Changing Text");
                break;
        }
    }

    public void PlayTestAnimation(int testStat)
    {
        testCard.GetComponent<Animator>().Play("Show");
        foreach (GameObject obj in mapButtons)
        {
            obj.GetComponent<Button>().interactable = false;
        }
    }

    public void CatSelection(int selectedCat)
    {

		switch(selectedCat){
			case 1:
				catTested = ButtonController.cat1;
				break;

			case 2:
				catTested = ButtonController.cat2;
				break;

			case 3:
				catTested = ButtonController.cat3;
				break;
		}

		diceNumber = int.Parse(catTested.Substring(testStat,1));
		print("N de dados: " + diceNumber);
        testCard.GetComponent<Animator>().Play("CatSelection");
		for (int i = 0; i < diceNumber; i++)
		{
			diceTestRoll = Random.Range(1, 7);
			diceInfo+=diceTestRoll;
			print ("Resultado da Rolagem: "+diceTestRoll);
			if (diceTestRoll >= testDif) testSuccessCounter += 1;
				
			if (testSuccessCounter >= diceNumberRandomizer) 
			{
				testSuccess = true;
				print("Success!");
		  	}
		}
		GameObject.Find("Main Camera").GetComponent<DiceRoll>().StartRoll(diceNumber,diceInfo);

	}
}
