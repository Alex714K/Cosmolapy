namespace Cosmolapy.saveHandle.cryption;

public class Cryption
{
	private const string alphabet = "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	private const int distanceOfAlphabet = 36;

	private const int firstKey = 5;
	private const int secondKey = 7;

	public string Encrypt(string dataString)
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

	public string Decrypt(string dataString)
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

	private bool IsSymbolInAlpabet(char symbol)
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

	private int GetNormalIndexFromAlphabet(int index)
	{
        return index % distanceOfAlphabet;
	}
}
