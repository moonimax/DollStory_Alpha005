using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameraobject : MonoBehaviour
{
    public Transform playertransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playertransform.position.x, 0f, playertransform.position.z);
    }
}
