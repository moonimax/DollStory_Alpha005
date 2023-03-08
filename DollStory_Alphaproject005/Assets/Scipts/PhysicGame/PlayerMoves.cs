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

    //���ư��� ��
    public float jumpPower;

    //����Ƚ��
    private int jump_time = 1;

    public float jump_duration = 1f;

    //ĳ���� ȸ���ӵ�
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


    //�������� ������ ���� �޼���
   public void Slerpmove()
    {
        //�ٴڿ� ������ ������ ����
        if (!IsJumping)
        {
            IsJumping = true;
           
            //��ư ��Ȱ��ȭ
            for(int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<Button>().interactable = true;

            }

            practicePoint = GetComponentInChildren<SearchPoint>().findSpot;

            //��ǥ��ġ, ���� �Ŀ�, ���ӽð�, ���� ������ �����ִ� TWeen �Լ�
            this.transform.DOJump(practicePoint, jumpPower, jump_time, jump_duration);

            //���� ������ �Ĵٺ��� ��
            this.transform.LookAt(practicePoint);

            //�ִϸ��̼� ���� ����
            animator.SetBool("Jump", true);
        }
        //���߿� �������� �������� ���ϵ��� ��
        else
        {
            //��ư ��Ȱ��ȭ
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<Button>().interactable = false;

            }
            Debug.Log("���߿� ���ֽ��ϴ�");
            return;
        }

       
    }

    // �ٴڿ� ������ ���� ���ϰ� �ϴ� ����
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //�ٴڿ� ������ ���� ���� ���·� ����
            IsJumping = false;

            //�ִϸ��̼� �ٽ� �⺻���·� ����
            animator.SetBool("Jump", false);

            //�ٴڿ� �ٽ� ������ ��ư Ȱ��ȭ
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<Button>().interactable = true;

            }
        }
    }

}
