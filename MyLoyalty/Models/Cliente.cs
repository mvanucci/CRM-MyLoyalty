using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net;

namespace MyLoyalty.Models
{
    public class Cliente
    {
       
        public int id { get; set; }

        [Display(Name = "Nome do Cliente")]
        [Required(ErrorMessage = "Nome deve ser preenchido")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Nome deve ter entre 5 e 50 caracteres!")]
        public string nome { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Display(Name = "CPF do Cliente")]
        [Required(ErrorMessage = "CPF deve ser preenchido")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "CPF deve ter entre 10 e 50 caracteres!")]
        public string cpf { get; set; }

       
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime dataNascimento { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O telefone deve ser preenchido")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Telefone deve ter entre 8 e 15 caracteres!")]
        public string telefone { get; set; }

        [Display(Name = "Produto foi Encontrado ?")]
        [Required(ErrorMessage = "O produto deve ser preenchido")]
        
        public string pdtEncontrado { get; set; }
        [Display(Name = "A venda foi realizada ?")]
        public string vendaRealizada { get; set; }

        public Produto produto { get; set; }
        [Display(Name = "Produto")]
        public int produtoid { get; set; }

        public Cliente() { }

        public Cliente(int id, string nome, string email, string cpf, DateTime dataNascimento, string telefone, string pdtEncontrado,string venda ,Produto produto)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.cpf = cpf;
            this.dataNascimento = dataNascimento;
            this.telefone = telefone;
            this.pdtEncontrado = pdtEncontrado;
            this.vendaRealizada = venda;
            this.produto = produto;
        }

        public void sendPesquisa(int? id)
        {
            MailMessage mail = new MailMessage();

            mail.From = new MailAddress("mmyloyalty@gmail.com");
            mail.To.Add(this.email);
            mail.Subject = "Pesquisa de satisfação";
            mail.Body = "Acesse o link em anexo: e responda a nossa pesquisa de satisfação: https://localhost:44343/Pesquisas/Edit/"+ id;

            using (var smtp = new SmtpClient("smtp.gmail.com"))
            {
                smtp.EnableSsl = true; // GMail requer SSL
                smtp.Port = 587;       // porta para SSL
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // modo de envio
                smtp.UseDefaultCredentials = false; // vamos utilizar credencias especificas

                // seu usuário e senha para autenticação
                smtp.Credentials = new NetworkCredential("mmyloyalty@gmail.com", "myloyalty#@!");

                // envia o e-mail
                smtp.Send(mail);
            }   
        }
    }
}
