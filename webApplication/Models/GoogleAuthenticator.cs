using System.Text;
using System.Security.Cryptography;

namespace webApplication.Models
{
    public class GoogleAuthenticator
    {
        RNGCryptoServiceProvider rnd;
        public byte[] randomBytes = new byte[10];
        private string unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

        private int intervalLength;
        private int pinCodeLength;
        private int pinModulo;

        public GoogleAuthenticator()
        {
            rnd = new RNGCryptoServiceProvider();

            pinCodeLength = 6;
            intervalLength = 30;
            pinModulo = (int)Math.Pow(10, pinCodeLength);

            rnd.GetBytes(randomBytes);
        }

        public string UrlEncode(string value)
        {
            StringBuilder result = new StringBuilder();

            foreach (char symbol in value)
            {
                if (unreservedChars.IndexOf(symbol) != -1)
                {
                    result.Append(symbol);
                }
                else
                {
                    result.Append('%' + string.Format("{0:X2}", (int)symbol));
                }
            }

            return result.ToString();
        }

        public string generateResponseCode(long challenge, byte[] randomBytes)
        {
            HMACSHA1 myHmac = new HMACSHA1(randomBytes);
            myHmac.Initialize();

            byte[] value = BitConverter.GetBytes(challenge);
            Array.Reverse(value);
            myHmac.ComputeHash(value);
            byte[] hash = myHmac.Hash;
            int offset = hash[hash.Length - 1] & 0xF;

            byte[] SelectedFourBytes = new byte[4];
            SelectedFourBytes[0] = hash[offset];
            SelectedFourBytes[1] = hash[offset + 1];
            SelectedFourBytes[2] = hash[offset + 2];
            SelectedFourBytes[3] = hash[offset + 3];
            Array.Reverse(SelectedFourBytes);
            int finalInt = BitConverter.ToInt32(SelectedFourBytes, 0);

            int truncatedHash = finalInt & 0x7FFFFFFF;
            int pinValue = truncatedHash % pinModulo;
            return padOutput(pinValue);
        }

        private string padOutput(int value)
        {
            string result = value.ToString();
            for (int i = result.Length; i < pinCodeLength; i++)
            {
                result = "0" + result;
            }
            return result;
        }

        public string getPrivateKey(byte[] data)
        {
            return Transcoder.Base32Encode(data);
        }

        public long getCurrentInterval()
        {
            TimeSpan TS = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long currentTimeSeconds = (long)Math.Floor(TS.TotalSeconds);
            long currentInterval = currentTimeSeconds / intervalLength; // 30 Seconds
            return currentInterval;
        }

        public string GeneratePin()
        {
            return generateResponseCode(getCurrentInterval(), randomBytes);
        }
    }
}
/*
 * Typowe use case'y: 
 * 
 * Tworzenie nowego konta:
 * 
 * string randomString = Transcoder.Base32Encode(tp.randomBytes);    <------ randomowy secret do zapisania w DB pprzy użytkowniku
 * string ProvisionUrl = tp.UrlEncode(String.Format("otpauth://totp/{0}?secret={1}", "NazwaAplikacji", randomString));    <-------- tworzenie urla z nazwą aplikacji i wygenerowanym ciągiem znaków
 * string url = String.Format("http://chart.apis.google.com/chart?cht=qr&chs={0}x{1}&chl={2}", 200, 200, ProvisionUrl);    <------ generowanie url z kodem qr
 * WebClient wc = new WebClient(); 
 * var data = wc.DownloadData(url); 
 * BitmapImage bitmap = new BitmapImage();
 * bitmap.BeginInit();
 * bitmap.StreamSource = new MemoryStream(data);
 * bitmap.EndInit();
 * 
 * zostajemy na koniec z bitmapą już do wyświetlenia
 * możemy także wyświetlić kod do wpisania w aplikacji poprzez:
 * 
 * tp.getPrivateKey(tp.randomBytes);
 * 
 * Generowanie kodu dla aktualnych 30 sek: 
 * 
 * tp.generateResponseCode(tp.getCurrentInterval(), b) 
 *  
 * b to sekret wygemerpwamy wczesniej przez uzytkownika
 */