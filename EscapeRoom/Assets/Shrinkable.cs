using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrinkable : MonoBehaviour
{
    private bool IsShrinking;
    private bool IsGrowing;
    private Vector3 OriginalScale;

    // Start is called before the first frame update
    void Start()
    {
        OriginalScale = transform.localScale;
        IsShrinking = false;
        IsGrowing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsShrinking)
            Shrink();
        else if (IsGrowing)
            Grow();
        
    }

    public void SetShrinking(bool isShrinking)
    {
        IsShrinking = isShrinking;
    }

    public void SetGrowing(bool isGrowing)
    {
        IsGrowing = isGrowing;
    }

    private void Grow()
    {
        transform.localScale += new Vector3(0.05f, 0.05f, 0.05f) * 1;
        if (transform.localScale.x >= OriginalScale.x)
        {
            transform.localScale = OriginalScale;
            IsGrowing = false;
        }            
    }

    private void Shrink()
    {
        transform.localScale += new Vector3(0.05f, 0.05f, 0.05f) * -1;
        if (transform.localScale.x <= 0.0f)
        {
            transform.localScale = new Vector3(0, 0, 0);
            IsShrinking = false;
        }
    }
}
