using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public bool SpringMouse;
    public bool Toytrain;

    public float speed = 2f;
    //������ ���ӿ�����Ʈ�� ������
    private GameObject prefab;
    //���̺� ī������ ���ִ� ����
    private int waveCount = 0;

    //�������� ������ transform�� ��ġ
    private Vector3 placeA;
    //���������� ������ transform�� ��ġ
    private Vector3 placeB;

    private Vector3 target;
    private Vector3 direction;
    //���ʸ��� �������� ī��Ʈ�� ���ִ� ��������
    public float countdown = 5f;

    //public bool 
    Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        placeA = new Vector3(transform.position.x - 15f, transform.position.y, transform.position.z);
        placeB = new Vector3(transform.position.x + 15f, transform.position.y, transform.position.z);

        //�������� ���� �ϳ��� ���ϰ� �ϴ� �ڵ屸���ʿ�
        target = placeB;
    
    }

    // Update is called once per frame
    void Update()
    {
        CheckObstacles();



        if (countdown <= 0)
        {
            //ī��Ʈ ���α׷��� ���ִ� �ڷ�ƾ�Լ��� �����ؾ���
            StartCoroutine(SpawnWaves());
        }

    }



    IEnumerator SpawnWaves()
    {
        Instantiate(prefab, transform.position, rotation);

        //�̵� �ӵ��� Time.deltaTime�� ���Ͽ� �̵��Ÿ� ���
        float distance = speed * Time.deltaTime;

        //����� �Ÿ��� ���Ͽ� �̵� ���� ���
        Vector3 movement = direction.normalized * distance;

        //prefab.transform.Translate

        yield return null;
    }

    //� ������ �Ǹ��ϴ� �޼���
    private void CheckObstacles()
    {
        if(SpringMouse == true)
        {
            prefab = GameObject.FindGameObjectWithTag("SpringMouse");
        }
    }

    private void LockOn()
    {
        //������ ������Ʈ�� ȸ������ �����ϱ� ���� ����
        rotation = Quaternion.identity;

        //�������� �̵��� ������
        direction = target - transform.position;

        if(direction != Vector3.zero)
        {
            rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
    }
}


/* 2�� 1�� 2�� 1�� ���������� �����ϴ� ������ ������ ���� �ڵ��̴�
 * 
 * public class SequentialLogic : MonoBehaviour
{
    public GameObject[] objects;  // ������ ������Ʈ �迭
    public float interval = 1.0f; // ���� ����

    private int index = 0;        // ������ ������Ʈ �ε���
    private bool isSecond = false; // 2��° ������Ʈ�� ������ �������� ����

    void Start()
    {
        // ù ��° ������Ʈ ����
        CreateObject();
    }

    void Update()
    {
        // ���� ���ݸ��� ���ο� ������Ʈ ����
        if (Time.time >= interval * (index + 1))
        {
            CreateObject();
        }
    }

    void CreateObject()
    {
        // 2��° ������Ʈ�� ������ �����̸� 2��° ������Ʈ�� ����
        if (isSecond)
        {
            Instantiate(objects[1], transform.position, Quaternion.identity);
            isSecond = false;
        }
        // 2��° ������Ʈ�� ������ ���ʰ� �ƴϸ� 1��° ������Ʈ�� ����
        else
        {
            Instantiate(objects[0], transform.position, Quaternion.identity);
            isSecond = true;
        }

        // �ε��� ����
        index++;
    }
}
 * 
 * 
 */