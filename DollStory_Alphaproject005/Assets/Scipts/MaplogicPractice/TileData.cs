using UnityEngine;

public class TileInfoList : MonoBehaviour
{
    //TileData 클래스를 scriptableobject로 만든 배열
    public TileData[] tileDataArray;
}


//에셋메뉴에서 스크립터블 오브젝트 생성
[CreateAssetMenu(fileName = "New Item", menuName = "Path/Item", order = 1)]

    public class TileData : ScriptableObject
    {
        public float pathnum;
        public string pathname = "New Item";
        public string Theme = "New theme";
        public string Obstacle = "Y/N";
        public float spawnProbability;

        //길의 것을 만들어야하는데 언제 이것을 불러일으키냐의 문제이다.
        public GameObject prefab;
        
        //길의 테마타입
        public pathType pathtype;

        //길에 대한 설명
        public string pathdescription;

        //길의 타입 정하기
        public enum pathType
        {
            BabyRoom,
            OnTable,
            PlayGround

        }
}




