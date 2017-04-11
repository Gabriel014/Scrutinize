using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayVariableHandler : MonoBehaviour
{

    public static int cat1Life = 4, cat2Life = 4, cat3Life = 4, lastUsedCat = 3;

    public void disableCat(int cat)
    { 
            switch (cat)
            {
                case 0:
                    lastUsedCat = 0;
                    break;
                case 1:
                    lastUsedCat = 1;
                    break;
                case 3:
                    lastUsedCat = 2;
                    break;
            }
        }

    public void changeLife(bool increase, int cat, int amount)
    {
        if (increase)
        {
            switch (cat)
            {
                case 0:
                    cat1Life += amount;
                    break;
                case 1:
                    cat2Life += amount;
                    break;
                case 2:
                    cat3Life += amount;
                    break;
            }
        }

        else
        {
            switch (cat)
            {
                case 0:
                    cat1Life -= amount;
                    break;
                case 1:
                    cat2Life -= amount;
                    break;
                case 2:
                    cat3Life -= amount;
                    break;
            }
        }

    }
}
