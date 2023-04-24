using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Move : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0;
    Vector3 moveDir = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDir = direction;
    }
}
