using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UpGrade : MonoBehaviour
{
    /// <summary>�w�����z</summary>
    [SerializeField] ulong _price = 0;

    /// <summary>�A�^�b�`��̃{�^��</summary>
    Button _button;

    /// <summary>�A�^�b�`��̃e�L�X�g</summary>
    [SerializeField] TextMeshProUGUI _shopText;

    /// <summary>�A�C�e���̖��O</summary>
    [SerializeField] string _name;

    /// <summary>�A�b�v�O���[�h����{��</summary>
    [SerializeField] Facility _facility;

    /// <summary>�A�b�v�O���[�h����N���b�J�[</summary>
    [SerializeField] Clicker _clicker;

    /// <summary>���\�[�X�Ǘ��N���X�̃C���X�^���X</summary>
    ResourceManager _resourceManager;

    void Start()
    {
        _resourceManager = ResourceManager.Instance;
        _button = gameObject.GetComponent<Button>();
        // �N���b�N���̃C�x���g��ݒ�
        _button.onClick.AddListener(UpGradeFacility);
    }

    void Update()
    {
        // �e�L�X�g���X�V
        _shopText.text = $"{_name}�@{_price}G";
    }

    void UpGradeFacility()
    {
        // �{�݂��A�b�v�O���[�h
        _facility._isUpGraded = true;

        // �N���b�J�[���A�b�v�O���[�h
        _clicker._isUpGraded = true;

        // ���݂̍w�����z�������\�[�X������
        _resourceManager.SubtractResource(_price);

        // �{�^��������
        Destroy(gameObject);
    }
}