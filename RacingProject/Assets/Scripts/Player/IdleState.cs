using UnityEngine;

/// <summary>
/// 待機状態
/// </summary>
public class IdleState : PlayerState
{

    public IdleState(PlayerController player) : base(player) { }

    public override void Enter()
    {
        //走行アニメーションオフ
        player.animator.SetBool("IsRun", false);

        //ブレーキアニメーションオフ
        player.animator.SetBool("IsBrake", false);
    }

    public override void Update()
    {
        //動き始めたら移動状態へ
        if(player.input.Accel > 0.1f)
        {
            player.ChangeState(new DriveState(player));
            return;
        }
    }

    public override void Exit()
    {
        
    }
}
