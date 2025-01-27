namespace Movies.Common.Notification;

public static class Messages
{
    public static class User
    {
        public static readonly string EmailExists = "Esse email já está em uso!";
        public static readonly string UsernameExists = "Esse nome de usuário já está em uso!";
        public static readonly string PasswordAreDifferents = "As senhas são diferentes!";
        public static readonly string ErrorInCreate = "Erro ao criar usuário!";
    }
}
