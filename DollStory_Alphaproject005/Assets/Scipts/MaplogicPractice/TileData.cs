using UnityEngine;

public class TileInfoList : MonoBehaviour
{
    //TileData Ŭ������ scriptableobject�� ���� �迭
    public TileData[] tileDataArray;
}


//���¸޴����� ��ũ���ͺ� ������Ʈ ����
[CreateAssetMenu(fileName = "New Item", menuName = "Path/Item", order = 1)]

    public class TileData : ScriptableObject
    {
        public float pathnum;
        public string pathname = "New Item";
        public string Theme = "New theme";
        public string Obstacle = "Y/N";
        public float spawnProbability;

        //���� ���� �������ϴµ� ���� �̰��� �ҷ�����Ű���� �����̴�.
        public GameObject prefab;
        
        //���� �׸�Ÿ��
        public pathType pathtype;

        //�濡 ���� ����
        public string pathdescription;

        //���� Ÿ�� ���ϱ�
        public enum pathType
        {
            BabyRoom,
            OnTable,
            PlayGround

        }
}




