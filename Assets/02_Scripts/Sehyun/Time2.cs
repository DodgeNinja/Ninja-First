using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time2 : MonoBehaviour
{
    
    public Text[] text_time; // 시간을 표시할 text
    float time; // 시간.


   
    private void Update() // 바뀌는 시간을 text에 반영 해 줄 update 생명주기
    {
        
        
            time += 500 *Time.deltaTime;
            text_time[0].text = ((int)time / 3600%12).ToString();
            text_time[1].text = ((int)time / 60 % 60).ToString();
           
        
        
    }
}
