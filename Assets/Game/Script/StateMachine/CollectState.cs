using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectState : IState<Enemy>
{
    float timer;
    float randomtime;
    public void OnEnter(Enemy t)
    {
        timer = 0;
        randomtime = Random.Range(8f, 12f);
        t.SetCollect(true);
    }

    public void OnExecute(Enemy t)
    {   
        timer += Time.deltaTime;
        t.CollectBrick();
        if (t.GetCurrentQuanlityBrick() > 0 && (timer > randomtime || !t.CheckCollect())) 
        {
            t.ChangeState(new BuildingState());
        }
    }

    public void OnExit(Enemy t)
    {

    }

}
