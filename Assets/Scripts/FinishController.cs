using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    [SerializeField]
    private LevelManager levelManager;
    private void OnTriggerEnter(Collider other)
    {
   
        if (other.CompareTag("Finish") && transform.childCount > 2)
        {
            int childCount = transform.childCount;

            GameObject child = transform.GetChild(childCount - 1).gameObject;
            transform.GetChild(childCount - 1).parent = null;

            Debug.Log(transform.childCount);
            StartCoroutine(CoroutineRemove(2, child));
        }
        else if (other.CompareTag("Finish") && transform.childCount == 2)
        {
            levelManager.FinishGame();
        }
        else if (other.CompareTag("Final"))
        {
            levelManager.FinishGame();
        }

        IEnumerator CoroutineRemove(float sec, GameObject gameObject)
        {
            yield return new WaitForSeconds(sec);
            Destroy(gameObject);
            Destroy(gameObject.transform.parent);
        }

    }
}
