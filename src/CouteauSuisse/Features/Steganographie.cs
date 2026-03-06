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
        string transformedLetterWithoutSpace;
        string notVisibleLetter = "";
        string transformedPhrase = "";
        string hiddenMessage = _answerUser[_hiddenMessageIndex] + ' ';
        string clearMessage = _answerUser[_clearMessageIndex];
        char letterSpace = '\u200D';
        char wordSpace = '\u2060';
        int lastCharIndex = 0;
        bool hiddenLetterAdded = false;
        bool hiddenWordNotAdded = true;
        bool hiddenSpaceAdded = false;
        string enryptedVisiblePhrase = "";
        string visibleLetter = "";
        for (int i = 0; i < clearMessage.Length; i++)
        {
            hiddenSpaceAdded = !hiddenSpaceAdded;
            hiddenLetterAdded = !hiddenLetterAdded;
            transformedPhrase += clearMessage[i];
            enryptedVisiblePhrase += clearMessage[i];
            if (hiddenWordNotAdded && (i < hiddenMessage.Length))
            {
                if (!hiddenLetterAdded)
                {
                    transformedPhrase += letterSpace;
                    enryptedVisiblePhrase += " ";
                    hiddenSpaceAdded = true;
                }
                if (hiddenSpaceAdded)
                {
                    transformedLetter = morse.ConvertToMorse(hiddenMessage[i].ToString());
                    transformedLetterWithoutSpace = transformedLetter.TrimEnd(' ');
                    for (int j = 0; j < transformedLetter.Length; j++)
                    {
                        if (j < transformedLetterWithoutSpace.Length)
                            switch (transformedLetter[j])
                            {
                                case '.':
                                    notVisibleLetter += '\u200B';
                                    visibleLetter += ".";
                                    break;

                                case '-':
                                    notVisibleLetter += '\u200C';
                                    visibleLetter += "-";
                                    break;
                            }
                        if (j == transformedLetterWithoutSpace.Length - 1)
                        {
                            lastCharIndex = j;
                            transformedPhrase += notVisibleLetter;
                            notVisibleLetter = "";
                            enryptedVisiblePhrase += visibleLetter;
                            visibleLetter = "";
                            hiddenLetterAdded = true;
                        }
                    }
                }
            }
            else
            {
                transformedPhrase += '\u2060';
                enryptedVisiblePhrase += "/";
            }
                
        }
        SaveToFile("../../../../../doc/stegano.txt", transformedPhrase);
        Console.WriteLine(enryptedVisiblePhrase);
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