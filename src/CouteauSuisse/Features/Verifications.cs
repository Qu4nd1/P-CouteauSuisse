using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CouteauSuisse.Features.ConversionBase;

namespace CouteauSuisse.Features
{
    class Verifications
    {
        public string IntAndRangeCheck(int selectedOptionIndex, string answerUser, ConversionBase conversionBase)
        {
            bool typeValidity = true;
            bool rangeValidity = true;
            do
            {
                for (int i = 0; i < answerUser.Length; i++)
                {
                    if (char.IsDigit(answerUser[i]))
                    {
                        typeValidity = true;
                    }
                    else
                    {
                        typeValidity = false;
                        break;
                    }
                }
                if (typeValidity != true)
                    answerUser = conversionBase.AskUser();
                switch (selectedOptionIndex)
                {
                    case 1:
                        break;
                    case 2:
                        if (RangeCheck(0, 1, answerUser) == false)
                            answerUser = conversionBase.AskUser();
                        break;
                    case 3:
                        if (RangeCheck(0, 1, answerUser) == false)
                            answerUser = conversionBase.AskUser();
                        break;
                    case 4:
                        if (RangeCheck(0, 7, answerUser) == false)
                            answerUser = conversionBase.AskUser();
                        break;
                }
            } while (typeValidity != true && rangeValidity != true);
            return answerUser;
            
        }
        private bool RangeCheck(int valeurMin, int valeurMax, string answerUser)
        {
            bool rangeValidity = true;

            for (int i = answerUser.Length - 1; i >= 0; i--)
            {
                int charCheck = Convert.ToInt32(answerUser[i].ToString());
                if (valeurMin > charCheck || charCheck > valeurMax)
                {
                    rangeValidity = false;
                    break;
                }
            }
            return rangeValidity;
        }
    }
}
