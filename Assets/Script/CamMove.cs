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
        // Up�L�[�ō��W0, 0, 1�ɏu�Ԉړ�����
        if (Input.GetKey("up"))
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
