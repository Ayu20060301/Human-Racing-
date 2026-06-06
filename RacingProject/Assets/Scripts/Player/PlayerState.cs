using UnityEngine;

//State基底クラス
public abstract class PlayerState
{
    protected PlayerController player;

    /// <summary>
    /// プレイヤーの状態管理
    /// </summary>
    /// <param name="player">プレイヤーの挙動</param>
    public PlayerState(PlayerController player)
    {
        this.player = player;
    }


    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }

}
