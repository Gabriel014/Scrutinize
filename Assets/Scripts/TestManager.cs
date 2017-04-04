using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TestManager : MonoBehaviour
{
    public GameObject testCard, challengeButton, catCard, okButton, battleOkButton;
    public GameObject[] mapButtons, battlingCatImage;
    int[] catList;
    GameObject currentMonsterButton;
    public int testStat, diceNumberRandomizer, testDif;
    public List<Sprite> catImage, challengeImage;
    public bool defined = false;
    public Text testText, dicesNumber, testNumber, testResult;
    public Button cat1Button, cat2Button, cat3Button;
    int diceRoll, diceNumber = 0, playerBiggestDice = 0, monsterBiggestDice = 7, 
        diceTestRoll = 0, battlingCat, monsterDif, testSuccessCounter = 0;
	string catTested, diceInfo, bossDiceInfo;
    bool testSuccess = false;

    void Start()
    {
		cat1Button.GetComponent<Image>().sprite=ButtonController.catThumb1;
		cat2Button.GetComponent<Image>().sprite=ButtonController.catThumb2;
		cat3Button.GetComponent<Image>().sprite=ButtonController.catThumb3;
        mapButtons = GameObject.FindGameObjectsWithTag("Map Button");
    }

    void Update()
    {
        battlingCatImage = GameObject.FindGameObjectsWithTag("Battling Cat");
    }

    public void TestGeneration(int currentLevel)
    {
        if (!defined)
        {
            testStat = Random.Range(0, 3); //0 = Braveness, 1 = Agility, 2 = Cuteness

            diceNumberRandomizer = Random.Range(currentLevel-2 , currentLevel + 1); //Randomizes the test dice amount
            if (diceNumberRandomizer < 1) diceNumberRandomizer = 1;

            testDif = Random.Range(2, 7); //Randomizes the test difficulty

            defined = true;

            ChangeButtonText(testStat);
            PlayTestAnimation(testStat);
        }

        else PlayTestAnimation(testStat);
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

        cat1Button.interactable = true;
        cat2Button.interactable = true;
        cat3Button.interactable = true;

        if (GameplayVariableHandler.cat1Life <= 0) cat1Button.interactable = false;
        if (GameplayVariableHandler.cat1Life <= 0) cat1Button.interactable = false;
        if (GameplayVariableHandler.cat1Life <= 0) cat1Button.interactable = false;

        //Temporarily enable all cats buttons but just if its life is not 0, if it is then disable it

        switch (GameplayVariableHandler.lastUsedCat)
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

        testSuccessCounter = 0;

        battlingCat = selectedCat; //Sets the selected cat as the cat who will be used during battle

        switch (selectedCat) { //Changes the catTested with the parameters from the cat allocated in each cat spot
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
		diceInfo="";
        diceNumber += int.Parse(catTested.Substring(testStat, 1)); 
        //The number of dices will be equal to the cat atb on the atb being tested
        if (ArtifactsHandler.diceBonus) diceNumber += ArtifactsHandler.diceBonusValue;
        //If there is any dice bonus artifact, add the amount of bonus dice on the total dices which will be rolled
        print("N de dados: " + diceNumber);
        testCard.GetComponent<Animator>().Play("CatSelection");
        for (int i = 0; i < diceNumber; i++)
        {
            diceTestRoll += Random.Range(1, 7); //Roll a d6 
            if (ArtifactsHandler.bonusAtb == testStat) diceTestRoll += ArtifactsHandler.bonusValue;
            //If the atb being tested is equal the current atb getting a bonus, add that bonus on the dice result
            if (diceTestRoll > 6) diceTestRoll = 6;
            diceInfo += diceTestRoll;
            print("Resultado da Rolagem: " + diceTestRoll);
            if (diceTestRoll >= testDif) testSuccessCounter += 1;
            diceTestRoll = 0; //Resets the value of the rolled number
        }
        ArtifactsHandler.resetBonuses(); //Reset all bonus added in this test

        if (testSuccessCounter >= diceNumberRandomizer)
        {
            testSuccess = true;
            testResult.color = Color.green;
            testResult.text = "Success!!";
        }
        

        if (!testSuccess)
        {
            testResult.color = Color.red;
            testResult.text = "Fail!!";

            switch (selectedCat)
            { 
                case 0:
                    GameObject.Find("Main Camera").GetComponent<GameplayVariableHandler>().changeLife(false, 0, 1);
                    break;
                case 1:
                    GameObject.Find("Main Camera").GetComponent<GameplayVariableHandler>().changeLife(false, 1, 1);
                    break;
                case 2:
                    GameObject.Find("Main Camera").GetComponent<GameplayVariableHandler>().changeLife(false, 2, 1);
                    break;
            }
        }

        okButton.transform.localScale = new Vector3(1.5f, 1.5f, 1f);

        GameObject.Find("Main Camera").GetComponent<DiceRoll>().RollDices("test",diceNumber, diceInfo, testDif);
        GameplayVariableHandler.lastUsedCat = selectedCat; //Sets the disabled cat for the next challenge (the cat used this turn)
    }

    public void ChangeCardImage()
    {
        //In case more cats are added, we have to increase the cases number!!!
        int catId = int.Parse(catTested.Substring(3, 1));

        switch (catId)
        {
            case 1:
                catCard.GetComponent<Image>().sprite = catImage[0];
                foreach (GameObject obj in battlingCatImage) obj.GetComponent<Image>().sprite = catImage[0];
                break;

            case 2:
                catCard.GetComponent<Image>().sprite = catImage[1];
                foreach (GameObject obj in battlingCatImage) obj.GetComponent<Image>().sprite = catImage[1];
                break;

            case 3:
                catCard.GetComponent<Image>().sprite = catImage[2];
                foreach (GameObject obj in battlingCatImage) obj.GetComponent<Image>().sprite = catImage[2];
                break;

            case 4:
                catCard.GetComponent<Image>().sprite = catImage[3];
                foreach (GameObject obj in battlingCatImage) obj.GetComponent<Image>().sprite = catImage[3];
                break;

            case 5:
                catCard.GetComponent<Image>().sprite = catImage[4];
                foreach (GameObject obj in battlingCatImage) obj.GetComponent<Image>().sprite = catImage[4];
                break;
        }
    }

    public void OkButton()
    {
        diceNumber = 0;
        GameObject[] diceList = GameObject.FindGameObjectsWithTag("dice");
        testResult.enabled = false;

        foreach (GameObject obj in diceList)
        {
            Destroy(obj);
        }

        okButton.transform.localScale = new Vector3(0f, 0f, 0f);

        foreach (GameObject obj in mapButtons)
        {
            obj.GetComponent<Button>().interactable = true; //Enable all other buttons
        }

        if (testSuccess)
        {
            testText.text = "";
            gameObject.transform.localScale = new Vector3(0f, 0f);
            testCard.GetComponent<Animator>().Play("New State");
            //The artifact/trap/creature randomizer must be done in this if
        }
        else
        {
            //Reset all animations
            testCard.GetComponent<Animator>().Play("New State");
        }
    }

    public void BattleManager(GameObject monsterButton) {

        currentMonsterButton = monsterButton;

        testSuccess = false;

        //monsterButton.GetComponent<Animator>().Play("bossAnimation");

        monsterBiggestDice = 0;
        playerBiggestDice = 0;

		if (monsterButton.tag == "boss1") monsterDif = 3;
        if (monsterButton.tag == "boss2") monsterDif = 4;
        //Add monster difficult for each monster prefab according to its name

        print("Dificuldade do Monstro: " + monsterDif);

        switch (battlingCat)
        { //Changes the catTested with the parameters from the cat allocated in each cat spot
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


        diceNumber += int.Parse(catTested.Substring(testStat, 1));
        //The number of dices will be equal to the cat atb on the atb being tested
        if (ArtifactsHandler.diceBonus) diceNumber += ArtifactsHandler.diceBonusValue;
        //If there is any dice bonus artifact, add the amount of bonus dice on the total dices which will be rolled

        print("N de dados: " + diceNumber);
		bossDiceInfo="";

        for (int i = 0; i < monsterDif; i++)
        {
            diceTestRoll = Random.Range(1, 7);
			bossDiceInfo+=diceTestRoll;
            print("Monster Roll" + diceTestRoll);
            if (diceTestRoll > monsterBiggestDice) monsterBiggestDice = diceTestRoll;
        }

		GameObject.Find("Main Camera").GetComponent<DiceRoll>().RollDices("boss",monsterDif, bossDiceInfo,monsterBiggestDice);

        diceInfo = "";
        for (int i = 0; i < diceNumber; i++)
        {
            diceTestRoll += Random.Range(1, 7); //Roll a d6 
            if (ArtifactsHandler.bonusAtb == testStat) diceTestRoll += ArtifactsHandler.bonusValue;
            //If the atb being tested is equal the current atb getting a bonus, add that bonus on the dice result
            if (diceTestRoll > 6) diceTestRoll = 6;
            diceInfo += diceTestRoll;
            if (diceTestRoll > playerBiggestDice) playerBiggestDice = diceTestRoll;
            diceTestRoll = 0; //Resets the value of the rolled number
        }
        ArtifactsHandler.resetBonuses(); //Reset all bonus added in this test

        print("Player Biggest Dice:" + playerBiggestDice + "||| Monster Biggest Dice:" + monsterBiggestDice);
        if (playerBiggestDice >= monsterBiggestDice) testSuccess = true;

        if (testSuccess)
        {
            testResult.color = Color.green;
            testResult.text = "You win!!";
        }

        else
        {
            testResult.color = Color.red;
            testResult.text = "You lose!!";
        }

		GameObject.Find("Main Camera").GetComponent<DiceRoll>().RollDices("player",diceNumber, diceInfo, monsterBiggestDice);

        if (!testSuccess) {
            switch (battlingCat)
            {
                case 0:
                    GameObject.Find("Main Camera").GetComponent<GameplayVariableHandler>().changeLife(false, 0, 1);
                    break;
                case 1:
                    GameObject.Find("Main Camera").GetComponent<GameplayVariableHandler>().changeLife(false, 1, 1);
                    break;
                case 2:
                    GameObject.Find("Main Camera").GetComponent<GameplayVariableHandler>().changeLife(false, 2, 1);
                    break;
            }
        }

        else
        {
            PlayerPrefs.SetInt("gold", PlayerPrefs.GetInt("gold") + Random.Range(20, 50));
            print("Battle Successful!");
        }

        battleOkButton.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
    }

    public void BattleOkButton()
    {
        diceNumber = 0;
        GameObject[] diceList = GameObject.FindGameObjectsWithTag("dice");
        testResult.enabled = false;

        foreach (GameObject obj in diceList)
        {
            Destroy(obj);
        }

        battleOkButton.transform.localScale = new Vector3(0f, 0f, 0f);

        foreach (GameObject obj in mapButtons)
        {
            obj.GetComponent<Button>().interactable = true; //Enable other buttons
        }

        if (testSuccess)
        {
            //The artifact/trap/creature randomizer must be done in this if
           // Destroy(currentMonsterButton);
            //Destroy(gameObject);
			currentMonsterButton.GetComponent<GameObject>();
			currentMonsterButton.SetActive(false);
        }
        else
        {
            //Reset all animations

			/*Animator anim=currentMonsterButton.GetComponent<Animator>();
			anim.speed=-1f;
			anim.Play("bossAnimation");
			//animation["bossAnimation"].t = 5.0f;
			currentMonsterButton.GetComponent<RewardsController>().TurnBack();
			//currentMonsterButton.GetComponent<Animator>().enabled=false;*/
			currentMonsterButton.GetComponent<GameObject>();
			currentMonsterButton.SetActive(false);
        }
    }
}