using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform Player;
    public bool isFinish = false;
    public GameObject cameraRotator;
    public float cameraFollowOffset = 10f;


    public float rotateSpeed = 1;
    
    // Update is called once per frame
    void Update()
    {
        if (!isFinish) 
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, Player.position.z - cameraFollowOffset);
        }
        
        if (isFinish)
        {
            RotateCam();
        }
    }

    void RotateCam()
    {
        cameraRotator.transform.position = Player.position;

        transform.parent = cameraRotator.transform;
        cameraRotator.transform.parent = Player;
        cameraRotator.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
