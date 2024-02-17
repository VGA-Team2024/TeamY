using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using System;
using System.IO;
using System.Linq;
/// <summary>
/// セーブとロードをする。Seve(),Load()
/// セーブデータはResourcesフォルダにSaveData.jsonとして出力されます
/// </summary>
public class SeveAndLoad : MonoBehaviour
{
    [SerializeField]
    GameObject _shopPanel;
    void Start()
    {
        Load();
    }
    public void Save()
    {
        Facility[] facilities = _shopPanel.GetComponentsInChildren<Facility>();
        UpGrade[] upGrades = _shopPanel.GetComponentsInChildren<UpGrade>();
        List<FacilityData> facilitiesData = new();
        List<UpGrade> upgGadesData = new();
        //ShopPanelの子のobjectに対応するコンポーネントがアタッチされていたら
        //Listに追加する。
        foreach (Facility facility in facilities)
        {
            facilitiesData.Add(new FacilityData()
            {//facility._nameがpublicじゃなかったから変更をお願いする
                name = facility._name,
                ownedNum = facility._ownedNum,
            }
            );
        }
        foreach (UpGrade upgrade in upGrades)
        {//要変更
            upgGadesData.Add(upgrade);
        }

        //引っ張ってきたデータをSeveDataクラスでnew
        SeveData seveData = new()
        {
            Score = ResourceManager.Instance.GetResource(),
            facilitiesDataList = facilitiesData,
            upGradsList = upgGadesData
        };
        String json = JsonUtility.ToJson(seveData, true);//ここでSeveDataをJsonに変換
        File.WriteAllText($"Assets/Resources/SaveData.json", json);
        Debug.Log($"セーブした");
    }
    public void Load()
    {
        TextAsset jsonLoad = Resources.Load<TextAsset>("SaveData");
        SeveData seveData = JsonUtility.FromJson<SeveData>(jsonLoad.text);
        //↓ロードしたデータを各データに入れる
        DataSet(seveData);
        Debug.Log($"ロードした");
    }

    void DataSet(SeveData seveData)
    {
        ResourceManager.Instance.SetResource(seveData.Score);
        foreach (var facilityData in seveData.facilitiesDataList)
        {
            foreach (var facility in from Transform child in _shopPanel.transform
                                     //letでクエリ構文のなかで一旦やりたいことを書ける
                                     let facility = child.gameObject.GetComponent<Facility>()
                                     //whereでFacilityがアタッチされているchildを探す+α
                                     where child.gameObject.GetComponent<Facility>() && facility._name == facilityData.name
                                     //最終的に欲しいobjectをselectする、今回はFacility[]
                                     select facility)
            {
                facility._ownedNum = facilityData.ownedNum;
            }
        }
    }
}

[Serializable]
class FacilityData
{
    public string name;
    public ulong ownedNum;
}
[Serializable]
class SeveData
{
    public ulong Score;
    public List<FacilityData> facilitiesDataList;
    public List<UpGrade> upGradsList;
}
