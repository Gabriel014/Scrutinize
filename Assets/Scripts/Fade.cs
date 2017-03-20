using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public Texture2D fadeTexture;   // textura de cor preta do fade
    public float fadeSpeed = 1.5f;  //velocidade do fade

    private int drawDepth = -1000, fadeDirection = -1;   //ordem da textura hierarquia, direção do fade -1 = in e 1 = out
    private float alpha = 1.0f;                          //transparencia da textura

    //inicia no awake para evitar que a cena inicie antes do fade in
    void Start()
    {
        BeginFade(-1);
    }

    void OnGUI()
    {
        //muda o alpha da textura em relação ao delta time com o limite de 1  e 0
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;
        //limita o valor entre 1 e 0
        alpha = Mathf.Clamp01(alpha);
        //desenha o canvas com textura preta do tamanho da tela
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }

    //muda para fade in ou fade out 
    public float BeginFade(int direction)
    {
        fadeDirection = direction;
        return (1/fadeSpeed);
    }

 
}