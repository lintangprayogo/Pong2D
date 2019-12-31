using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    // Start is called before the first frame update'
    public float speed;
    public string axis;
    public float topBorder;
    public float bottomBorder;

    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        float gerak = Input.GetAxis(axis) * speed * Time.deltaTime;
        float nextPos = transform.position.y + gerak;
        if (nextPos > topBorder)
        {
            gerak = 0;
        }
        if (nextPos < bottomBorder)
        {
            gerak = 0;
        }

        transform.Translate(0, gerak, 0);
    }
}
