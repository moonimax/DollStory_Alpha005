using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingPlay : MonoBehaviour
{
    GameObject Player1;

    //��ǥ������ �� �������� // SearchPoint�� ������Ʈ �Ҿ��
    GameObject searchPoint;

    Vector3 target_pos;
    Vector3 target_posL;
    Vector3 target_posR;
    Vector3 target_posF;
    Vector3 target_posBF;

    // Start is called before the first frame update
    void Start()
    {
        searchPoint = GameObject.FindGameObjectWithTag("SearchPoint");
        Player1 = GameObject.FindGameObjectWithTag("Player");
        //findspot = FindObjectOfType<PlayerMove>().transform.position;
    }


    public void leftMove()
    {
        searchPoint.GetComponent<SearchPoint>().leftMove();
        //Player1.GetComponent<BoxJump>().ActualMove();
    }
    public void rightMove()
    {
        searchPoint.GetComponent<SearchPoint>().rightMove();
        //Player1.GetComponent<BoxJump>().ActualMove();
    }

    public void forwardMove()
    {
        searchPoint.GetComponent<SearchPoint>().forwardMove();
        //Player1.GetComponent<BoxJump>().ActualMove();
    }

    public void backMove()
    {
        searchPoint.GetComponent<SearchPoint>().backMove();
        //Player1.GetComponent<BoxJump>().ActualMove();
    }

    
}
