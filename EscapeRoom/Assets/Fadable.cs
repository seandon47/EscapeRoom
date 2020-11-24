using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fadable : MonoBehaviour
{
    public float FadeRate;
    public bool StartFaded;
    private bool Fading;
    private bool Showing;
    private Color ColorComponent;
    private Image ImageComponent;

    // Start is called before the first frame update
    void Start()
    {
        Fading = false;
        Showing = false;
        ImageComponent = GetComponent<Image>();
        ColorComponent = ImageComponent.color;

        if (StartFaded)
        {
            ColorComponent.a = 0;
            ImageComponent.color = ColorComponent;
            SetChildrenAlpha(transform, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float newValue = 0;
        if (Fading)
        {
            newValue = ColorComponent.a - FadeRate;
            if (newValue <= 0)
            {
                newValue = 0;
                Fading = false;
            }
            ColorComponent.a = newValue;
            ImageComponent.color = ColorComponent;
            SetChildrenAlpha(transform, newValue);
        }
        else if (Showing)
        {
            newValue = ColorComponent.a + FadeRate;
            if (newValue >= 1)
            {
                newValue = 1;
                Showing = false;
            }
            ColorComponent.a = newValue;
            ImageComponent.color = ColorComponent;
            SetChildrenAlpha(transform, newValue);
        }
    }

    private void SetChildrenAlpha(Transform fadableTransform, float newValue)
    {
        foreach (Transform child in fadableTransform)
        {
            SetChildrenAlpha(child, newValue);

            Image imageComponent = child.GetComponent<Image>();
            Text textComponent = child.GetComponent<Text>();

            if (imageComponent != null)
            {
                Color componentColor = imageComponent.color;
                componentColor.a = newValue;
                imageComponent.color = componentColor;
            }                

            if (textComponent != null)
            {
                Color componentColor = textComponent.color;
                componentColor.a = newValue;
                textComponent.color = componentColor;
            }
        }
    }

    public void Fade()
    {
        Fading = true;
        Showing = false;
    }

    public void Show()
    {
        Showing = true;
        Fading = false;
    }
}