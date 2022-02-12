using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace BootstrapModalTest.Models
{
    public enum AtivoInativo
    {
        Ativo = 0,
        Inativo = 1
    }

    public enum Sexo
    {
        [Display(Name = "Masculino")]
        M,
        [Display(Name = "Feminino")]
        F
    }

    public enum Tratamento
    {
        [Display(Name = "Senhor")]
        Sr,
        [Display(Name = "Senhora")]
        Sra,
        [Display(Name = "Doutor")]
        Doutor,
        [Display(Name = "Doutora")]
        Doutora
    }

    [Table("Tsocio")]
    public class Socio
    {
        [Key]
        [ScaffoldColumn(false)]
        [Column("SocioId", Order = 0, TypeName = "int")]
        public int SocioID { get; set; }

        [Required(ErrorMessage = "Nome é obrigatorio")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Nome deve ter entre 5 e 70 caracteres")]
        [Display(Name = "Nome", Description = "Nome")]
        [Column("Nome", Order = 1, TypeName = "varchar")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Sobre Nome é obrigatorio")]
        [StringLength(70, MinimumLength = 5, ErrorMessage = "Sobre Nome deve ter entre 5 e 70 caracteres")]
        [Display(Name = "Sobre Nome", Description = "Sobre Nome")]
        [Column("SobreNome", Order = 2, TypeName = "varchar")]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "Nr do Sócio é obrigatorio")]
        [StringLength(15, MinimumLength = 5)]
        [Column("NrSocio", Order = 3, TypeName = "varchar")]
        public string NrSocio { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Data inclusão é obrigatorio")]
        [Column("DataInclusao", Order = 4, TypeName = "smalldatetime")]
        public DateTime DataInclusao { get; set; }

        [Column("DataPrimHosp", Order = 5, TypeName = "smalldatetime")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Remote("ckEntreDatas", "Socios", AdditionalFields = "DataInclusao", ErrorMessage = "Data 1* Hospedagem deve ser maior que Data Inclusão")]
        [Required(ErrorMessage = "Data 1* Hospedagem é obrigatorio")]
        public DateTime DataPrimHosp { get; set; }

        [ScaffoldColumn(false)]
        [Column("AtivoInativo", Order = 6, TypeName = "int")]
        public AtivoInativo AtivoInativo { get; set; }

        [Column("Apelido", Order = 8, TypeName = "varchar")]
        [Required(ErrorMessage = "Informe o apelido")]
        [Remote("ckApelido", "Socios", ErrorMessage = "apelido ja esta em uso")]
        public string Apelido { get; set; }

        public Sexo Sexo { get; set; }

        public Tratamento Tratamento { get; set; }
    }
}