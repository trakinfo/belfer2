using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Belfer.Helpers
{
    public static class StringHelper
    {
        public static bool DigitOnly(string Value)
        {
            try
            {
                if (Value.Length == 0) return false;
                foreach (var S in Value)
                {
                    if (!char.IsDigit(S)) return false;
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Verify string if it is a valid email string
        /// </summary>
        /// <param name="email">Text to verify against email principle</param>
        /// <returns>Returns true if e-mail is OK, otherwise false</returns>
        public static bool ValidateEmail(string email)
        {
            var pattern = @"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$";
            Regex rgx = new Regex(pattern);
            return rgx.IsMatch(email);
        }
        public static bool ValidatePassword(string pwd)
        {
            var MinLength = AppVars.MinPwdLength;
            var pattern = @"(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{" + MinLength + ",}";
            Regex rgx = new Regex(pattern);
            return rgx.IsMatch(pwd);
        }
        public static string RandomizePassword()
        {
            var MinPwdLength = AppVars.MinPwdLength;
            var MaxPwdLength = AppVars.MaxPwdLength;

            var PASSWORD_CHARS_LCASE = "abcdefghijkmnopqrstwxyz";
            var PASSWORD_CHARS_UCASE = "ABCDEFGHJKLMNPQRSTWXYZ";
            var PASSWORD_CHARS_NUMERIC = "23456789";
            var PASSWORD_CHARS_SPECIAL = "$?&!%";

            var charGroups = new char[][] { PASSWORD_CHARS_LCASE.ToCharArray(), PASSWORD_CHARS_UCASE.ToCharArray(), PASSWORD_CHARS_NUMERIC.ToCharArray(), PASSWORD_CHARS_SPECIAL.ToCharArray() };

            var charsLeftInGroup = new int[charGroups.Length];
            for (int i = 0; i < charsLeftInGroup.Length; i++)
            {
                charsLeftInGroup[i] = charGroups[i].Length;
            }

            var leftGroupsOrder = new int[charGroups.Length];
            for (int i = 0; i < leftGroupsOrder.Length; i++)
            {
                leftGroupsOrder[i] = i;
            }

            var randomBytes = new byte[4];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(randomBytes);

            var seed = BitConverter.ToInt32(randomBytes, 0);
            var random = new Random(seed);
            char[] password = null;

            if (MinPwdLength < MaxPwdLength)
            {
                password = new char[random.Next(MinPwdLength, MaxPwdLength)];
            }
            else
            {
                password = new char[MinPwdLength];
            }

            var nextCharIdx = new int();
            var nextGroupIdx = new int();
            var nextLeftGroupsOrderIdx = new int();
            var lastCharIdx = new int();
            var lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;

            for (int i = 0; i < password.Length; i++)
            {
                if (lastLeftGroupsOrderIdx == 0)
                {
                    nextLeftGroupsOrderIdx = 0;
                }
                else
                {
                    nextLeftGroupsOrderIdx = random.Next(0, lastLeftGroupsOrderIdx);
                }
                nextGroupIdx = leftGroupsOrder[nextLeftGroupsOrderIdx];
                lastCharIdx = charsLeftInGroup[nextGroupIdx] - 1;
                if (lastCharIdx == 0)
                {
                    nextCharIdx = 0;
                }
                else
                {
                    nextCharIdx = random.Next(0, lastCharIdx + 1);
                }
                password[i] = charGroups[nextGroupIdx][nextCharIdx];
                if (lastCharIdx == 0)
                {
                    charsLeftInGroup[nextGroupIdx] = charGroups[nextGroupIdx].Length;
                }
                else
                {
                    if (lastCharIdx != nextCharIdx)
                    {
                        var temp = charGroups[nextGroupIdx][lastCharIdx];
                        charGroups[nextGroupIdx][nextCharIdx] = charGroups[nextGroupIdx][nextCharIdx];
                        charGroups[nextGroupIdx][nextCharIdx] = temp;
                    }
                    charsLeftInGroup[nextGroupIdx] = charsLeftInGroup[nextGroupIdx] - 1;
                }
                if (lastLeftGroupsOrderIdx == 0)
                {
                    lastLeftGroupsOrderIdx = leftGroupsOrder.Length - 1;
                }
                else
                {
                    if (lastLeftGroupsOrderIdx != nextLeftGroupsOrderIdx)
                    {
                        var temp = leftGroupsOrder[lastLeftGroupsOrderIdx];
                        leftGroupsOrder[lastLeftGroupsOrderIdx] = leftGroupsOrder[nextLeftGroupsOrderIdx];
                        leftGroupsOrder[nextLeftGroupsOrderIdx] = temp;
                    }
                    lastLeftGroupsOrderIdx = lastLeftGroupsOrderIdx - 1;
                }
            }
            return new string(password);

        }
    }
}
