using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseMenu : MonoBehaviour
{
    // Reference to the content of the scrollable window
    // All of the door panels will be put in there.
    public Transform Content;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToggleMenu()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}

