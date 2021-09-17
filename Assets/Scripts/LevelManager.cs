using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private AnimationController animationController;
      
    [SerializeField]
    private GameObject player;

    public GameObject endCanvas;
    public GameObject loseCanvas;



    // Update is called once per frame
    void Update()
    {
        
    }
    public void FinishGame()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        animationController.FinishDance();
        endCanvas.gameObject.SetActive(true);
    }
    public void EndGame()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Rigidbody>().isKinematic = true;
        animationController.SetLose();
        loseCanvas.gameObject.SetActive(true);
    }
    


}
