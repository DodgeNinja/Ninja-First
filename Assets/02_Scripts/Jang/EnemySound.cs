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
        var soundRange = Physics.OverlapBox(transform.position, new Vector3(sountRadius, 2.5f,
            sountRadius), Quaternion.identity, playerMask);

        //var soundRange = Physics.OverlapSphere(transform.position, sountRadius,
        //     playerMask);

        if (soundRange.Length > 0 && !check)
        {
            Debug.Log(soundRange[0].name);
            enemySound.Play();
            check = true;
        }
        else if (soundRange.Length == 0)
        {
            check = false;
        }
    }
}
