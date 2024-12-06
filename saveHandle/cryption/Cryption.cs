using System;
using System.Text;

namespace Cosmolapy.saveHandle.cryption;

public static class Cryption
{
	private const string alphabet = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	private const int distanceOfAlphabet = 36;

	private const int firstKey = 5;
	private const int secondKey = 7;

	public static string Encrypt(string dataString)
	{
		string dataEncrypted = "";
		int indexOfSymbol = 0;
		for (int index = 0; index < dataString.Length; index++)
		{
			if (!IsSymbolInAlpabet(dataString[index]))
			{
				dataEncrypted += dataString[index];
				continue;
			}

			if (index == 0)
			{
				indexOfSymbol = alphabet.IndexOf(dataString[index]) + firstKey;
				dataEncrypted += alphabet[GetNormalIndexFromAlphabet(indexOfSymbol)];
			}
			else
			{
				indexOfSymbol = alphabet.IndexOf(dataString[index]) + secondKey * index;
				dataEncrypted += alphabet[GetNormalIndexFromAlphabet(indexOfSymbol)];
			}
		}

		return dataEncrypted;
	}

	public static string Decrypt(string dataString)
	{
		string dataDecrypted = "";
		int indexOfSymbol = 0;
		for (int index = 0; index < dataString.Length; index++)
		{
			if (!IsSymbolInAlpabet(dataString[index]))
			{
				dataDecrypted += dataString[index];
				continue;
			}

			if (index == 0)
			{
				indexOfSymbol = alphabet.IndexOf(dataString[index]) - firstKey;
				if (indexOfSymbol >= 0) 
					dataDecrypted += alphabet[GetNormalIndexFromAlphabet(indexOfSymbol)];
				else 
					dataDecrypted += alphabet[alphabet.Length + GetNormalIndexFromAlphabet(indexOfSymbol)];
			}
			else 
			{
				indexOfSymbol = alphabet.IndexOf(dataString[index]) - secondKey * index;
				if (indexOfSymbol >= 0) 
					dataDecrypted += alphabet[GetNormalIndexFromAlphabet(indexOfSymbol)];
				else 
					dataDecrypted += alphabet[alphabet.Length + GetNormalIndexFromAlphabet(indexOfSymbol)];
				
			}
		}
		return dataDecrypted;
	}

	public static long ToUTF8(string dataString)
	{
		// Создаем массив байтов из строки с использованием кодировки ASCII
        byte[] utf8Bytes = Encoding.UTF8.GetBytes(dataString);
        
        // Преобразуем байты обратно в строку, используя ASCII
        StringBuilder sb = new StringBuilder();
        foreach (byte b in utf8Bytes)
        {
            sb.Append(b.ToString("D3").PadLeft(3)); // Форматируем байты как трехзначные числа
        }
        
        // string sbString = sb.ToString().Trim(); // Убираем лишний пробел в конце
		return Convert.ToInt64(sb.ToString().Trim());
	}

	public static string ToUTF8()
	{
		// Создаем массив байтов из строки с использованием кодировки ASCII
        byte[] utf8Bytes = Encoding.UTF8.GetBytes("Привет");
        
        // Преобразуем байты обратно в строку, используя ASCII
        StringBuilder sb = new StringBuilder();
        foreach (byte b in utf8Bytes)
        {
            sb.Append(b.ToString("D3").PadLeft(3)); // Форматируем байты как трехзначные числа
        }
        
        // string sbString = sb.ToString().Trim(); // Убираем лишний пробел в конце
		// return Convert.ToUInt64(sb.ToString().Trim());
		return sb.ToString().Trim();
	}

	private static bool IsSymbolInAlpabet(char symbol)
	{
		bool flagIfIn = false;
		foreach (char symbolInLine in alphabet)
		{
			if (symbol == symbolInLine)
			{
				flagIfIn = true;
				break;
			}
		}
		return flagIfIn;
	}

	private static int GetNormalIndexFromAlphabet(int index)
	{
        return index % distanceOfAlphabet;
	}
}
