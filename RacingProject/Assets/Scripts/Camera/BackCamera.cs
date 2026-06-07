using Unity.Cinemachine;
using UnityEngine;


public class BackCamera : MonoBehaviour
{
    public CinemachineCamera tpsCamera;
    public CinemachineCamera backCamera;

    public PlayerController playerController;

    
                                   
  
    private void Update()
    {
        if(playerController.input.IsRearCamera)
        {
            tpsCamera.Priority = 10;
            backCamera.Priority = 20;
        }
        else
        {
            tpsCamera.Priority = 20;
            backCamera.Priority = 10;
        }
    }


}
