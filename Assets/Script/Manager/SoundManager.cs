using UnityEngine;

// AudioSource���A�^�b�`
[RequireComponent(typeof(AudioSource))]

/// <summary>SE�EBGM���Ǘ�����N���X</summary>
public class SoundManager : MonoBehaviour
{
    /// <summary>�{�݂̍w���{�^���ōĐ�����SE</summary>
    [Header("�{��")]
    [SerializeField] AudioClip[] _facilitySound = null;

    /// <summary>�A�b�v�O���[�h�̍w���{�^���ōĐ�����SE</summary>
    [Header("�A�b�v�O���[�h")]
    [SerializeField] AudioClip[] _upgradeSound = null;

    /// <summary>���̑��̃{�^���ōĐ�����SE</summary>
    [Header("���̑�")]
    [SerializeField] AudioClip[] _otherSound = null;

    /// <summary>�I�[�f�B�I�\�[�X</summary>
    AudioSource _audioSource;

    /// <summary>�C���X�^���X</summary>
    public static SoundManager Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    /// <summary>�{�݃{�^����SE���Đ����郁�\�b�h�B�e�{�^������Ăяo�����B</summary>
    /// <param name="soundNum">AudioClip�z��̃C���f�b�N�X�B 0 = �J�[�\��, 1 = �O�����}, 2 = �e, 3 = �w��, 4 = ��</param>
    public void PlayFacilitySound(int soundNum)
    {
        _audioSource.PlayOneShot(_facilitySound[soundNum]);
    }

    /// <summary>�A�b�v�O���[�h�{�^����SE���Đ����郁�\�b�h�B�e�{�^������Ăяo�����B</summary>
    /// <param name="soundNum">AudioClip�z��̃C���f�b�N�X�B 0 = �J�[�\��, 1 = �O�����}, 2 = �e, 3 = �w��, 4 = ��</param>
    public void PlayUpgradeSound(int soundNum)
    {
        _audioSource.PlayOneShot(_upgradeSound[soundNum]);
    }

    /// <summary>���̑���SE���Đ����郁�\�b�h�B�e�{�^������Ăяo�����B</summary>
    /// <param name="soundNum">AudioClip�z��̃C���f�b�N�X�B 0 = �N���b�J�[�i�N���b�N�j, 1 = �N���b�J�[�i�}�E�X�I�[�o�[�j, 2 = �p�l���؂�ւ�, 3 = �X�g�[���[�i�s, 4 = �]��, 5 = ����</param>
    public void PlayOtherSound(int soundNum)
    {
        _audioSource.PlayOneShot(_otherSound[soundNum]);
    }
}
