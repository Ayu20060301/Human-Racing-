using UnityEngine;

/// <summary>
/// 走行状態
/// </summary>
public class DriveState : PlayerState
{
    public DriveState(PlayerController player) : base(player) { }


    public override void Enter()
    {
        player.animator.SetBool("IsRun", true);
    }


    public override void Update()
    {
        player.UpdateMovement();

        //ブレーキ状態へ遷移
        if(player.input.Brake > 0)
        {
            player.ChangeState(new BrakeState(player));
            return;
        }

        //速度が0になったら停止状態にする
        if(player.Speed <= 0.1f)
        {
            player.ChangeState(new IdleState(player));
        }
    }

    public override void Exit()
    {
        
    }

}
