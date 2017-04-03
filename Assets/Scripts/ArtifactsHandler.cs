using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtifactsHandler : MonoBehaviour
{

    public static bool bravenessBonus, agilityBonus, cutenessBonus, diceBonus;
    public static int bonusValue;


    void bravenessNumericBonus(int bonusAmount)
    {
        bravenessBonus = true;
        bonusValue = bonusAmount;
    }

    void agilityNumericBonus(int bonusAmount)
    {
        agilityBonus = true;
        bonusValue = bonusAmount;
    }

    void cutenessNumericBonus (int bonusAmount)
    {
        cutenessBonus = true;
        bonusValue = bonusAmount;
    }

    void diceBonusIncreaser (int extraDiceAmount)
    {
        diceBonus = true;
        bonusValue = extraDiceAmount;
    }

}

