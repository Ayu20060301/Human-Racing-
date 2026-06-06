using UnityEngine;

/// <summary>
/// ブレーキの状態
/// </summary>
public class BrakeState : PlayerState
{
    public BrakeState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        player.animator.SetBool("IsBrake", true);
    }

    public override void Update()
    {

        player.UpdateMovement();

        //アクセル状態へ遷移
        if (player.input.Accel > 0)
        {
            player.ChangeState(new DriveState(player));
        }

        //速度が0の場合は停止状態にする
        if(player.Speed <= 0.1f)
        {
           
            player.ChangeState(new IdleState(player));
            return;
        }

    }

    public override void Exit()
    {
        
    }
}
