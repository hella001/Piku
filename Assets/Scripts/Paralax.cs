using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{

    public Transform mainCam;
    public Transform middleBG;
    public Transform sideBG;

    public float length = 28.4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCam.position.x > middleBG.position.x)
            sideBG.position = middleBG.position + Vector3.right *length;

        if (mainCam.position.x < sideBG.position.x)
            sideBG.position = middleBG.position + Vector3.left * length;
    }
}
