using UnityEngine;

public class IdleState : State
{
    protected D_IdleState stateData;

    protected bool flipAfterIdle;
    protected bool isIdleTimeOver;
    protected bool isPlayerMinAgroRange;

    //������������ ����� � ��������� idle
    protected float idleTime;

    public IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();

        //����������� ��������
        entity.SetVelocity(0f);
        isIdleTimeOver = false;
        SetRandomIdleTime();
    }

    public override void Exit()
    {
        base.Exit();

        if (flipAfterIdle)
        {
            entity.Flip();
        }
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (Time.time >= startTime + idleTime)
        {
            isIdleTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void SefFlipAfterIdle(bool flip)
    {
        flipAfterIdle = flip; 
    }

    //��������� ��������� ������� � ��������� idle
    private void SetRandomIdleTime()
    {
        idleTime = Random.Range(stateData.minIdleTime, stateData.maxIdleTime);
    }

    public override void DoCheck()
    {
        base.DoCheck();

        isPlayerMinAgroRange = entity.CheckPlayerInMinAgroRange();
    }

}