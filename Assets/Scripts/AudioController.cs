using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public GameObject audioButton;
    public Sprite buttonOn, buttonOff;

    // Use this for initialization
    void Awake()
    {
        string music = PlayerPrefs.GetString("music", "on");

        if (music == "on")
        {
            audioButton.GetComponent<Image>().sprite = buttonOn;
            AudioListener.volume = 1f;
        }
        else
        {
            audioButton.GetComponent<Image>().sprite = buttonOff;
            AudioListener.volume = 0f;
        }

    }
    
    public void pressed()
    {
        if (AudioListener.volume > 0)
        {
            AudioListener.volume = 0f;
            audioButton.GetComponent<Image>().sprite = buttonOff;
            PlayerPrefs.SetString("music", "off");
        }

        else
        {
            AudioListener.volume = 1f;
            audioButton.GetComponent<Image>().sprite = buttonOn;
            PlayerPrefs.SetString("music", "on");
        }
    }
}