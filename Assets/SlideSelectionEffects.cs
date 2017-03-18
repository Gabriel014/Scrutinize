using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class SlideSelectionEffects : MonoBehaviour {
    
    public Scrollbar Slider;
    public List<Button> LevelButtons;
    public bool move;
	float intervals;
	float buttonsNumbers;

	void Start()
	{
		buttonsNumbers = LevelButtons.Count-1;
		intervals = (float)((1/buttonsNumbers)/2);
	}
	// Update is called once per frame
	void Update () {
		
		//PARA ANDROID
		/*
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);

            //se o player toca na tela, cancela o movimento dos botoes
            if (t.phase == TouchPhase.Began)
            {
                move = false;
            }
            //quando o player solta a tela, a animação executa
            if (t.phase == TouchPhase.Ended)
            {
                move = true;
            }
        }
		*/
        //para teste no pc
        if (Input.GetButtonDown("Fire1"))
        {
            move = false;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            move = true;
        }
        
        if (move)
        {
			print(intervals);
			for (int i = 0; i < LevelButtons.Count; i++)
			{
				if (Slider.GetComponent<Scrollbar>().value <  intervals+((1/buttonsNumbers)*i))
            	{
					Slider.GetComponent<Scrollbar>().value = Mathf.Lerp(Slider.GetComponent<Scrollbar>().value, (1/buttonsNumbers)*i, 0.2f);

					for (int j = 0; j < LevelButtons.Count; j++)
					{
						if (i==j) LevelButtons[j].transform.localScale = Vector2.Lerp(LevelButtons[j].transform.localScale, new Vector2(1.2f,1.2f),0.1f);
						if (i!=j) LevelButtons[j].transform.localScale = Vector2.Lerp(LevelButtons[j].transform.localScale, new Vector2(1.0f,1.0f),0.1f);
					}
					break;
            	}

			}

		}
	}
}
