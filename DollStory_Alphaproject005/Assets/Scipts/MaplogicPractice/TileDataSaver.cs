using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;


//��ũ���ͺ� ������Ʈ�� XML���Ͽ� �����ϴ� �ڵ�
public class TileDataSaver : MonoBehaviour
{
    public string xmlPath;
    public TileData tileData;

    
    void SaveTileData()
    {
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlPath);

        XmlNode rootNode = xmlDocument.SelectSingleNode("Tiles");
    }
}
