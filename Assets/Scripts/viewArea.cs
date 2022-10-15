using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewArea : MonoBehaviour
{
    public Camera myCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            myCam.orthographicSize = 5.0f;

        }else if (Input.GetKey(KeyCode.K))
        {
            myCam.orthographicSize = 10.0f;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            myCam.orthographicSize = 40.0f;
        }
        else if (Input.GetKey(KeyCode.H))
        {
            myCam.orthographicSize = 3.0f;
        }

    }
}
