using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private CameraController cameraController;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void SetJump()
    {
        animator.SetTrigger("Jump");
    } 
    public void FinishDance()
    {
        animator.SetTrigger("Finish");
        cameraController.isFinish = true;
    }

    public void SetLose()
    {
        animator.SetTrigger("Lose");
        cameraController.isFinish = true;
    }

}
