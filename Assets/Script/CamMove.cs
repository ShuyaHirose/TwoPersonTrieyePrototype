using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Upキーで座標0, 0, 1に瞬間移動する
        if (Input.GetKey("up"))
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
