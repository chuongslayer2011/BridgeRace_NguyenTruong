using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scriptable
{
    public enum ColorType
    {
        None = 0,
        Red = 1,
        Green = 2,
        Blue = 3,
        Yellow = 4,
    }
    [CreateAssetMenu(menuName = "ColorData")]
    public class ColorData : ScriptableObject
    {

        [SerializeField] Material[] materials;
        public Material GetMaterial(ColorType colorType)
        {
            return materials[(int)colorType];
        }
    }

}
