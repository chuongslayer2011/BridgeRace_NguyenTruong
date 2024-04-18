using Scriptable;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    [SerializeField] private Renderer stairRenderer;
    [SerializeField] private Collider stairCollider;
    [SerializeField] private ColorData colorData;
    private ColorType colorType;






    public void Buildling(ColorType colorType)
    {
        stairRenderer.enabled = true;
        stairRenderer.material = colorData.GetMaterial(colorType);
        this.colorType = colorType;
    }
    public int GetColor()
    {   
        if (colorData == null)
        {
            return (int) ColorType.None;
        }
        return (int) this.colorType;
    }
}
