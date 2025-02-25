﻿namespace Domain.Helpers
{
    public static class PasswordHelper
    {
        // Gera um hash seguro para a senha
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        // Verifica se a senha informada corresponde ao hash salvo no banco
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
