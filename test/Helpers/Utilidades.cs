using System.Security.Cryptography;
using System.Text;

namespace LuegoPago.Helpers
{
    public class Utilidades
    {
        // Método para encriptar una cadena usando SHA256.
        public string EncriptarSHA256(string texto)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Computar el hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));

                // Convertir el array de bytes a string
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // Método para verificar si una cadena en texto plano coincide con un hash SHA256 almacenado.
        public bool VerificarSHA256(string textoPlano, string hashAlmacenado)
        {
            // Hash de la contraseña proporcionada
            var hashTextoPlano = EncriptarSHA256(textoPlano);

            // Comparar con el hash almacenado
            return string.Equals(hashTextoPlano, hashAlmacenado);
        }
    }
}
