using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PlayerMoves : MonoBehaviour
{
    [HideInInspector]
    public Transform Player_pos;

    GameObject Panels;

    GameObject searchPoint;

    Vector3 practicePoint;

    //날아가는 힘
    public float jumpPower;

    //점프횟수
    private int jump_time = 1;

    public float jump_duration = 1f;

    //캐릭터 회전속도
    [HideInInspector]
    public int turnspeed = 1;

    [HideInInspector]
    public bool IsJumping;
    [HideInInspector]
    public GameObject[] buttons;

    private Animator animator;

    private void Start()
    {
        Panels = GameObject.FindGameObjectWithTag("Panel");
        animator = GetComponent<Animator>();
        
        IsJumping = false;
    }
    // Update is called once per frame
    void Update()
    {

    }


    //실질적인 움직임 구현 메서드
   public void Slerpmove()
    {
        //바닥에 있으면 점프를 실행
        if (!IsJumping)
        {
            IsJumping = true;
           
            //버튼 비활성화
            for(int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<Button>().interactable = true;

            }

            practicePoint = GetComponentInChildren<SearchPoint>().findSpot;

            //목표위치, 점프 파워, 지속시간, 으로 점프를 시켜주는 TWeen 함수
            this.transform.DOJump(practicePoint, jumpPower, jump_time, jump_duration);

            //가는 방향을 쳐다보게 함
            this.transform.LookAt(practicePoint);

            //애니메이션 점프 실행
            animator.SetBool("Jump", true);
        }
        //공중에 떠있으면 점프하지 못하도록 함
        else
        {
            //버튼 비활성화
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<Button>().interactable = false;

            }
            Debug.Log("공중에 떠있습니다");
            return;
        }

       
    }

    // 바닥에 닿으면 점프 못하게 하는 판정
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //바닥에 닿으면 점프 가능 상태로 만듦
            IsJumping = false;

            //애니메이션 다시 기본상태로 전이
            animator.SetBool("Jump", false);

            //바닥에 다시 닿으면 버튼 활성화
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<Button>().interactable = true;

            }
        }
    }

}
