﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactsHandler : MonoBehaviour
{

    public static bool artifactOn, diceBonus;
    public static int bonusValue, bonusAtb, diceBonusValue; //0 = Braveness, 1 = Agility, 2 = Cuteness


    public void bravenessNumericBonus(int bonusAmount)
    {
        artifactOn = true;
        print("Braveness Bonus");

        bonusAtb = 0; //Braveness
        bonusValue = bonusAmount;
    }

    public void agilityNumericBonus(int bonusAmount)
    {
        artifactOn = true;
        print("Agility Bonus");

        bonusAtb = 1; //Agility
        bonusValue = bonusAmount;
    }

    public void cutenessNumericBonus (int bonusAmount)
    {
        artifactOn = true;
        print("Cuteness Bonus");

        bonusAtb = 2; //Cuteness
        bonusValue = bonusAmount;
    }

    public void diceBonusIncreaser (int extraDiceAmount)
    {
        artifactOn = true;
        print("Dice Bonus");

        diceBonus = true; 
        diceBonusValue = extraDiceAmount;
    }

    public void resetDisabledCat()
    {
        print("Reset Disabled Cat");
        GameplayVariableHandler.lastUsedCat = 3;
    }

    public void healLife(int healAmount)
    {
        print("Heal Life");
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

