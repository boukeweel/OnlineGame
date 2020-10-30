using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.forward = Camera.main.transform.forward;
        transform.localScale = new Vector3(transform.parent.localScale.x, 1, 1);
    }

    
}
