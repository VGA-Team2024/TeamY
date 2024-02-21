using System;
using UnityEngine;
using UnityEngine.UI;

public class StoryController : MonoBehaviour
{
    [Header("��b��")]
    [Multiline(3)]
    public string[] _lines;
    [Header("�I�����̓��e��")]
    public string[] _choices;

    [SerializeField] GameObject _choicePrefab;
    [SerializeField] Text _line;
    
    int _index = 0;
    void Start()
    {
        Conversation();
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && _index < _lines.Length)
        {
            //�{�^�������������b���i��
            Conversation();
        }
        else if(_index >= _lines.Length)
        {
            Choice();
        }
    }
    /// <summary>��b�C�x���g</summary>
    void Conversation()
    {
        _line.text = _lines[_index];
        _index++;
    }
    /// <summary>�I�����C�x���g</summary>
    void Choice()
    {
        for(int i = 0;i < _choices.Length; i++)//�I�����̐���������
        {
            var child = _choicePrefab.transform.GetChild(i);
            Text text = child.GetChild(0).GetComponent<Text>();
            text.text = _choices[i];//Button��Text��ύX
            //���̌�Ƀt���O������ǉ�
            child.gameObject.SetActive(true);
        }
    }
}
