using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary> point of game </summary>
    [SerializeField] private ulong _point = 1000;

    [SerializeField] private List<Item> _items = new List<Item>();

    [SerializeField] private bool _timer = true;
    
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("LIULIU : SecundGameManager");
            Destroy(gameObject);
        }
    }
    /// <summary>　Set Game Point　</summary>
    /// <param name="newPoint"> 計算した後の　ポイント　</param>
    public void SetPoint(ulong newPoint)
    {
        if (newPoint < 0)
        {
            newPoint = 0;
            Debug.LogError("LIULIU : point Under 0");
            return;
        }
        else if (newPoint < 10000000000000000000)
        {
            _point = newPoint;
            return;
        } 
        else
        {
            newPoint = 10000000000000000000;
            Debug.Log("進数");
        }
    }
    /// <summary> Geter </summary>
    /// <returns> Game point </returns>
    public ulong GetPoint()
    {
        return _point;
    }
    
    private IEnumerator count()
    {
        while (_timer)
        {
            var　dps = _items.Where(item => item.unlock == true).Select(item => item.ATK/item.cd).Sum();
            yield return new WaitForSeconds(1f); // 1秒待つ
        }
    }
}

[System.Serializable]
public class Item
{
    [Header("アイテムの解除")]
    public bool unlock;
    [Header("名前")]
    public string name;
    [Header("価格")]
    public int price;
    [Header("価格アップ倍率")]
    public float priceup;
    [Header("Level")]
    public int level; 
    [Header("攻撃力アップ倍率")]
    public float atkup; 
    [Header("攻撃力")]
    public float atk; 
    [Header("クールダウン")]
    public float cd; 
}
