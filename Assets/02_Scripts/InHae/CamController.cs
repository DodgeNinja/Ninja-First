using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController: MonoBehaviour
{
    public GameObject player;
    public float xmove = 0;
    public float ymove = 0;
    public float distance = 1;
    public float Camspeed = 2.5f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 X축의 움직임 입력값을 xmove 변수에 저장한다
        xmove += Input.GetAxis("Mouse X")*Camspeed;
        // 마우스 Y축의 움직임 입력값을 ymove 변수에 저장한다(-=인 이유: +=으로 하면 마우스를 위로 올리면 위를 보고 아래로 내리면 아래를 봐서 부자연스럽다.)
        ymove -= Input.GetAxis("Mouse Y")*Camspeed;

        // 마우스 x,y 축의 움직임을 오일러각을 쿼터니엄으로 변환시켜주고 그거에 따라 카메라의 방향을 조정한다
        transform.rotation = Quaternion.Euler(ymove, xmove, 0);
        // 카마레가 바라보는 방향은 z축이므로 z축 방향의 백터를 구한다
        Vector3 reverseDistance = new Vector3(0.0f, 0.0f, distance);
        // 카메라 위치 = 플레이어의 위치 - 카메라 회전각 * (0,0,거리)라는데 잘 모르겠어요..
        transform.position = player.transform.position - transform.rotation * reverseDistance;

    }
}
