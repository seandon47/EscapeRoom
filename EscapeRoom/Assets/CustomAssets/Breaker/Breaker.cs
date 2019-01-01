using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breaker : MonoBehaviour {
    public BreakerButtonPress TopButton;
    public BreakerButtonPress BottomButton;
    Animator anim;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        if(TopButton != null)
        {
            TopButton.Pressed += TopButton_Pressed;
        }

        if (BottomButton != null)
        {
            BottomButton.Pressed += BottomButton_Pressed;
        }
    }

    private void TopButton_Pressed()
    {
        StartCoroutine(DoRedButtonPress());
    }

    private void BottomButton_Pressed()
    {
        StartCoroutine(DoGreenButtonPress());
    }

    // Update is called once per frame
    void Update () {
	
	}

    IEnumerator DoRedButtonPress()
    {
        anim.Play("TopButtonPress");
        yield return new WaitForSeconds(1.0f);
    }

    IEnumerator DoGreenButtonPress()
    {
        anim.Play("BottomButtonPress");
        yield return new WaitForSeconds(1.0f);
    }
}
