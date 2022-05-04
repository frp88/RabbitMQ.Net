using System;
using System.ComponentModel.DataAnnotations;

namespace RabbitMQ.Net.Domain
{
    public class Cliente
    {
        [Key]
        public long? id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        [Display(Name = "e-mail")]
        public string email { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "data de nascimento")]
        public DateTime? dataDeNascimento { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "data de cadastro")]
        public DateTime dataDeCadastro { get; set; }

        public Cliente()
        {
            dataDeCadastro = DateTime.Now;
        }

        public Cliente(string nome) : this()
        {
            this.nome = nome;
        }
        public Cliente(string nome, string cpf) : this(nome)
        {
            this.cpf = cpf;
        }
        public Cliente(string nome, string cpf, string email) : this(nome, cpf)
        {
            this.email = email;
        }
        public Cliente(string nome, string cpf, string email, DateTime dataDeNascimento) : this(nome, cpf, email)
        {
            this.dataDeNascimento = dataDeNascimento;
        }
    }
}
