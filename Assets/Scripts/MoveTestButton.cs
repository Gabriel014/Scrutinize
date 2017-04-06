using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTestButton : MonoBehaviour
{

    bool move = false;
    [HideInInspector]
    public Transform initialPosition;

    // Use this for initialization

    void Start()
    {
        initialPosition = gameObject.transform.parent.GetComponent<Transform>();
    }

    public void Clicked()
    {
        gameObject.transform.parent.transform.SetSiblingIndex(13);
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            gameObject.transform.parent.transform.position = new Vector3(0, 0, 0);
        }
    }

    public void ReturnInitialPosition()
    {
        gameObject.transform.parent.transform.position = initialPosition.position;
    }
}
