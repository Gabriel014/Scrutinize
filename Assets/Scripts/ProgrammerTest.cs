using UnityEngine;
using System.Collections;

public class ProgrammerTest : MonoBehaviour
{

    // Use this for initialization

    [ContextMenu("Clear PlayerPrefs")]
    public void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
		
}