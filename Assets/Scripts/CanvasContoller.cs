using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasContoller : MonoBehaviour
{  
    public GameObject endCancas;
    public PlayerMovement playerMovement;
    public GameObject startCanvas;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement.enabled = false;
        Time.timeScale = 0f;
    }
    // Update is called once per frame
    public void StartButton()
    {
        Time.timeScale = 1f;
        startCanvas.gameObject.SetActive(false);
        playerMovement.enabled = true;
    }

    public void NextButton()
    {
        SceneManager.LoadScene(0);
    }
}
