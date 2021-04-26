using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 offset;
    private Transform target;
    private Vector2 velocity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null && GameObject.FindGameObjectsWithTag("Player")!=null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            offset = target.position- transform.position;
        }
        //offset = new Vector3(transform.position.x - target.position.x, transform.position.y - target.position.x, 0);


    }
    private void FixedUpdate()
    {
        if (target != null)
        {
            //SmoothDamp函数可以实现平滑跟随，你这样写是直接赋值位置，实时更新位置。
            float X = Mathf.SmoothDamp(transform.position.x, 
                target.position.x - offset.x, ref velocity.x, 0.05f);
            float Y = Mathf.SmoothDamp(transform.position.y, 
                target.position.y - offset.y, ref velocity.y, 0.05f);
            if (Y > transform.position.y)
                transform.position = new Vector3(X, Y, transform.position.z);

        }
    }
}
