using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactsHandler : MonoBehaviour
{

    public static bool artifactOn, diceBonus;
    public static int bonusValue, bonusAtb, diceBonusValue; //0 = Braveness, 1 = Agility, 2 = Cuteness


    public void bravenessNumericBonus(int bonusAmount)
    {
        artifactOn = true;

        bonusAtb = 0; //Braveness
        bonusValue = bonusAmount;
    }

    public void agilityNumericBonus(int bonusAmount)
    {
        artifactOn = true;

        bonusAtb = 1; //Agility
        bonusValue = bonusAmount;
    }

    public void cutenessNumericBonus (int bonusAmount)
    {
        artifactOn = true;

        bonusAtb = 2; //Cuteness
        bonusValue = bonusAmount;
    }

    public void diceBonusIncreaser (int extraDiceAmount)
    {
        artifactOn = true;

        diceBonus = true; 
        diceBonusValue = extraDiceAmount;
    }

    public void resetDisabledCat()
    {
        GameplayVariableHandler.lastUsedCat = 3;
    }

    public void healLife(int healAmount)
    {
        GameplayVariableHandler.cat1Life += healAmount;
        GameplayVariableHandler.cat2Life += healAmount;
        GameplayVariableHandler.cat3Life += healAmount;

    }

    public static void resetBonuses()
    {
        artifactOn = false;
        bonusValue = 0;
        diceBonus = false;
    }
}

