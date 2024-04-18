using Scriptable;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Character : MonoBehaviour, IComparable<Character> 
{
    
    [SerializeField] public Animator animator;
    [SerializeField] protected ColorData colorData;
    [SerializeField] protected Renderer meshRenderer;
    [SerializeField] protected ColorType colorType;
    [SerializeField] protected Transform brickList;
    [SerializeField] protected Rigidbody rb;
    public int currentStage = 0;
    protected List<Brick> bricks = new List<Brick>();
    private Vector3 offset = new Vector3(0, 0.35f, 0);  
    //private GameObject topBrick;
    private string currentAnimName;
    bool isUp;
    public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            animator.ResetTrigger(animName);
            currentAnimName = animName;
            animator.SetTrigger(currentAnimName);
        }
    }
    protected void SetColor(ColorType colorType)
    {
        meshRenderer.material = colorData.GetMaterial(colorType);
    }
    public virtual void OnInit()
    {
        this.SetColor(colorType);
        this.currentStage = 0;
        this.ClearAllBrick();
        MapController.instance.AddColorToStage(currentStage, colorType);
        this.transform.position = MapController.instance.GetSpawnPoint().position;
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        
       
    }
    protected virtual void OnTriggerEnter(Collider collision)
    {
        int colorIndex = 0;
        if (collision.CompareTag("Brick") )
        {
           
           colorIndex = collision.GetComponent<Brick>().GetColorType();
           if (colorIndex == (int) colorType)
            {

                MapController.instance.RemoveBridgeOnStage(currentStage, collision.GetComponent<Brick>(), collision.gameObject.transform.position);
                AddBrick(collision.gameObject);
                
            }
        }
        
        if (collision.CompareTag("Stairs"))
        {
            
            
            colorIndex = collision.gameObject.GetComponent<Stairs>().GetColor();
            if ((bricks.Count != 0) )
            {
                if ((int)this.colorType != colorIndex)
                {
                    
                    collision.gameObject.GetComponent<Stairs>().Buildling(this.colorType);

                    RemoveBrick();
                }
            }
            
        }
        
    }

    protected void AddBrick(GameObject brick)
    {
        brick.transform.position = brickList.position;
        brick.transform.rotation = brickList.rotation;
        brickList.position += offset;
        brick.transform.SetParent(transform, true);
        brick.GetComponent<Brick>().SetColor(colorType);
        bricks.Add(brick.GetComponent<Brick>());
    }

    protected void RemoveBrick()
    {   
        brickList.position -=offset;
        Brick topBrick = bricks[bricks.Count -1];
        SimplePool.Despawn(topBrick);
        bricks.RemoveAt(bricks.Count - 1);
    }
    public void ClearAllBrick()
    {
       
        for(int i = 0; i < bricks.Count; i++)
        {
            SimplePool.Despawn(bricks[i]);
            brickList.position -= offset;
        }
        bricks.Clear();
    }

    public ColorType GetColorType()
    {
        return this.colorType;
    }
    public void SetCurrentStage(int stage)
    {
        this.currentStage = stage;
    }
    public int GetCurrentStage()
    {
        return this.currentStage;
    }
    public int CompareTo(Character other)
    {
        if (other == null)
            return 1;
        return this.bricks.Count.CompareTo(other.bricks.Count);
    }
}
