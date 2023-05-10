using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CamState : MonoBehaviour
{
    PlayerMovement playerMovement;

    float shake = -180;
    const float shakeAomunt = 0.025f;

    private void Awake()
        => playerMovement = FindObjectOfType<PlayerMovement>();

    void Update()
    {
        if (playerMovement.moveDirection.x != 0 || playerMovement.moveDirection.z != 0)
        {
            shake += shakeAomunt;
            transform.position += new Vector3(0, Mathf.Sin(shake) / 1000f, 0);
        }
    }
}
