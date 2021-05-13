using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject[] list;
    public string[] tipe;
    public string[] lvl;
    private XmlDocument xmlDoc;

    private void Start()
    {
        TextAsset xmlAsset = (TextAsset)Resources.Load("config");
        xmlDoc = new XmlDocument();
        if (xmlAsset) xmlDoc.LoadXml(xmlAsset.text);

        for (int i = 0; i < list.Length; i++)
        {
            for (int k = 0; k < tipe.Length; k++)
            {
                for (int e = 0; e < lvl.Length; e++)
                {
                    foreach (XmlNode Tower in xmlDoc.SelectNodes("root/Tower/" + tipe[k] + "/Lvl" + lvl[e]))
                    {
                        if (list[i].GetComponent<Tower>().tipe == tipe[k] && list[i].GetComponent<Tower>().lvl == lvl[e])
                        {
                            list[i].GetComponent<Tower>().price = int.Parse(Tower.Attributes.GetNamedItem("Price").Value);
                            list[i].GetComponent<Tower>().health = int.Parse(Tower.Attributes.GetNamedItem("Health").Value);
                            if (Tower.Attributes.GetNamedItem("Range") != null)
                            {
                                list[i].GetComponent<Tower>().range = int.Parse(Tower.Attributes.GetNamedItem("Range").Value);
                            }
                            if (Tower.Attributes.GetNamedItem("RateOfFire") != null)
                            {
                                list[i].GetComponent<Tower>().rateOfFire = int.Parse(Tower.Attributes.GetNamedItem("RateOfFire").Value);
                            }
                            if (Tower.Attributes.GetNamedItem("GoldGet") != null)
                            {
                                list[i].GetComponent<Tower>().goldGet = float.Parse(Tower.Attributes.GetNamedItem("GoldGet").Value);
                            }
                            if (Tower.Attributes.GetNamedItem("GoldDelay") != null)
                            {
                                list[i].GetComponent<Tower>().goldDelay = float.Parse(Tower.Attributes.GetNamedItem("GoldDelay").Value);
                            }
                            if (Tower.Attributes.GetNamedItem("PercentOfGold") != null)
                            {
                                list[i].GetComponent<Tower>().percentOfGold = int.Parse(Tower.Attributes.GetNamedItem("PercentOfGold").Value);
                            }
                        }
                    }
                }
            }
        }

    }
}
