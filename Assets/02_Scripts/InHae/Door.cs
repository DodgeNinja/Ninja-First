using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] int speed;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Reder();
    }

    void Reder()
    {
        Vector3 vec = player.transform.position - transform.position;
        if (Mathf.Acos(Vector3.Dot(vec.normalized, transform.forward)) * Mathf.Rad2Deg > 90)
        {
            FrontRader();
        }
        else
        {
            BackRader();
        }
    }

    void FrontRader()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, radius, LayerMask.GetMask("Player"));
        if(col.Length > 0)
        {
            if (transform.localScale.x > 0)
                if (Mathf.Rad2Deg * transform.rotation.y <= 40)
                    transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime * speed);

            if (transform.localScale.x < 0)
                if (Mathf.Rad2Deg * transform.rotation.y >= -40)       
                    transform.Rotate(new Vector3(0, -90, 0) * Time.deltaTime * speed);
        }

        else
        {
            if (transform.localScale.x > 0)
                if (Mathf.Rad2Deg * transform.rotation.y > 0)
                    transform.Rotate(new Vector3(0, -90 , 0) * Time.deltaTime * speed);

            if (transform.localScale.x < 0)
                if (Mathf.Rad2Deg * transform.rotation.y < 0)
                    transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime * speed);

        }
    }

    void BackRader()
    {
        Collider[] col = Physics.OverlapSphere(transform.position, radius, LayerMask.GetMask("Player"));
        if (col.Length > 0)
        {
            if (transform.localScale.x > 0)
                if (Mathf.Rad2Deg * transform.rotation.y >= -40)
                    transform.Rotate(new Vector3(0, -90, 0) * Time.deltaTime * speed);

            if (transform.localScale.x < 0)
                if (Mathf.Rad2Deg * transform.rotation.y <= 40)
                    transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime * speed);
        }

        else
        {
            if (transform.localScale.x > 0)
                if (Mathf.Rad2Deg * transform.rotation.y < 0)
                    transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime * speed);

            if (transform.localScale.x < 0)
                if (Mathf.Rad2Deg * transform.rotation.y > 0)
                    transform.Rotate(new Vector3(0, -90, 0) * Time.deltaTime * speed);

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawSphere(transform.position, radius);
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
