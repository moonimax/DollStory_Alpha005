using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public bool SpringMouse;
    public bool Toytrain;

    public float speed = 2f;
    //생성할 게임오브젝트의 프리팹
    private GameObject prefab;
    //웨이브 카운팅을 해주는 변수
    private int waveCount = 0;

    //왼쪽으로 생성될 transform의 위치
    private Vector3 placeA;
    //오른쪽으로 생성될 transform의 위치
    private Vector3 placeB;

    private Vector3 target;
    private Vector3 direction;
    //몇초마다 나오는지 카운트를 해주는 변수선언
    public float countdown = 5f;

    //public bool 
    Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        placeA = new Vector3(transform.position.x - 15f, transform.position.y, transform.position.z);
        placeB = new Vector3(transform.position.x + 15f, transform.position.y, transform.position.z);

        //목적지를 둘중 하나로 정하게 하는 코드구현필요
        target = placeB;
    
    }

    // Update is called once per frame
    void Update()
    {
        CheckObstacles();



        if (countdown <= 0)
        {
            //카운트 프로그램을 해주는 코루틴함수를 설계해야함
            StartCoroutine(SpawnWaves());
        }

    }



    IEnumerator SpawnWaves()
    {
        Instantiate(prefab, transform.position, rotation);

        //이동 속도와 Time.deltaTime을 곱하여 이동거리 계산
        float distance = speed * Time.deltaTime;

        //방향과 거리를 곱하여 이동 벡터 계산
        Vector3 movement = direction.normalized * distance;

        //prefab.transform.Translate

        yield return null;
    }

    //어떤 길인지 판명하는 메서드
    private void CheckObstacles()
    {
        if(SpringMouse == true)
        {
            prefab = GameObject.FindGameObjectWithTag("SpringMouse");
        }
    }

    private void LockOn()
    {
        //생성될 오브젝트의 회전값을 설정하기 위한 변수
        rotation = Quaternion.identity;

        //목적지로 이동할 방향계산
        direction = target - transform.position;

        if(direction != Vector3.zero)
        {
            rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
    }
}


/* 2개 1개 2개 1개 순차적으로 구현하는 로직을 구현한 예제 코드이다
 * 
 * public class SequentialLogic : MonoBehaviour
{
    public GameObject[] objects;  // 생성할 오브젝트 배열
    public float interval = 1.0f; // 생성 간격

    private int index = 0;        // 생성할 오브젝트 인덱스
    private bool isSecond = false; // 2번째 오브젝트를 생성할 차례인지 여부

    void Start()
    {
        // 첫 번째 오브젝트 생성
        CreateObject();
    }

    void Update()
    {
        // 생성 간격마다 새로운 오브젝트 생성
        if (Time.time >= interval * (index + 1))
        {
            CreateObject();
        }
    }

    void CreateObject()
    {
        // 2번째 오브젝트를 생성할 차례이면 2번째 오브젝트를 생성
        if (isSecond)
        {
            Instantiate(objects[1], transform.position, Quaternion.identity);
            isSecond = false;
        }
        // 2번째 오브젝트를 생성할 차례가 아니면 1번째 오브젝트를 생성
        else
        {
            Instantiate(objects[0], transform.position, Quaternion.identity);
            isSecond = true;
        }

        // 인덱스 증가
        index++;
    }
}
 * 
 * 
 */