using TMPro;
using UnityEngine;

/// <summary>�X�g�[���[�C�x���g�����s����N���X</summary>
public class Story : MonoBehaviour
{
    /// <summary>��b��</summary>
    string[,] _message = new string[4,2]
    {
        // �X�g�[���[1
        {"�O�����}\n�͂��߂܂���", 
         "�O�����}\n���������N�b�L�[���Ă��Ă������"},
        // �X�g�[���[2
        {"�O�����}\n����ȃu���b�N���͏��߂Ă���", 
         "�O�����}\n�����N�b�L�[�Ă������Ȃ���"}, 
        // �X�g�[���[3
        {"���Ȃ�\n�����o�o�A�͏΂��Ă���Ȃ�...", 
         "���Ȃ�\n�ߋ��ɖ߂��Ă�蒼���ׂ���...?"}, 
        // �X�g�[���[4
        {"���Ȃ�\n�ǂ����Ă����Ȃ�����...", 
         "���Ȃ�\n�������������I��肾..."}
    };

    /// <summary>��b����\������e�L�X�g</summary>
    [Header("��b����\������e�L�X�g")]
    [SerializeField] TextMeshProUGUI _messageText;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>��b�����X�V����B��ʂ��N���b�N����x�ɌĂ΂��B</summary>
    public void UpdateMessageText()
    {

    }
}
