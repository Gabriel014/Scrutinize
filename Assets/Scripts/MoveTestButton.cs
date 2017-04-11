using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTestButton : MonoBehaviour
{

    bool move = false;
    public Vector3 initialPosition;
    public GameObject thisButton;

    // Use this for initialization

    void Start()
    {
        initialPosition = thisButton.transform.parent.GetComponent<Transform>().position;
    }

    public void Clicked()
    {
        thisButton.transform.parent.transform.SetSiblingIndex(13);
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            thisButton.transform.parent.transform.position = new Vector3(0, 0, 0);
        }
    }

    public void ReturnInitialPosition()
    {
        move = false;
        print("Returning to Initial Position!");
        print(initialPosition);
        thisButton.transform.parent.transform.position = initialPosition;
    }
}
