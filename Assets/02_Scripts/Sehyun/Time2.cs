using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time2 : MonoBehaviour
{
    
    public Text[] text_time; // �ð��� ǥ���� text
    float time; // �ð�.


   
    private void Update() // �ٲ�� �ð��� text�� �ݿ� �� �� update �����ֱ�
    {
        
        
            time += 500 *Time.deltaTime;
            text_time[0].text = ((int)time / 3600%12).ToString();
            text_time[1].text = ((int)time / 60 % 60).ToString();
           
        
        
    }
}
