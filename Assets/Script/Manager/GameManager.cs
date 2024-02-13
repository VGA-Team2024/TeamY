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
    [SerializeField] private bool _timer = true;
    [SerializeField] private ulong _clickPoint = 2;
    public static GameManager Instance { get; private set; }
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

    public void ChangePoint(ulong value)
    {
        SetPoint(GetPoint() + value);
    }

    /// <summary> Geter </summary>
    /// <returns> Game point </returns>
    public ulong GetPoint()
    {
        return _point;
    }

    /// <summary>  Click したらここ呼ぶ</summary>
    public void Click()
    {
        SetPoint(GetPoint() + _clickPoint);
    }

    private IEnumerator count()
    {
        while (_timer)
        {
            yield return new WaitForSeconds(1f); // 1秒待つ
        }
    }
}


static class LiuToketaString
{
    /// <summary>
    ///  値を桁あり文字列として取得
    /// 例:10000000 >>  10M000K000
    /// </summary>
    /// <param name="num">   文字列として取得したい値   </param>
    /// <returns>桁あり文字列表現</returns>
    public static string ToketaString(this ulong num)
    {
        string[] suffixes = { "K", "M", "G", "T", "P", "E", "Z", "Y" }; // サフィックスの配列

        string result = "";
        for (int i = 0; num > 0; i++)
        {
            if (num >= 1000)
            {
                result = suffixes[i] + (num % 1000).ToString("000") + result;
                num /= 1000;
            }
            else
            {
                result = num + result;
                num = 0;
            }
        }
        return result;
    }
    public static string TocammaString(this ulong num)
    {
        string result = "";
        for (int i = 0; num > 0; i++)
        {
            if (num >= 1000)
            {
                result = "," + (num % 1000).ToString("000") + result;
                num /= 1000;
            }
            else
            {
                result = num + result;
                num = 0;
            }
        }
        return result;
    }
    
    public static string ToketaString(this int num)
    {
        string[] suffixes = { "K", "M", "G", "T", "P", "E", "Z", "Y" }; // サフィックスの配列

        string result = "";
        for (int i = 0; num > 0; i++)
        {
            if (num >= 1000)
            {
                result = suffixes[i] + (num % 1000).ToString("000") + result;
                num /= 1000;
            }
            else
            {
                result = num + result;
                num = 0;
            }
        }
        return result;
    }

    public static string TocammaString(this int num)
    {
        string result = "";
        for (int i = 0; num > 0; i++)
        {
            if (num >= 1000)
            {
                result = "," + (num % 1000).ToString("000") + result;
                num /= 1000;
            }
            else
            {
                result = num + result;
                num = 0;
            }
        }
        return result;
    }
}