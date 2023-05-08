using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource sound;
    [SerializeField] private AudioClip normalSound;
    [SerializeField] private AudioClip enemySound;
    [SerializeField] private float sountRadius;
    [SerializeField] private LayerMask enemyMask;

    public bool check;

    void Update()
    {
        SoundRange();
    }

    private void SoundRange()
    {
        var soundRange = Physics.OverlapBox(transform.position, new Vector3(sountRadius, 2.5f,
            sountRadius), Quaternion.identity, enemyMask);

        //var soundRange = Physics.OverlapSphere(transform.position, sountRadius,
        //enemyMask);

        if (soundRange.Length != 0 && !check)
        {
            sound.clip = enemySound;
            sound.Play();
            check = true;
        }
        else if (soundRange.Length == 0 && check)
        {
            sound.clip = normalSound;
            sound.Play();
            check = false;
        }
    }
}
