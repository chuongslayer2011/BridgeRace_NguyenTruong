using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingState : IState<Enemy>
{
    public void OnEnter(Enemy t)
    {
        t.SetCollect(false);
        t.SetTargetPoint();
    }

    public void OnExecute(Enemy t)
    {
        if (t.GetCurrentQuanlityBrick() == 0)
        {
            t.ChangeState(new CollectState());
        }
        t.Building();
        
    }

    public void OnExit(Enemy t)
    {

    }

}
