using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[SerializeField]
public class SearchPoint : MonoBehaviour
{
    [HideInInspector]
    GameObject Player_0ne;
    //public Transform searchtransform;
    [HideInInspector]
    GameObject Panel;

    //x, z ��ǥ�� ������
    [SerializeField]
    public Vector3 findSpot;

    public float something = 0.05f;
    
    [HideInInspector]
    Vector3 target_pos;

    //���ư��� �Ÿ�
    public float flyingDistance = 3f;
  

    private void Start()
    {
        Player_0ne = GameObject.FindGameObjectWithTag("Player");
        Panel = GameObject.FindGameObjectWithTag("Panel");
    }
    //�¹�ư�� ������ �·� ���� ��� ������ ��� �����ϴ� �ý���
    void Update()
    {
        
    
    }

    public void leftMove()
    {
        target_pos = Player_0ne.transform.position;
        findSpot = new Vector3(target_pos.x - flyingDistance, target_pos.y, target_pos.z);
        transform.position = findSpot;
        Debug.Log("�������� �̵��޾��");

        Player_0ne.GetComponent<PlayerMoves>().Slerpmove();
        //findspot = searchPoint.GetComponent<SearchPoint>().searchLeft(_target);
    }

    public void rightMove()
    {
        target_pos = Player_0ne.transform.position;
        findSpot = new Vector3(target_pos.x + flyingDistance, target_pos.y, target_pos.z);
        transform.position = findSpot;
        Debug.Log("���������� �̵��޾��");

        Player_0ne.GetComponent<PlayerMoves>().Slerpmove();
        //Player_0ne.transform.position = Vector3.Slerp(Player_0ne.transform.position, findSpot, something);
        //findspot = searchPoint.GetComponent<SearchPoint>().searchLeft(_target);
    }
    public void forwardMove()
    {
        target_pos = Player_0ne.transform.position;
        findSpot = new Vector3(target_pos.x, target_pos.y, target_pos.z + flyingDistance);
        transform.position = findSpot; 
        Debug.Log("������ �̵��޾��");

        Player_0ne.GetComponent<PlayerMoves>().Slerpmove();
        //Player_0ne.transform.position = Vector3.Slerp(Player_0ne.transform.position, findSpot, something);
        //findspot = searchPoint.GetComponent<SearchPoint>().searchLeft(_target);
    }

    public void backMove()
    {
        target_pos = Player_0ne.transform.position;
        findSpot = new Vector3(target_pos.x, target_pos.y, target_pos.z - flyingDistance);
        transform.position = findSpot;
        Debug.Log("�������� �̵��޾��");

        Player_0ne.GetComponent<PlayerMoves>().Slerpmove();
        //Player_0ne.transform.position = Vector3.Slerp(Player_0ne.transform.position, findSpot, something % 5);
        //findspot = searchPoint.GetComponent<SearchPoint>().searchLeft(_target);
    }
}
