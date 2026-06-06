using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
   public float Steer { get; private set; }
   public float Accel { get; private set; } //アクセル
   public float Brake { get; private set; } //ブレーキ

   public bool UseItem { get; private set; } //アイテム使う

    
   private Gamepad m_Pad;

   private void Update()
   {
        if (m_Pad == null)
        {
            m_Pad = Gamepad.current;
        }

        if (m_Pad == null) return;

        Steer = PadInput.Steer(m_Pad);
        Accel = PadInput.AHeld(m_Pad) ? 1.0f : 0.0f; //Aボタン
        Brake = PadInput.BHeld(m_Pad) ? 1.0f : 0.0f; //Bボタン

        //UseItem = m_Pad.rightTrigger.wasPressedThisFrame; //R2ボタン

       
   }
}
