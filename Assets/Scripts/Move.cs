using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.Translate(Vector2.up * Time.deltaTime * 8f);
        }else if(Input.GetKey(KeyCode.A))
        {
            player.Translate(Vector2.left * Time.deltaTime * 8f);
        }else if (Input.GetKey(KeyCode.S))
        {
            player.Translate(Vector2.down * Time.deltaTime * 8f);
        }else if (Input.GetKey(KeyCode.D))
        {
            player.Translate(Vector2.right * Time.deltaTime * 8f
                );
        }
    }
}
