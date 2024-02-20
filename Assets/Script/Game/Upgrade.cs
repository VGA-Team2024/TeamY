using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Upgrade : MonoBehaviour
{
    /// <summary>�w�����z</summary>
    [SerializeField] ulong _price = 0;

    /// <summary>�A�^�b�`��̃{�^��</summary>
    Button _button;

    /// <summary>�A�^�b�`��̉��i�e�L�X�g</summary>
    [SerializeField] TextMeshProUGUI _priceText;

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

        // �e�L�X�g���X�V
        _priceText.text = $"{_price} C";

        // �N���b�N���̃C�x���g��ݒ�
        _button.onClick.AddListener(UpgradeFacility);
    }

    void UpgradeFacility()
    {
        // �{�݂��A�b�v�O���[�h
        _facility._currentUpgradeFactor *= 2;

        // �N���b�J�[���A�b�v�O���[�h
        _clicker._currentUpgradeFactor *= 2;

        // �w�����z�������\�[�X������
        _resourceManager.SubtractResource(_price);

        // �{�^��������
        Destroy(gameObject);
    }
}