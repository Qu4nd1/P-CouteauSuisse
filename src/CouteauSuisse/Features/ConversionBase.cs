using CouteauSuisse.Display;

namespace CouteauSuisse.Features
{
    class ConversionBase
    {

        private bool _running = true;
        private string _answerUser;
        private string _answerConverted;

        public void BaseMain(ConversionBase conversionBase, Verifications verifications)
        {
            ConversionBaseMenu conversionBaseMenu = new ConversionBaseMenu();
            do
            {
                int choice = conversionBaseMenu.RunInteractive();

                if (conversionBaseMenu.Options[choice - 1] == "Back To Menu")
                {
                    _running = false;
                }
                else
                {
                    conversionBaseMenu.HandleChoice(choice, conversionBase, verifications);
                    Console.WriteLine("\nPress any key to return to menu...");
                    Console.ReadKey(true);
                }
            } while (_running);
        }
        public string AskUser()
        {
            Console.Write("Entrez une valeur entière et postive: ");
            _answerUser = Console.ReadLine();

            return _answerUser;
        }
        public void Transformation(int optionNumber)
        {
            double answerToConvert;
            double answerConverting = 0;
            int baseNumber = 0;
            int power = 0;
            int binaryToOctalBundleSize = 3;
            int time = 0;
            char[] answerUserTab = new char[_answerUser.Length];
            char[] answerTransformation = Array.Empty<char>();
            


            for (int i = 0; i < _answerUser.Length; i++)
            {
                answerUserTab[i] = _answerUser[i];
            }
            //========= DECIMAL TO BINARY =========
            if (optionNumber == 1) 
            {
                answerToConvert = Convert.ToDouble(_answerUser);
                baseNumber = 2;
                while (answerToConvert >= Math.Pow(baseNumber, power))
                {
                    power++;
                }
                for (int i = power; i > -1; i--)
                {
                    if (Math.Pow(baseNumber, i) <= answerToConvert)
                    {
                        answerToConvert -= Math.Pow(baseNumber, i);
                        _answerConverted += "1";
                    }
                    else
                        _answerConverted += "0";
                }
            }
            //========= BINARY TO DECIMAL =========
            else if (optionNumber == 2) 
            {
                baseNumber = 2;
                power = _answerUser.Length;
                for (int i = 0; i < _answerUser.Length; i++)
                {
                    power--;
                    if (_answerUser[i] == '1')
                        answerConverting += Math.Pow(baseNumber, power);
                }
                _answerConverted = answerConverting.ToString();
            }
            //========= BINARY TO OCTAL =========
            else if (optionNumber == 3)
            {
                baseNumber = 2;
                if (_answerUser.Length%3 != 0)
                {
                    int originalSize = answerUserTab.Length;
                    int reste = 0;
                    bool found = false;
                    do
                    {
                        if (3 * time > originalSize)
                        {
                            reste = (3 * time) - originalSize;
                            found = true;
                        }
                        time++;
                    } while (found != true);
                    answerTransformation = new char[originalSize+reste];
                    Array.Copy(answerUserTab, 0, answerTransformation, reste, originalSize); 
                    for (int i = 0; i < reste; i++)
                    {
                        answerTransformation[i] = '0';
                    }
                    int count = 0;
                    for (int i = answerTransformation.Length / 3; i > 0; i--)
                    {
                        answerConverting = 0;
                        for (int j = binaryToOctalBundleSize; j > 0; j--)
                        {
                            if (answerTransformation[count] == '1')
                                answerConverting += Math.Pow(baseNumber, j-1);
                            count++;
                        }
                        _answerConverted += answerConverting.ToString();
                    }
                    
                }
                else
                {
                    answerTransformation = new char[answerUserTab.Length];
                    Array.Copy(answerUserTab, answerTransformation, answerUserTab.Length);
                    int count = 0;
                    for (int i = answerTransformation.Length / 3; i > 0; i--)
                    {
                        answerConverting = 0;
                        for (int j = binaryToOctalBundleSize; j > 0; j--)
                        {
                            if (answerTransformation[count] == '1')
                                answerConverting += Math.Pow(baseNumber, j-1);
                            count++;
                        }
                        _answerConverted += answerConverting.ToString();
                    }
                }
            }
            //========= OCTAL TO BINARY
            else if (optionNumber == 4)
            {
                baseNumber = 2;
                for (int i = 0; i < _answerUser.Length; i++)
                {
                    
                    double valueToConvert = _answerUser[i] - '0';
                    for (int j = 3; j > 0; j--)
                    {
                        if (Math.Pow(baseNumber, j-1) <= valueToConvert)
                        {
                            valueToConvert -= Math.Pow(baseNumber, j-1);
                            _answerConverted += "1";
                        }
                        else
                            _answerConverted += "0";
                    }
                }
            }
            Console.WriteLine($"Le résultat est: {_answerConverted}");
            _answerConverted = "";
        }
    }
}
