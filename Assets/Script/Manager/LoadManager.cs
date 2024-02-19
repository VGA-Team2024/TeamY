using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

/// <summary>
/// Instance.Load()���ĂԂ�
/// Resources�t�@�C���ɂ���SaveData�����[�h���ăQ�[�����̃f�[�^�ɔ��f�����邱�Ƃ��ł��܂��B
/// </summary>
public class LoadManager : MonoBehaviour
{
    public static LoadManager instance;
    //�V���O���g��
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
    }
    [SerializeField]
    GameObject _shopPanel;
    void Start()
    {
        if (File.Exists($"Assets/Resources/SaveData.json"))
        {
            Load();
        }
    }
    public void Load()
    {
        TextAsset jsonLoad = Resources.Load<TextAsset>("SaveData");
        SaveData savedata = JsonUtility.FromJson<SaveData>(jsonLoad.text);
        //�����[�h�����f�[�^���e�f�[�^�ɓ����
        DataSet(savedata);
        Debug.Log($"���[�h����");
    }

    void DataSet(SaveData savedata)
    {
        ResourceManager.Instance.SetResource(savedata.score);
        foreach (var facilityData in savedata.facilitiesDataList)
        {
            foreach (var facility in from Transform child in _shopPanel.transform
                                         //let�ŃN�G���\���̂Ȃ��ň�U��肽�����Ƃ�������
                                     let facility = child.gameObject.GetComponent<Facility>()
                                     //where��Facility���A�^�b�`����Ă���child��T��+��
                                     where child.gameObject.GetComponent<Facility>() && facility._name == facilityData.name
                                     //�ŏI�I�ɗ~����object��select����A�����Facility[]
                                     select facility)
            {
                facility._ownedNum = facilityData.ownedNum;
                facility._isUpGraded = facilityData.isUpGraded;
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
                                        select upGradeData)//���̃V�[�����̃f�[�^�ɁASavedata�ɂ���A�b�v�O���[�h��object���Ȃ�������A�V������������܂�

            {
                Instantiate(upGradeData.gameObject, _shopPanel.transform).SetActive(true);
            }
        }
    }
}
