using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class WorldSelectSlide : MonoBehaviour {
    
    public Scrollbar Slider;
    public List<Button> LevelButtons;
    public bool move;
	// Update is called once per frame
	void Update () {
		
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
        /*
        //para teste no pc
        if (Input.GetButtonDown("Fire1"))
        {
            move = false;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            move = true;
        }*/
        
        if (move)
        {
            if (Slider.GetComponent<Scrollbar>().value < 0.25f)
            {
                Slider.GetComponent<Scrollbar>().value = Mathf.Lerp(Slider.GetComponent<Scrollbar>().value, 0, 0.1f);
            }
            /*else if (Slider.GetComponent<Scrollbar>().value > 0.125f && Slider.GetComponent<Scrollbar>().value < 0.375f)
            {
                Slider.GetComponent<Scrollbar>().value = Mathf.Lerp(Slider.GetComponent<Scrollbar>().value, 0.25f, 0.1f);
            }*/
            else if (Slider.GetComponent<Scrollbar>().value >= 0.25f && Slider.GetComponent<Scrollbar>().value < 0.75f)
            {
                Slider.GetComponent<Scrollbar>().value = Mathf.Lerp(Slider.GetComponent<Scrollbar>().value, 0.5f, 0.1f);
            }
/*else if (Slider.GetComponent<Scrollbar>().value > 0.675f && Slider.GetComponent<Scrollbar>().value < 0.875f)
            {
                Slider.GetComponent<Scrollbar>().value = Mathf.Lerp(Slider.GetComponent<Scrollbar>().value, 0.75f, 0.1f);
            }*/
            else if (Slider.GetComponent<Scrollbar>().value >= 0.75 && Slider.GetComponent<Scrollbar>().value <= 1f)
            {
                Slider.GetComponent<Scrollbar>().value = Mathf.Lerp(Slider.GetComponent<Scrollbar>().value, 1, 0.1f);
            }
        }

		if (Slider.GetComponent<Scrollbar>().value < 0.25f)
		{
			LevelButtons[0].transform.localScale = Vector2.Lerp(LevelButtons[0].transform.localScale, new Vector2(1.5f,1.5f),0.1f);
			LevelButtons[1].transform.localScale = Vector2.Lerp(LevelButtons[1].transform.localScale, new Vector2(1.2f,1.2f),0.1f);
			LevelButtons[2].transform.localScale = Vector2.Lerp(LevelButtons[2].transform.localScale, new Vector2(1.2f,1.2f),0.1f);
		}
		else if (Slider.GetComponent<Scrollbar>().value >= 0.25f && Slider.GetComponent<Scrollbar>().value < 0.75f)
		{
			LevelButtons[0].transform.localScale = Vector2.Lerp(LevelButtons[0].transform.localScale, new Vector2(1.2f,1.2f),0.1f);
			LevelButtons[1].transform.localScale = Vector2.Lerp(LevelButtons[1].transform.localScale, new Vector2(1.5f,1.5f),0.1f);
			LevelButtons[2].transform.localScale = Vector2.Lerp(LevelButtons[2].transform.localScale, new Vector2(1.2f,1.2f),0.1f);
			
		}
		else if (Slider.GetComponent<Scrollbar>().value >= 0.75 && Slider.GetComponent<Scrollbar>().value <= 1f)
		{
			LevelButtons[0].transform.localScale = Vector2.Lerp(LevelButtons[0].transform.localScale, new Vector2(1.2f,1.2f),0.1f);
			LevelButtons[1].transform.localScale = Vector2.Lerp(LevelButtons[1].transform.localScale, new Vector2(1.2f,1.2f),0.1f);
			LevelButtons[2].transform.localScale = Vector2.Lerp(LevelButtons[2].transform.localScale, new Vector2(1.5f,1.5f),0.1f);
		}
	}
}
