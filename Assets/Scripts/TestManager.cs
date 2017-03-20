using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestManager : MonoBehaviour
{

    public int testStat;
    public int diceNumberRandomizer;
    public int testDif;
    public bool defined = false;
    public Text testText;

    public void TestGeneration(int currentLevel)
    {
        if (!defined) {
            int testStat = Random.Range(1, 4); //1 = Braveness, 2 = Agility, 3 = Cuteness
        
            diceNumberRandomizer = Random.Range(currentLevel - 2, currentLevel + 2); //Randomizes the test dice amount
            if (diceNumberRandomizer < 1) diceNumberRandomizer = 1
                    ;
            testDif = Random.Range(1, 7); //Randomizes the test difficulty

            defined = true;

            ChangeButtonTest(testStat);
        }
    }

    public void ChangeButtonTest(int testStat)
    {
        Debug.Log(testStat);
        switch (testStat)
        {
            case 1: //braveness
                testText.text = "D:" + diceNumberRandomizer + "\nB:" + testDif;
                Debug.Log("Changing Text");
                break;

            case 2: //agility
                testText.text = "D:" + diceNumberRandomizer + "\nA:" + testDif;
                Debug.Log("Changing Text");
                break;

            case 3: //cuteness
                testText.text = "D:" + diceNumberRandomizer + "\nC:" + testDif;
                Debug.Log("Changing Text");
                break;
        }
    }

}
