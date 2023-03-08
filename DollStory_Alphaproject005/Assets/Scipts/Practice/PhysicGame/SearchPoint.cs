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

    //x, z 좌표를 지정함
    [SerializeField]
    public Vector3 findSpot;

    public float something = 0.05f;
    
    [HideInInspector]
    Vector3 target_pos;

    //날아가는 거리
    public float flyingDistance = 3f;
  

    private void Start()
    {
        Player_0ne = GameObject.FindGameObjectWithTag("Player");
        Panel = GameObject.FindGameObjectWithTag("Panel");
    }
    //좌버튼을 누르면 좌로 판정 우로 누르면 우로 판정하는 시스템
    void Update()
    {
        
    
    }

    public void leftMove()
    {
        target_pos = Player_0ne.transform.position;
        findSpot = new Vector3(target_pos.x - flyingDistance, target_pos.y, target_pos.z);
        transform.position = findSpot;
        Debug.Log("왼쪽으로 이동햇어요");

        Player_0ne.GetComponent<PlayerMoves>().Slerpmove();
        //findspot = searchPoint.GetComponent<SearchPoint>().searchLeft(_target);
    }

    public void rightMove()
    {
        target_pos = Player_0ne.transform.position;
        findSpot = new Vector3(target_pos.x + flyingDistance, target_pos.y, target_pos.z);
        transform.position = findSpot;
        Debug.Log("오른쪽으로 이동햇어요");

        Player_0ne.GetComponent<PlayerMoves>().Slerpmove();
        //Player_0ne.transform.position = Vector3.Slerp(Player_0ne.transform.position, findSpot, something);
        //findspot = searchPoint.GetComponent<SearchPoint>().searchLeft(_target);
    }
    public void forwardMove()
    {
        target_pos = Player_0ne.transform.position;
        findSpot = new Vector3(target_pos.x, target_pos.y, target_pos.z + flyingDistance);
        transform.position = findSpot; 
        Debug.Log("앞으로 이동햇어요");

        Player_0ne.GetComponent<PlayerMoves>().Slerpmove();
        //Player_0ne.transform.position = Vector3.Slerp(Player_0ne.transform.position, findSpot, something);
        //findspot = searchPoint.GetComponent<SearchPoint>().searchLeft(_target);
    }

    public void backMove()
    {
        target_pos = Player_0ne.transform.position;
        findSpot = new Vector3(target_pos.x, target_pos.y, target_pos.z - flyingDistance);
        transform.position = findSpot;
        Debug.Log("뒤쪽으로 이동햇어요");

        Player_0ne.GetComponent<PlayerMoves>().Slerpmove();
        //Player_0ne.transform.position = Vector3.Slerp(Player_0ne.transform.position, findSpot, something % 5);
        //findspot = searchPoint.GetComponent<SearchPoint>().searchLeft(_target);
    }
}
