using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectCubes : MonoBehaviour
{
    public int initialPlayerChild = 2;

    [SerializeField]
    private AnimationController animationController;



   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UnitCube"))
        {
            SetChildren(other);
           
        }
        /*else if (other.CompareTag("Cubes"))
        {
            Transform childTransform;
            int cubeNum = other.transform.childCount;
            for(int i = 0; i < cubeNum; i++)
            {
                childTransform = other.transform.GetChild(i);
                SetChildren(childTransform.GetComponent<BoxCollider>());
            }
            Destroy(other.gameObject);
        }*/
    }

    void SetChildren(Collider other)
    {
        transform.Translate(Vector3.up);
        other.transform.parent = transform;
        other.transform.localPosition = (transform.childCount - initialPlayerChild) * Vector3.down;
        animationController.SetJump();
        other.isTrigger = false;
        other.transform.GetChild(0).gameObject.GetComponent<BoxCollider>().enabled = true;
        FixChilderenPos();
    }

    void FixChilderenPos()
    {
        //transform.localPosition = (float)(transform.childCount - 1.5)*Vector3.up;
        for (int i = 1; i < transform.childCount; i++)
        {
            transform.GetChild(i).localPosition = (i - 1) * Vector3.down;
        }
    }

 

    
}
