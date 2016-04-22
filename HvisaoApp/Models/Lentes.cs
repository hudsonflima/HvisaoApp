using System;
using System.ComponentModel.DataAnnotations;

namespace HvisaoApp.Models
{
    public class Lentes
    {
        [Key]
        public int SolicitacaoId { get; set; }
        [Display(Name = "Registro do Paciente")]
        [Required(ErrorMessage = "Informe o registro (ID) do(a) paciente.")]
        public int Registro { get; set; }
        [Display(Name = "Nome do Paciente")]
        [Required(ErrorMessage = "Informe o nome do(a) paciente.")]
        public string Paciente { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Informe a descrição da solicitação.")]
        public string Descricao { get; set; }
        [Display(Name = "Data do Pedido")]
        [Required(ErrorMessage = "Informe a data de aquisição.")]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DataPedido { get; set; }
        [Display(Name = "Entregue?")]
        public bool Entregue { get; set; }
    }
}