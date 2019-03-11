using System.ComponentModel.DataAnnotations;

namespace MyLoyalty.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome da Conta")]
        public string Nome { get; set; }

        [Display(Name = "Login do usuário")]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Conta Administrador")]
        public string adm { get; set; }

        public Usuario() { }

        public Usuario(int id, string nome, string login, string password, string _isAdm)
       {
            this.Id = id;
            this.Nome = nome;
            this.Login = login;
            this.Password = password;
            this.adm = _isAdm;
       }
    }
}
