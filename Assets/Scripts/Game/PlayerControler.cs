using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerControler : MonoBehaviour
{
    private bool isLeft = false;
    private ManagerVars vars;
    private Vector3 nextPlatformLeft, nextPlatformRight;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        vars = ManagerVars.GetManagerVars();
    }

    
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameStart == false || GameManager.Instance.isGameOver == true)
        {
           
            return;
        }
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()==true)
        {
            //Debug.Log("2");
            return;
        }
            if (Input.GetMouseButtonUp(0)&& isJumping == false)
        {
            EventCenter.Broadcast(EventType.DecidePath);
            isJumping = true;
            Vector3 position = Input.mousePosition;
            if (position.x < Screen.width / 2)
            {
                isLeft = true;
            }
            else
            {
                isLeft = false;

            }
            Jump();
        }
    }
    private void Jump()
    {
        //Debug.Log("Jump");
        if (isLeft)
        {
            //Debug.Log("isLeft");
            transform.localScale = new Vector3(-1, 1, 1);
            transform.DOMoveX(nextPlatformLeft.x, 0.2f);//0.2f是进行时间
            transform.DOMoveY(nextPlatformLeft.y+0.8f, 0.15f);//0.2f是进行时间
        }
        else
        {
            //Debug.Log("isRight");
            transform.localScale = Vector3.one;
            transform.DOMoveX(nextPlatformRight.x, 0.2f);//0.2f是进行时间
            transform.DOMoveY(nextPlatformRight.y + 0.8f, 0.15f);//0.2f是进行时间
        }
        isJumping = false;
    }
    //private void OnCollisionEnter2D(Collision2D collision)
   
    //{
    //    if (collision.gameObject.tag == "Platform")
    //    {
            
    //        Vector3 currentPlatformPositon = collision.gameObject.transform.position;
    //        nextPlatformLeft =new Vector3(currentPlatformPositon.x - vars.next_x
    //            , currentPlatformPositon.y + vars.next_y, 0);
    //        nextPlatformRight = new Vector3(currentPlatformPositon.x + vars.next_x
    //            , currentPlatformPositon.y + vars.next_y, 0);
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Platform")
        {

            Vector3 currentPlatformPositon = collision.gameObject.transform.position;
            nextPlatformLeft = new Vector3(currentPlatformPositon.x - vars.next_x
                , currentPlatformPositon.y + vars.next_y, 0);
            nextPlatformRight = new Vector3(currentPlatformPositon.x + vars.next_x
                , currentPlatformPositon.y + vars.next_y, 0);
        }
    }

}
