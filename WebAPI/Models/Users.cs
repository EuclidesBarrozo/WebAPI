using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class Users
    {
        public Users()
        {
        }

        public Users(string name, string cpf, string rg, DateTime birthday, string motherName, string fatherName, DateTime checkinDate)
        {
            this.uName          = name;
            this.uCPF           = cpf;
            this.uRG            = rg;
            this.uBirthday      = birthday;
            this.uMotherName    = motherName;
            this.uFatherName    = fatherName;
            this.uCheckinDate   = checkinDate;
        }
        //Display define the word use to display the attribute
        [Display(Name = "id")]
        public int userId { get; set; }

        [Display(Name = "Nome")]
        //Required informs that the data is required
        [Required(ErrorMessage = "Informe o nome do usuário.")]
        public string uName { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Informe o CPF do usuário.")]
        public string uCPF { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = "Informe o RG do usuário.")]
        public string uRG { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Informe o aniversário do usuário.")]
        public DateTime uBirthday { get; set; }

        [Display(Name = "Mãe")]
        [Required(ErrorMessage = "Informe o nome da mãe do usuário.")]
        public string uMotherName { get; set; }

        [Display(Name = "Pai")]
        [Required(ErrorMessage = "Informe o nome do pai do usuário.")]
        public string uFatherName { get; set; }

        [Display(Name = "Data de Inscrição")]
        public DateTime uCheckinDate { get; set; }
    }
}