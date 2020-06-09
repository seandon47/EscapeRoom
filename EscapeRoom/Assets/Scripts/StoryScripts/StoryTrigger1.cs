using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTrigger1 : MonoBehaviour
{
    public AudioClip audioClip;
    AudioSource audio;
    public GameObject storyTrigger;
    private bool isTriggered = false; 

    // Start is called before the first frame update
    void Start()
    {
        audio = storyTrigger.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(!isTriggered)
        {
            if (collision.gameObject.name == "Drone Body")
            {
                audio.PlayOneShot(audioClip);
            }
            isTriggered = true;
        }
    }
}
