using System;
using System.ComponentModel.DataAnnotations;

namespace HvisaoApp.Models
{
    public class Lentes
    {
        [Key]
        public int SolicitacaoId { get; set; }
        [Required(ErrorMessage = "Informe o registro (ID) do(a) paciente.")]
        public int Registro { get; set; }
        [Required(ErrorMessage = "Informe o nome do(a) paciente.")]
        public string Paciente { get; set; }
        [Required(ErrorMessage = "Informe a descrição da solicitação.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Informe a data de aquisição.")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime? DataPedido { get; set; }
        public bool Entregue { get; set; }
    }
}