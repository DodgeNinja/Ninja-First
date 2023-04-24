using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLook : MonoBehaviour
{
    GameObject player;

    private void Awake() => player = GameObject.FindWithTag("Player");

    void Update() => LookAtPlayer();

    private void LookAtPlayer()
    {
        Vector3 v = player.transform.position - transform.position;
        v.y = 0;

        transform.rotation = Quaternion.LookRotation(-v.normalized);
    }
}
