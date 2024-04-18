using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState<Enemy>
{
    public void OnEnter(Enemy t)
    {
        t.ChangeAnim("Idle");
    }

    public void OnExecute(Enemy t)
    {
        if (MapController.instance.checkBrickOnStage(t.getCurrentStage()))
        {
            t.ChangeState(new CollectState());
        }
    }

    public void OnExit(Enemy t)
    {

    }

}
