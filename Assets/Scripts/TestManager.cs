using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour
{
    public GameObject testCard, challengeButton;
    GameObject[] mapButtons;
    int[] catList;
    public GameObject catCard, okButton;
    public int testStat, diceNumberRandomizer, testDif, cat1Life = 3, cat2Life = 3, cat3Life = 3;
    public List<Sprite> catImage, challengeImage;
    public bool defined = false;
    public Text testText, dicesNumber, testNumber, testResult;
    public Button cat1Button, cat2Button, cat3Button;
    int currentDisabledCat = 3, diceRoll, diceNumber, diceTestRoll, testSuccessCounter = 0;
    string catTested, diceInfo;
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
        switch (testStat) //Changes the test image according to the atb being tested
        {
            case 0:
                testCard.GetComponent<Image>().sprite = challengeImage[0];
                break;
            case 1:
                testCard.GetComponent<Image>().sprite = challengeImage[1];
                break;
            case 2:
                testCard.GetComponent<Image>().sprite = challengeImage[2];
                break;
        }


        dicesNumber.text = "" + diceNumberRandomizer; 
        testNumber.text = "" + testDif;
        //Changes the test values on the card

        if (cat1Life > 0) cat1Button.interactable = true; else cat1Button.interactable = false;
        if (cat2Life > 0) cat2Button.interactable = true; else cat2Button.interactable = false;
        if (cat3Life > 0) cat3Button.interactable = true; else cat3Button.interactable = false;
        //Temporarily enable all cats buttons but just if its life is not 0, if it is then disable it for good

        switch (currentDisabledCat)
        {
            case 0:
                cat1Button.interactable = false;
                break;
            case 1:
                cat2Button.interactable = false;
                break;
            case 2:
                cat3Button.interactable = false;
                break;
            case 3:
                break;
        }
        //Then disables the last used cat button

        testCard.GetComponent<Animator>().Play("Show"); //Play the animation which shows the challenge card
        foreach (GameObject obj in mapButtons)
        {
            obj.GetComponent<Button>().interactable = false; //Disable all other buttons but the cats
        }
    }

    public void CatSelection(int selectedCat)
    {

        switch (selectedCat){ //Changes the catTested with the parameters from the cat allocated in each cat spot
			case 0:
				catTested = ButtonController.cat1;
				break;

			case 1:
				catTested = ButtonController.cat2;
				break;

			case 2:
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
                testResult.color = Color.green;
                testResult.text = "Success!!";
		  	}
            else
            {
                testResult.color = Color.red;
                testResult.text = "Fail!!";
                //In case of fail, decreases this cat life
                switch (selectedCat)
                {
                    case 1:
                        cat1Life -= 1;
                        break;
                    case 2:
                        cat2Life -= 1;
                        break;
                    case 3:
                        cat3Life -= 1;
                        break;
                }
            }

            okButton.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
            
		}
		GameObject.Find("Main Camera").GetComponent<DiceRoll>().StartRoll(diceNumber,diceInfo);
        currentDisabledCat = selectedCat; //Sets the disabled cat for the next challenge (the cat used this turn)
	}

    public void ChangeCardImage()
    {
        //In case more cats are added, we have to increase the cases number!!!
        int catId = int.Parse(catTested.Substring(3, 1));

        switch (catId)
        {
            case 1:
                catCard.GetComponent<Image>().sprite = catImage[0];
                break;

            case 2:
                catCard.GetComponent<Image>().sprite = catImage[1];
                break;

            case 3:
                catCard.GetComponent<Image>().sprite = catImage[2];
                break;

            case 4:
                catCard.GetComponent<Image>().sprite = catImage[3];
                break;

            case 5:
                catCard.GetComponent<Image>().sprite = catImage[4];
                break;
        }
    }

    public void OkButton()
    {
        if (testSuccess)
        {
            //The artifact/trap/creature randomizer must be done in this if
            Destroy(challengeButton);
        }
        else
        {
            //Reset all animations
            testText.text = "?";
        }
    }
}
