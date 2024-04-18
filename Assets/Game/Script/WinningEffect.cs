using Scriptable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningEffect : MonoBehaviour
{
    [SerializeField] private List<Renderer> charactersEffect;
    [SerializeField] private ColorData colorData;
    public void SetColorToChar(ColorType char1, ColorType char2, ColorType char3)
    {
        charactersEffect[0].material = colorData.GetMaterial(char1);
        charactersEffect[1].material = colorData.GetMaterial(char2);
        charactersEffect[2].material = colorData.GetMaterial(char3);
    }
}
