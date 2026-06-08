using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public CinemachineCamera tpsCamera;  //3人称用カメラ
    public CinemachineCamera fpsCamera;  //1人称用カメラ
    public CinemachineCamera rearCamera; //後方用カメラ

    public PlayerController playerController;

    /// <summary>
    /// カメラモード
    /// </summary>
    private enum CameraMode
    {
        TPS,  //3人称
        FPS,  //1人称
        REAR  //後方
    }


    private CameraMode m_CurrentMode = CameraMode.TPS;  //最初は3人称視点に設定しておく

    private void Update()
    {
        //後方確認が最優先
        if(playerController.input.IsRearCamera)
        {
            m_CurrentMode = CameraMode.REAR;
        }

        else if(playerController.input.IsFirstCamera)
        {
            m_CurrentMode = CameraMode.FPS;
        }
        else
        {
            m_CurrentMode = CameraMode.TPS;
        }

        ApplyCamera();
    }

    /// <summary>
    /// 設定したカメラの適用
    /// </summary>
    private void ApplyCamera()
    {
        tpsCamera.Priority = 0;
        fpsCamera.Priority = 0;
        rearCamera.Priority = 0;

        switch(m_CurrentMode)
        {
            case CameraMode.TPS:
                tpsCamera.Priority = 20;
                break;
            case CameraMode.FPS:
                fpsCamera.Priority = 20;
                break;
            case CameraMode.REAR:
                rearCamera.Priority = 20;
                break;
        }

    }
}
