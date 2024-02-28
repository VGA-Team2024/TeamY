using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryController : MonoBehaviour
{
    [Header("��b��")]
    [Multiline(3)]
    public string[] _lines;
    [Header("�I�����̓��e��")]
    public string[] _choices;

    /// <summary>�I�������܂Ƃ߂�GameObject������</summary>
    [SerializeField] GameObject _choicePrefab;
    /// <summary>��b����\������UIText������</summary>
    [SerializeField] TextMeshProUGUI _line;


    /// <summary>�e�I�������o�����邩�ۂ��̔z��</summary>
    public bool[] _flugs = new bool[3] { true, false, false };
    /// <summary>��b��i�߂邽�߂̃C���f�b�N�X</summary>
    int _index = 0;
    void Start()
    {
        Conversation();
    }
    /// <summary>��b�C�x���g�B��ʂ��N���b�N�����Ƃ��ɌĂ΂��</summary>
    public void Conversation()
    {
        if(_index < _lines.Length)//��b����\��
        {
            _line.text = _lines[_index];
            _index++;
        }
        else
        {
            Choice();//��b�����S�ĕ\�����ꂽ��I�����ɔ��
        }
    }
    /// <summary>�I�����C�x���g</summary>
    void Choice()
    {
        for(int i = 0;i < _choices.Length; i++)//�I�����̐���������
        {
            var child = _choicePrefab.transform.GetChild(i);
            TextMeshProUGUI text = child.GetChild(0).GetComponent<TextMeshProUGUI>();
            text.text = _choices[i];//Button��Text��ύX
            child.gameObject.SetActive(_flugs[i]);//�t���O��true�ɂȂ��Ă��镨�����\��
        }
    }
    /// <summary>��b�I�����ɌĂяo��</summary>
    public void StoryEnd()
    {
        Destroy(this.gameObject);//�I������I�񂾂玩�g������
    }
}
