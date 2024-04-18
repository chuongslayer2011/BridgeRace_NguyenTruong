using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scriptable
{
    public class Brick : GameUnit 
    {
        [SerializeField] ColorData colorData;
        [SerializeField] Renderer _renderer;
        private ColorType colorType;
        
        // Start is called before the first frame update
        /*private void OnEnable()
        {
            ColorType randomColor = MapController.instance.RandomColorType();
            this.SetColor(randomColor);
            this.SetColorType(randomColor);
        }*/

 
        public void SetColor(ColorType colorType)
        {
            _renderer.material = colorData.GetMaterial(colorType);
        }
        public int GetColorType()
        {
            return (int)colorType;
        } 
        public void SetColorType(ColorType colorType)
        {
            this.colorType = colorType;
        }
        public void OnDespawn()
        {
            SimplePool.Despawn(this);
        }
    }
}
