using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    [Header("Reference")]
    public PlayerMovement playerMove;
    public GameObject canvas;
    public bool gameOver = false;

    private void Awake()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            End();
    }

    public void End()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        canvas.SetActive(false);
        playerMove.enabled = false;
        
        
        gameOver = true;
    }
}
