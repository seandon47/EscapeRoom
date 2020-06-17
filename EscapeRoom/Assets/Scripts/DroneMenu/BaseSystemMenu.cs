using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BaseSystemMenu : MonoBehaviour
{
    // Reference to the content of the scrollable window
    // All of the door panels will be put in there.
    public Transform Content;

    static List<BaseSystemMenu> SystemMenuList = new List<BaseSystemMenu>();
    
    // Use this for initialization
    protected virtual void Start()
    {
        SystemMenuList.Add(this);
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
            // So they don't stack and look weird
            CloseAllSystemMenus();
            gameObject.SetActive(true);
        }
    }

    public virtual void AddSubsystemToMenu(SubSystemClass SSC)
    {
        // Overide in derived class
    }

    protected void CloseAllSystemMenus()
    {
        foreach(BaseSystemMenu BSM in SystemMenuList)
        {
            BSM.gameObject.SetActive(false);
        }
    }
}

