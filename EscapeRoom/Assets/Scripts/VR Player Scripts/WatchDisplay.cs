using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WatchDisplay : MonoBehaviour
{
    public TextMeshPro DisplayText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateDisplayText(string text)
    {
        DisplayText.text = text;
    }
}
