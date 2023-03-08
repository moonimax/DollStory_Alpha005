using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //��ǥ ����
    public Transform target;
    //���� ����, �� �ڱ��ڽ��� ��ġ
    private Vector3 startPoint;
    //���ư��� �ӵ�
    public float flyspeed = 10;
    //���ư��� ���̼���
    public float flyheight = 1f;
    //�������� true ������
    public bool forward;

    
    // Start is called before the first frame update
    void Start()
    {
        //Vector3�� �ڱ� �ڽ��� ��ġ�� ����
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
            //�������� ����
            float x0 = startPoint.x;
            float x1 = target.position.x;
            float y1 = target.position.y;
            //���ư��� ������ ����
            float distance = x1 - x0;

            //transform ������  x1�ش���ġ�� ���ư�����
            float nextX = Mathf.MoveTowards(transform.position.x, x1, flyspeed * Time.deltaTime);
            
            //y������ �ε巴�� ���ư�������
            float baseY = Mathf.Lerp(startPoint.y, y1, (nextX - x0) / distance);

            float arc = flyheight * (nextX - x0) + (nextX - x1) / (-0.25f * distance * distance);

            Vector3 nextPosition = new Vector3(nextX, baseY + arc, transform.position.z);

            
            //transform.rotation = LookRotation(nextPosition - transform.position);
            transform.position = nextPosition;

            if(nextPosition == target.position)
            {
                Debug.Log("�����߽��ϴ�");
            }
        }
    }

      
}
