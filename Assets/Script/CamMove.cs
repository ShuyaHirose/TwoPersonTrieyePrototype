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
        // UpÉLÅ[Ç≈ç¿ïW0, 0, 1Ç…èuä‘à⁄ìÆÇ∑ÇÈ
        if (Input.GetKey("up"))
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
