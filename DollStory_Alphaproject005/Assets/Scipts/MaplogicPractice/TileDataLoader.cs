using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

//Sciptable 데이터를 XML파일을 넣어서 동기화시키기
public class TileDataLoader : MonoBehaviour
{
    public string xmlgo;

    public int tileset = 30;

    public float zOffset = 1.2f;

    //List tileDataList 를 저장해서 이제 이것의 [i]의 형태로 오브젝트들의 값을 가져올수잇음
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
            //타일 데이터 리스트에 정보값을 추가해준다
            tileDataList.Add(tileData);
            
        
        }


    }

    //타일을 배치하는 메서드
    void PlaceTiles()
    {
        float z = transform.position.z;

        //tileset수의만큼 타일을 place한다
        while(z < transform.position.z + tileset)
        {
            //어떤타일이 나왔는지 알수있음 winnerindex로 tile이 나온것임
            TileData tile = ChooseRandomTile();
            
            if(tile != null)
            {
                Vector3 tilePosition = new Vector3(transform.position.x, transform.position.y, z);
                
                //타일을 생성하기전에 tile.prefab을 숫자를 찾아서 가져와야한다
                //사전작업이 필요하다.
                Instantiate(tile.prefab, tilePosition, Quaternion.identity);


            }

            z += zOffset;
        }
    }



    //하나의 랜덤 타일을 하나 추출하는 메서드 //매우 중요!!!
    TileData ChooseRandomTile()
    {
        int result = 0;

        //초기값을 0으로 설정해줌
        float totalProbability = 0;

        
        //XML로 저장된 List값의 TileData값의 총확률을 가져옴
        foreach(TileData tile in tileDataList)
        {
            //아기방일때의 총확률에서 확률값을 더해줌
            if(tile.Theme == "BabyRoom")
            {
                totalProbability += tile.spawnProbability;
            }
        }

        //뽑힐값이 randomValue값으로 지정
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
                    //현재나온값에서 1을 더해줘서 winnerindex에 배치해줌
                    result = i;
                    
                    break;
                }
            }
        }

        //리스트에 저장된 타일의 숫자를 호출가능함
        return tileDataList[result];



        /*
    foreach(TileData tile in tileDataList)
    {
        //아기방 테마중에서
        if(tile.Theme == "BabyRoom")
        {
            //임의의 random값이 어떤확률보다 작게되면 빼라
            if (randomValue < tile.spawnProbability)
            {
                return tile;
            }
        }


        randomValue -= tile.spawnProbability;
    }*/


    }   

}



/* 새롭게 xml파일을 만들어서 xml을 저장하게 하는 메서드
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