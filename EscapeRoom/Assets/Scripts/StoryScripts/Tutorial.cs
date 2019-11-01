using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public enum Chapters
    {
        Chapter1,
        Chapter2,
        Chapter3,
        Chapter4,
        Chapter5,
        Chapter6
    }

    Chapters CurrentChapter;
    int TransitionTime;
    public GameObject alien;

	// Use this for initialization
	void Start () {
        CurrentChapter = Chapters.Chapter1;
        TransitionTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TimeUpdate()
    {
        switch (CurrentChapter)
        {
            case Chapters.Chapter1:
                ChapterOne();
                break;
            case Chapters.Chapter2:
                ChapterTwo();
                break;
            case Chapters.Chapter3:
                break;
            case Chapters.Chapter4:
                break;
            case Chapters.Chapter5:
                break;
            case Chapters.Chapter6:
                break;
            default:
                break;
        }
    }

    private void ChapterOne()
    {
        ShipSystemClass.SystemStatusEnum PowerStatus = GameController.Instance.PowerSystem.GetStatus();
        if (PowerStatus == ShipSystemClass.SystemStatusEnum.Functioning)
        {
            CurrentChapter = Chapters.Chapter2;
            TransitionTime = GameController.Instance.Time;            
            CircuitClass CC = GameController.Instance.LightingSystem.LightingCircuits;
            foreach (LightList LL in CC.AllMyCircuits)
            {
                foreach (LightClass LC in LL.Lights)
                {
                    LC.SetLightColor(Color.white);
                }
            }
        }
    }

    private void ChapterTwo()
    {
        int TimeDifference = GameController.Instance.Time - TransitionTime;
        if (TimeDifference < 10)
        {
            return;
        }
        else if (TimeDifference == 10)
        {
            CircuitClass AllTheCircuits = GameController.Instance.LightingSystem.LightingCircuits;
            foreach (LightList LL in AllTheCircuits.AllMyCircuits)
            {
                LL.TripBreaker();
                alien.SetActive(true);
                AudioSource audio = GetComponent<AudioSource>();

                audio.Play();
            }
            //GameController.Instance.LightingSystem.SetStatus(ShipSystemClass.SystemStatusEnum.Malfunctioning);            
        }
    }
}

