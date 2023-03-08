using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //목표 지점
    public Transform target;
    //시작 지점, 즉 자기자신의 위치
    private Vector3 startPoint;
    //날아가는 속도
    public float flyspeed = 10;
    //날아가는 높이설정
    public float flyheight = 1f;
    //눌린값을 true 시켜줌
    public bool forward;

    
    // Start is called before the first frame update
    void Start()
    {
        //Vector3에 자기 자신의 위치를 입힘
        //target.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2f);

        startPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       // target.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            forward = true;
        }

        if (forward)
        {
            //지역변수 선언
            float x0 = startPoint.x;
            float x1 = target.position.x;
            float y1 = target.position.y;
            //날아가는 방향을 설정
            float distance = x1 - x0;

            //transform 위에서  x1해당위치로 날아가게함
            float nextX = Mathf.MoveTowards(transform.position.x, x1, flyspeed * Time.deltaTime);
            
            //y축으로 부드럽게 날아가겜해줌
            float baseY = Mathf.Lerp(startPoint.y, y1, (nextX - x0) / distance);

            float arc = flyheight * (nextX - x0) + (nextX - x1) / (-0.25f * distance * distance);

            Vector3 nextPosition = new Vector3(nextX, baseY + arc, transform.position.z);

            
            //transform.rotation = LookRotation(nextPosition - transform.position);
            transform.position = nextPosition;

            if(nextPosition == target.position)
            {
                Debug.Log("도착했습니다");
            }
        }
    }

      
}
