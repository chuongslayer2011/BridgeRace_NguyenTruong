using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : Character
{
    private bool haveBrick;
    public NavMeshAgent agent;
    private IState<Enemy> currentState;
    private Transform bridge;
    private bool isCollecting;
    public override void OnInit()
    {   
        ChangeState(new IdleState());
        agent.enabled = false;
        base.OnInit();
    }
    private void FixedUpdate()
    {
        if(currentState != null)
        {
            currentState.OnExecute(this);
        }
        
    }

    public void SetDestination(Vector3 position)
    {
        agent.enabled = true;
        agent.SetDestination(position);
    }

    public void CollectBrick()
    {
        Vector3 target = MapController.instance.GetBrickOnStage(currentStage, this.colorType);
        if (target != Vector3.zero)
        {   
            isCollecting = true;
            ChangeAnim(CONST.RUN_ANIM);
            SetDestination(target);
        }
        else
        {   
            isCollecting=false;
        }
    }
    public void Building()
    {
        if (bridge != null)
        {
            SetDestination(bridge.position);
        }
    }
    public void ChangeState(IState<Enemy> state)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = state;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
    public int GetCurrentQuanlityBrick()
    {
        return bricks.Count;
    }
    public int getCurrentStage()
    {
        return currentStage;
    }
    public bool CheckCollect()
    {
        return isCollecting;
    }
    public void SetCollect(bool isCollecting)
    {
        this.isCollecting = isCollecting;
    }
    public void SetTargetPoint()
    {
        this.bridge = MapController.instance.GetTargetPointCurrentStage(currentStage);
    }
}