static class Separatpr
{
    /// <summary>���l������؂肷��N���X</summary>
    public static string UlongToSI(this ulong num)
    {
        string[] suffixes = { "K", "M", "G", "T", "P", "E", "Z", "Y" }; // �T�t�B�b�N�X�̔z��

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
    public static string UlongToComma(this ulong num)
    {
        if (num == 0)
        {
            return "0";
        }
        else
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

    public static string ToketaString(this int num)
    {
        string[] suffixes = { "K", "M", "G", "T", "P", "E", "Z", "Y" }; // �T�t�B�b�N�X�̔z��

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