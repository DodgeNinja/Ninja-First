using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    [SerializeField] private AudioSource enemySound;
    [SerializeField] private float sountRadius;
    [SerializeField] private LayerMask playerMask;

    public bool check;

    void Update()
    {
        SoundRange();
    }

    private void SoundRange()
    {
        RaycastHit hit;
        Vector2 center = transform.position;
        var soundRange = Physics.OverlapSphere(transform.position, sountRadius,
             playerMask);
        
        if (soundRange.Length != 0 && !check)
        {
            enemySound.Play();
            check = true;
        }
        else if (soundRange.Length == 0) check = false;
    }
}
