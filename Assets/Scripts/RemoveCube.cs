using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCube : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            int childCount = transform.childCount;
            if (childCount > 1)
            {
                GameObject child = transform.GetChild(childCount - 1).gameObject;
                transform.GetChild(childCount - 1).parent = null;                
                StartCoroutine(CoroutineRemove(2, child));

                if (transform.childCount == 1)
                {
                    levelManager.EndGame();
                }
            }
            
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            int childCount = transform.childCount;
            if (childCount > 1)
            {
                GameObject child = transform.GetChild(childCount - 1).gameObject;
                transform.GetChild(childCount - 1).parent = null;
                StartCoroutine(CoroutineRemove(2, child));
            }
            else if (transform.childCount == 1)
            {
                levelManager.EndGame();
            }
        }
    }*/

    IEnumerator CoroutineRemove(float sec, GameObject gameObject)
    {
        yield return new WaitForSeconds(sec);
        Destroy(gameObject);
        Destroy(gameObject.transform.parent);
    }
   
}
