using UnityEngine;
using System.Collections;

public class ProgrammerTest : MonoBehaviour
{

    // Use this for initialization

    [ContextMenu("Clear PlayerPrefs")]
    void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
		
}