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
        //�ִϸ��̼� ���ư��� �ð��� ��������
        Animation = Animation % 5f;
        Animation += Time.deltaTime;
        /*
        //�ִϸ��̼� ���ư��� �ð��� ��������
        Animation = Animation % 5f;

       transform.position = MathParabola.Parabola(Vector3.zero, Vector3.forward * 10, 5f, Animation / 5f);
        */

        //��Ŭ�� ������ ������ ��Ʈ�� ���󰡴� ����
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
