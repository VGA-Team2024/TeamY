using System;
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
    public static GameManager Instance {get; private set; }
    public event Action OnPointChanged;    
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
            Debug.LogError("LIULIU : 進数");
        }
        OnPointChanged?.Invoke();
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
            yield return new WaitForSeconds(1f); // 1秒待つ
        }
    }
}

