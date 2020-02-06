using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage ="Tamanho do {0} deve ter no minimo de 03 a 60 caracteres" )]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [EmailAddress(ErrorMessage = "Informe um {0} valido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Aniversario { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Range(1039.0, 10000000, ErrorMessage = "{0} nao pode ser inferior a um Salario minimo.  Salario Minimo = 1039.00 ")]
        [Display(Name ="Salario Base")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double SalarioBase { get; set; }

        
        public Departamento Departamento { get; set; }

        
        public int DepartamentoId { get; set; }
        public ICollection<RegistroVendas> Vendas { get; set; } = new List<RegistroVendas>();

       public Vendedor()
        {

        }

        public Vendedor(int id, string nome, string email, DateTime aniversario, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Aniversario = aniversario;
            SalarioBase = salarioBase;
            Departamento = departamento;

        }

        public void AdicionarVendas(RegistroVendas rv)
        {
            Vendas.Add(rv);

        }

        public void RemoverVenda(RegistroVendas rv)
        {
            Vendas.Remove(rv);

        }

        public double TotalVendas(DateTime inicio, DateTime final)
        {
            return Vendas.Where(rv => rv.Data >= inicio && rv.Data <= final).Sum(rv=>rv.Valor);

        }

    }
}
