using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxJump : MonoBehaviour
{
     protected float Animation;

    public float speed = 5f;

    GameObject searchPoint;
    // Start is called before the first frame update
    void Start()
    {
        searchPoint = GameObject.FindGameObjectWithTag("SearchPoint");
    }

    // Update is called once per frame
    void Update()
    {
        //애니메이션 날아가는 시간을 제어해줌
        Animation = Animation % 5f;
        Animation += Time.deltaTime;
        /*
        //애니메이션 날아가는 시간을 제어해줌
        Animation = Animation % 5f;

       transform.position = MathParabola.Parabola(Vector3.zero, Vector3.forward * 10, 5f, Animation / 5f);
        */

        //좌클릭 누를시 기존의 루트를 따라가는 로직
        /* if (Input.GetMouseButton(0))
         {
           GetComponent<ParabolaController>().FollowParabola();
         }
          */
    }

    public void ActualMove()
    {
        transform.position = MathParabola.Parabola(transform.position, searchPoint.GetComponent<SearchPoint>().findSpot * speed, 5f, Animation / 5f);
    }
}
