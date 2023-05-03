using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Im : MonoBehaviour
{
    Look_Player L_P;
    [SerializeField]
    private Image im;
    
   
    public bool interaction = false;
    // Start is called before the first frame update
    private void Awake()
    {

        //L_P = GetComponent<Look_Player>();
        L_P = FindObjectOfType<Look_Player>().GetComponent<Look_Player>();
        im = gameObject.GetComponent<Image>();
    }

    void Start()
    {
        //im.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (interaction == true)
        {
            im.enabled = true;
          

        }
        else
        {

            im.enabled = false;
          
        }

    }
}
