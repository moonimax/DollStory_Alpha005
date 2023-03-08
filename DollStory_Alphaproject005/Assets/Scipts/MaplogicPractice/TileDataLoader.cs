using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

//Sciptable �����͸� XML������ �־ ����ȭ��Ű��
public class TileDataLoader : MonoBehaviour
{
    public string xmlgo;

    public int tileset = 30;

    public float zOffset = 1.2f;

    //List tileDataList �� �����ؼ� ���� �̰��� [i]�� ���·� ������Ʈ���� ���� �����ü�����
    public List<TileData> tileDataList;

    void Awake()
    {
    }

    private void Start()
    {
        LoadTileData(xmlgo);
        PlaceTiles();
    }

   private void LoadTileData(string fileName)
    {
        TextAsset xmlAsset = Resources.Load<TextAsset>(fileName);

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlAsset.text);

        XmlNodeList xmlNodeList = xmlDoc.SelectNodes("//Tiles");

        foreach (XmlNode xmlNode in xmlNodeList)
        {
            TileData tileData = ScriptableObject.CreateInstance<TileData>();
            tileData.pathname = xmlNode.SelectSingleNode("Name").InnerText;
            //tileData.prefab = Resources.Load<GameObject>(xmlNode.SelectSingleNode("prefab").InnerText);
            tileData.spawnProbability = float.Parse(xmlNode.SelectSingleNode("Rate").InnerText);
            tileData.pathnum = float.Parse(xmlNode.SelectSingleNode("Number").InnerText);
            tileData.Obstacle = xmlNode.SelectSingleNode("Obstacle").InnerText;
            tileData.Theme = xmlNode.SelectSingleNode("Theme").InnerText;

            tileData.prefab = Resources.Load<GameObject>($"Path/{tileData.pathnum}");
            //Ÿ�� ������ ����Ʈ�� �������� �߰����ش�
            tileDataList.Add(tileData);
            
        
        }


    }

    //Ÿ���� ��ġ�ϴ� �޼���
    void PlaceTiles()
    {
        float z = transform.position.z;

        //tileset���Ǹ�ŭ Ÿ���� place�Ѵ�
        while(z < transform.position.z + tileset)
        {
            //�Ÿ���� ���Դ��� �˼����� winnerindex�� tile�� ���°���
            TileData tile = ChooseRandomTile();
            
            if(tile != null)
            {
                Vector3 tilePosition = new Vector3(transform.position.x, transform.position.y, z);
                
                //Ÿ���� �����ϱ����� tile.prefab�� ���ڸ� ã�Ƽ� �����;��Ѵ�
                //�����۾��� �ʿ��ϴ�.
                Instantiate(tile.prefab, tilePosition, Quaternion.identity);


            }

            z += zOffset;
        }
    }



    //�ϳ��� ���� Ÿ���� �ϳ� �����ϴ� �޼��� //�ſ� �߿�!!!
    TileData ChooseRandomTile()
    {
        int result = 0;

        //�ʱⰪ�� 0���� ��������
        float totalProbability = 0;

        
        //XML�� ����� List���� TileData���� ��Ȯ���� ������
        foreach(TileData tile in tileDataList)
        {
            //�Ʊ���϶��� ��Ȯ������ Ȯ������ ������
            if(tile.Theme == "BabyRoom")
            {
                totalProbability += tile.spawnProbability;
            }
        }

        //�������� randomValue������ ����
        float randomValue = Random.Range(0f, totalProbability);

        totalProbability = 0;

        //int Themenum;

        for(int i = 0; i < tileDataList.Count; i++)
        {

            if(tileDataList[i].Theme == "BabyRoom")
            {
                totalProbability += tileDataList[i].spawnProbability;

                if(randomValue < totalProbability)
                {
                    //���糪�°����� 1�� �����༭ winnerindex�� ��ġ����
                    result = i;
                    
                    break;
                }
            }
        }

        //����Ʈ�� ����� Ÿ���� ���ڸ� ȣ�Ⱑ����
        return tileDataList[result];



        /*
    foreach(TileData tile in tileDataList)
    {
        //�Ʊ�� �׸��߿���
        if(tile.Theme == "BabyRoom")
        {
            //������ random���� �Ȯ������ �۰ԵǸ� ����
            if (randomValue < tile.spawnProbability)
            {
                return tile;
            }
        }


        randomValue -= tile.spawnProbability;
    }*/


    }   

}



/* ���Ӱ� xml������ ���� xml�� �����ϰ� �ϴ� �޼���
    public class TileDataSaver : MonoBehaviour
{
    public string xmlPath;
    public TileData tileData;

    void SaveTileData()
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlPath);

        XmlNode rootNode = xmlDocument.SelectSingleNode("TileDataCollection");

        XmlNode tileDataNode = xmlDocument.CreateElement("TileData");

        XmlNode nameNode = xmlDocument.CreateElement("name");
        nameNode.InnerText = tileData.name;
        tileDataNode.AppendChild(nameNode);

        XmlNode prefabNode = xmlDocument.CreateElement("prefab");
        prefabNode.InnerText = tileData.prefab.name;
        tileDataNode.AppendChild(prefabNode);

        XmlNode spawnProbabilityNode = xmlDocument.CreateElement
    }
    */