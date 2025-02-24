using System.Security.Cryptography;

namespace aDVanceERP.Core.Utiles {
    public static class UtilesCifrado {
        private static readonly byte[] Key = Convert.FromBase64String("WoKaI8BhY7WhJK2yJ6vXV//HJFcK30gxK9X1vKGtl1s="); // Debe ser de 32 bytes para AES-256
        private static readonly byte[] IV = Convert.FromBase64String("an9aKNBQ+kAmmcN4oxw6FA=="); // Debe ser de 16 bytes

        public static string Cifrar(string texto) {
            using (var aes = Aes.Create()) {
                aes.Key = Key;
                aes.IV = IV;

                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream()) {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write)) {
                        using (var sw = new StreamWriter(cs)) {
                            sw.Write(texto);
                        }
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
        }

        public static string Descifrar(string textoCifrado) {
            using (var aes = Aes.Create()) {
                aes.Key = Key;
                aes.IV = IV;

                var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (var ms = new MemoryStream(Convert.FromBase64String(textoCifrado))) {
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read)) {
                        using (var sr = new StreamReader(cs)) {
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
