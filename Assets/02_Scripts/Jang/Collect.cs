using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    [SerializeField] private Collection coll;
    [SerializeField] private float radius;

    void Update()
    {
        if (Physics.OverlapSphere(transform.position, radius, LayerMask.GetMask("Player")).Length > 0)
        {
            CollectManager.instance.OnColl(coll);
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
