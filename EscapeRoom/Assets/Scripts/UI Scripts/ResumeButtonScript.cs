using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButtonScript : MonoBehaviour
{
    public GameObject EscapeMenu; 

    public void ResumeGame()
    {
        EscapeMenu.SetActive(false);
    }
}
