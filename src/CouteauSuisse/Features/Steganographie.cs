using CouteauSuisse.Display;

namespace CouteauSuisse.Features;

class Steganographie
{
    private bool _running = true;
    private string[] _answerUser = new string[2];
    public string[] AnswerUser { get { return _answerUser; } }
    private string _answerConverted;
    private int _clearMessageIndex = 0;
    private int _hiddenMessageIndex = 1;

    public void StegMain(Steganographie steganographie, Morse morse, Verifications verifications)
    {
        SteganographieMenu steganographieMenu = new SteganographieMenu();
        do
        {
            int choice = steganographieMenu.RunInteractive();

            if (steganographieMenu.Options[choice - 1] == "Back To Menu")
            {
                _running = false;
            }
            else
            {
                steganographieMenu.HandleChoice(choice, steganographie, morse, verifications);
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey(true);
            }
        } while (_running);
    }
    public string[] AskUser(bool optionChoice)
    {
        if (optionChoice)
        {
            Console.WriteLine("Texte porteur (ce que l'on verra): ");
            _answerUser[_clearMessageIndex] = Console.ReadLine();
            Console.WriteLine("Message secret à cacher (A-Z et espace): "); 
            _answerUser[_hiddenMessageIndex] = Console.ReadLine();
        }
        else
        {
        }
        return _answerUser;
    }

    public void SaveToFile(string path, string result)
    {
        using (StreamWriter sw = new StreamWriter(path, false))
        {
            sw.WriteLine(result);
        }
    }

    public string ReadFromFile(string path)
    {
        try
        {
            using (StreamReader sr = new StreamReader(path))
            {
                return sr.ReadLine() ?? string.Empty;
            }
        }
        catch
        {
            // Si erreur de lecture alors on renvoie un string vide pour pas renvoyer un null
            return string.Empty;
        }
    }
    public void EncodingTransformation(Morse morse)
    {
        string transformedLetter;
        string notVisibleLetter = "";
        string transformedPhrase = "";
        string hiddenMessage = _answerUser[_hiddenMessageIndex] + ' ';
        string clearMessage = _answerUser[_clearMessageIndex];
        for (int i = 0; i < clearMessage.Length; i++)
        {
            transformedPhrase += clearMessage[i];
            if (i < (hiddenMessage.Length - 1))
            {
                transformedLetter = morse.ConvertToMorse(hiddenMessage[i].ToString());
                for (int j = 0; j < transformedLetter.Length; j++)
                {
                    if (transformedLetter[j] == '.')
                    {
                        notVisibleLetter += '\u200B';
                    }
                    else if (transformedLetter[j] == '-')
                    {
                        notVisibleLetter += '\u200C';
                    }
                    else if (transformedLetter[j] == ' ')
                    {
                        notVisibleLetter += '\u200D';
                    }
                }
                transformedPhrase += notVisibleLetter;
                transformedLetter = "";
            }
            else
            {
                transformedPhrase += '\u2060';
            }
        }
        SaveToFile("D:/114/P-CouteauSuisse/doc/stegano.txt", transformedPhrase);
        Console.WriteLine("Le texte avec stéganographie a été sauvegardé dans le fichier stegano.txt");
    }

    public void DecodingTransformation(Morse morse)
    {
        string messageToDecode;
        string messageDecoded;
        messageToDecode = ReadFromFile("D:/114/P-CouteauSuisse/doc/stegano.txt");
        messageDecoded = morse.MorseToText(messageToDecode);
        Console.WriteLine($"Le message caché est: {messageDecoded}");
        
    }
}