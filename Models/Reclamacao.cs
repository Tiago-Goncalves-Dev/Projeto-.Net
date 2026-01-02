using System.ComponentModel.DataAnnotations;




namespace GestorReclamacao
{
    public class Reclamacao
    {

        //Referente ao user
        public int ReclamacaoID { get; set; } // Auto incrementar na BD

        [Required]
        [StringLength(100)]
        public string Assunto { get; set; }

        [Required]
        [StringLength(25)]
        public string NomeConsumidor { get; set; } // Nome do utilizador a fazer a Reclamação, podemos ajustar para ser Automático
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataEntrada { get; set; } = DateTime.Now; // Data da reclamação, DateTime.Now para ser automatico

        [Required]
        [StringLength(2000)]
        public string TextoReclamacao { get; set; } // Reclamação em si

        public string Estado { get; set; } = "Aberta"; // "Aberta", "Respondida", "Fechada"

        // Anexo do User
        public string? CaminhoFicheiro { get; set; } // Localização do Ficheiro ** A DEFINIR ** 
        public string? NomeOriginalFicheiro { get; set; } // Utiliza o nome original do ficheiro ( para evitar os nomes estranhos "fbeibwifhwbvwhfbwfjabc123_The.pdf")


        // Referente ao Admin
        public DateTime? DataEncerramento { get; set; } //Usar reclamacao.DataEncerramento = DateTime.Now; para Automatizar a data de fecho
        public string? RespostaAdmin { get; set; } // preenchido pelo admin

        // Anexo do admin (resposta)
        public string? CaminhoFicheiroAdmin { get; set; }
        public string? NomeOriginalFicheiroAdmin { get; set; }

    }
}