using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPoint : MonoBehaviour
{
    [SerializeField] private int currentStage;  
    
    private void OnTriggerEnter(Collider other)
    {   
        if(other.CompareTag("Player") || other.CompareTag("Enemy"))
        {   
            
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().ChangeState(new CollectState());
                other.GetComponent<Enemy>().SetTargetPoint();
            }
            if (MapController.instance.GetStage(currentStage).CheckIsReach() == false)
            {
                if (currentStage != 0)
                {
                    MapController.instance.AddColorToStage(currentStage, other.GetComponent<Character>().GetColorType());
                    MapController.instance.RemoveColorFromStage(other.GetComponent<Character>().GetCurrentStage(), other.GetComponent<Character>().GetColorType());
                }
                MapController.instance.GetStage(currentStage).SetIsReach(true);
                MapController.instance.SpawnBrick(currentStage);
            }
            else
            {
                if (currentStage != 0)
                {
                    MapController.instance.AddColorToStage(currentStage, other.GetComponent<Character>().GetColorType());
                    MapController.instance.RemoveColorFromStage(other.GetComponent<Character>().GetCurrentStage(), other.GetComponent<Character>().GetColorType());
                    MapController.instance.RespawnBrick(currentStage);
                }
                
            }
            other.GetComponent<Character>().SetCurrentStage(this.currentStage);
        }

    }
   
}
