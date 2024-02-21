using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

/// <summary>
/// Instance.Load()を呼ぶと
/// ResourcesファイルにあるSaveDataをロードしてゲーム内のデータに反映させることができます。
/// </summary>
public class LoadManager : MonoBehaviour
{
    public static LoadManager instance;
    //シングルトン
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        if (File.Exists($"Assets/Resources/SaveData.json"))
        {
            Load();
        }
    }
    [SerializeField]
    GameObject _shopPanel;
    /// <summary>
    /// ResourcesフォルダのSaveData.jsonをSaveDataクラスに変換して、DataSetメソッドで各データに入れます
    /// </summary>
    public void Load()
    {
        TextAsset jsonLoad = Resources.Load<TextAsset>("SaveData");
        SaveData savedata = JsonUtility.FromJson<SaveData>(jsonLoad.text);
        //↓ロードしたデータを各データに入れる
        DataSet(savedata);
        Debug.Log($"ロードした");
    }
    /// <summary>
    /// ShopPanelのなかにあるFacilityには各パラメータを入れる
    /// UpGradeはSaveDataにあって場になかったら生成、逆は破壊
    /// </summary>
    /// <param name="savedata">score
    /// <para>facilitiesDataList[]{name,ownedNum,currentPrice,currentUpgradeFactor}</para>
    /// upGradsDataList[]{name,isOwnedinstanceID}
    /// </param>
    void DataSet(SaveData savedata)
    {
        ResourceManager.Instance.SetResource(savedata.score);
        foreach (var facilityData in savedata.facilitiesDataList)
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
                facility._currentPrice = facilityData.currentPrice;
                facility._currentUpgradeFactor = facilityData.currentUpgradeFactor;
            }
        }
        if (savedata.upGradsDataList.Count == 0)
        {
            foreach (var child in from Transform child in _shopPanel.transform
                                  where child.GetComponent<UpGrade>()
                                  select child)
            {
                Destroy(child.gameObject);
            }
        }
        else
        {
            foreach (var upGradeData in from upGradeData in savedata.upGradsDataList
                                        let upGrades = _shopPanel.GetComponentsInChildren<UpGrade>()
                                        where upGrades == null || !upGrades.Any(x => x._name == upGradeData.name)
                                        select upGradeData)//今のシーン内のデータに、Savedataにあるアップグレードのobjectがなかったら、新しく生成されます
            {
                Instantiate(upGradeData.gameObject, _shopPanel.transform).SetActive(true);
            }
        }
    }
}
