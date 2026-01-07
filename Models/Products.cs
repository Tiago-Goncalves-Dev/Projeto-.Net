using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Net.Models;

public class Product
{
    [DisplayName("ID")]
    public int Id { get; set; }
    [DisplayName("Nome do Produto")]
    [Required]
    [StringLength(25)]
    public string? NomeDoProduto { get; set; }

    [Required]
    [DisplayName("Preço")]
    public double Preco { get; set; }

    [Required]
    [DisplayName("Caminho da IMG")]
    public string? ImagePath { get; set; }


    [NotMapped]
    public IFormFile? ImageFile { get; set; }



}
