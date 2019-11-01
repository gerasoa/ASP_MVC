using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RAS.CursoMvc.Application.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel()
        {
            Id = Guid.NewGuid();
            Enderecos = new List<EnderecoViewModel>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage ="Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage ="Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Preencha o campo E-mail")]
        [MaxLength(100, ErrorMessage ="Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage ="Preencha um email válido")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Preencha o campo CPF")]
        [MaxLength(11, ErrorMessage ="Máximo de {0} caracteres")]
        [Display(Name ="CPF")]
        public string CPF { get; set; }

        [Display(Name ="Data de Nascinento")]
        [DisplayFormat (ApplyFormatInEditMode = true, DataFormatString="{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage ="Data em formato inválido ")]
        public DateTime DataNascimento { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [ScaffoldColumn(false)]
        public bool Excluido { get; set; }

        //Endereço
        // virtual (lazyLoad / EagerLoading)
        public virtual ICollection<EnderecoViewModel> Enderecos { get; set; }


    }
}
