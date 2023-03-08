using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;


//스크립터블 오브젝트를 XML파일에 저장하는 코드
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
