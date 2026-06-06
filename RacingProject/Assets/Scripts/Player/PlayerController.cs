using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerInputHandler input; //プレイヤー入力用ハンドル
    public Animator animator;
    
    private PlayerState m_currentState;

    private Rigidbody m_Rigidbody;

    private float m_Speed = 0.0f; //速度
    private float m_MaxSpeed = 25.0f; //最大速度
    private float m_AccelPower = 8.0f; //加速
    private float m_BreakPower = 40.0f; //減速
    private float m_Friction = 6.0f; //摩擦力
    private float m_TurnSpeed = 120.0f; //ターンの速度


    //外部での呼び出し
    public float Speed => m_Speed;
    public float MaxSpeed => m_MaxSpeed;
    
    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        ChangeState(new IdleState(this)); //最初は待機状態
    }

    /// <summary>
    /// 状態の更新
    /// </summary>
    private void Update()
    {
        m_currentState?.Update();
    }

    /// <summary>
    /// 状態の変更
    /// </summary>
    /// <param name="newState">前の状態から新しい状態に変更</param>
    public void ChangeState(PlayerState newState)
    {
        m_currentState?.Exit();
        m_currentState = newState;
        m_currentState.Enter();
    }

   //-----------------------
   //基本移動
   //-----------------------
    public void UpdateMovement()
    {
        UpdateSpeed();

        MoveWithRayCast();

        //ハンドル
        this.transform.Rotate(0, input.Steer * m_TurnSpeed * Time.deltaTime, 0);
    }


    /// <summary>
    /// 速度の更新
    /// </summary>
    private void UpdateSpeed()
    {
        //加速
        if (input.Accel > 0)
        {
            m_Speed += m_AccelPower * Time.deltaTime;
        }
        //ブレーキと摩擦
        if (input.Brake > 0)
        {
            m_Speed -= m_BreakPower * Time.deltaTime;
        }
        else
        {
            //摩擦力を反映
            m_Speed -= m_Friction * Time.deltaTime;
            m_Speed = Mathf.Max(0.0f, m_Speed);
        }

        //速度制限
        m_Speed = Mathf.Clamp(m_Speed, 0.0f, m_MaxSpeed);

    }

    /// <summary>
    /// 移動処理(RayCast込み)
    /// </summary>
    private void MoveWithRayCast()
    {
        //移動
        Vector3 move = this.transform.forward * m_Speed * Time.deltaTime;
      
        if(CanMove(move))
        {
            this.transform.position += move;
        }
        else
        {
            //減速
            m_Speed *= 0.5f;
        }
    }


    /// <summary>
    /// 移動可能
    /// </summary>
    /// <param name="move">移動量</param>
    private bool CanMove(Vector3 move)
    {
        float distance = move.magnitude;
        Vector3 origin = this.transform.position + Vector3.up * 0.5f;
        Vector3 forward = this.transform.forward;

        float width = 0.5f;

        bool center = Physics.Raycast(origin, forward, distance);
        bool right = Physics.Raycast(origin + this.transform.right * width, forward, distance);
        bool left = Physics.Raycast(origin - this.transform.right * width, forward, distance);

        return !(center || right || left);
    }


    //アイテム
    public void UseItem()
    {
        Debug.Log("アイテムを使用");
    }
    


}
