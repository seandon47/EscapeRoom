using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    public GameObject NoiseMaker;
    public GameObject Flare;
    public GameObject FlashBomb;
    public GameObject PipeBomb;

    internal GameObject Create(string resultName)
    {
        switch (resultName)
        {
            case "NoiseMaker":
                return NoiseMaker;
            case "Flare":
                return Flare;
            case "FlashBomb":
                return FlashBomb;
            case "PipeBomb":
                return PipeBomb;
            default:
                return null;
        }
    }
}