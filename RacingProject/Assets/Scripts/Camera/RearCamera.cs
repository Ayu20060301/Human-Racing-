using Unity.Cinemachine;
using UnityEngine;

/// <summary>
/// 後方確認用のカメラ
/// </summary>
public class RearCamera : MonoBehaviour
{
    public CinemachineCamera tpsCamera;
    public CinemachineCamera rearCamera;

    public PlayerController playerController;

    private void Update()
    {
        if (playerController.input.IsRearCamera)
        {
            tpsCamera.Priority = 10;
            rearCamera.Priority = 20;
        }
        else
        {
            tpsCamera.Priority = 20;
            rearCamera.Priority = 10;
        }
    }
}
