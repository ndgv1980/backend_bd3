using BackendBDIII.Data.Repositories;
using BackendBDIII.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BackendBDIII.Data
{
    public static class HelperMethods
    {
        public static string GetUserHash(Usuario i_usuario) 
        {
            string data = $"{i_usuario.Id}{i_usuario.Nombre}{i_usuario.Contra}{i_usuario.Administrador}";
            return sha256_hash(data);
        }

        public static async Task<bool> ValidateToken(IUsuarioRepository i_usuarioRepository, string i_token) 
        {
            var users = await i_usuarioRepository.GetAllUsers();

            bool userValidated = false;
            foreach (var user in users)
            {
                string hash = HelperMethods.GetUserHash(user);
                if (hash == i_token)
                {
                    userValidated = true;
                    break;
                }
            }
            return userValidated;
        }

        public static async Task<bool> CheckIfIsAdmin(IUsuarioRepository i_usuarioRepository, string i_token) 
        {
            var users = await i_usuarioRepository.GetAllUsers();

            foreach (var user in users)
            {
                string hash = HelperMethods.GetUserHash(user);
                if (hash == i_token)
                {
                    return user.Administrador == 1;
                }
            }

            return false;
        }

        public static async Task<int> GetUserIdFromToken(IUsuarioRepository i_usuarioRepository, string i_token) 
        {
            var users = await i_usuarioRepository.GetAllUsers();

            foreach (var user in users)
            {
                string hash = HelperMethods.GetUserHash(user);
                if (hash == i_token)
                {
                    return user.Id;
                }
            }

            return -1;
        }

        private static String sha256_hash(string value)
        {
            StringBuilder Sb = new StringBuilder();

            using (var hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
