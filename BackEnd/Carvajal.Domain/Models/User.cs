using Carvajal.Domain.Interfaces;
using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Carvajal.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int TypeIdentificationId { get; set; }
        public string Identification { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual TypeIdentification TypeIdentification { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentException("Requerido", "Nombre");
            }

            if (string.IsNullOrEmpty(LastName))
            {
                throw new ArgumentException("Requerido", "Apellido");
            }

            if (TypeIdentificationId == 0)
            {
                throw new ArgumentException("Requerido", "Tipo Identificacion");
            }

            if (string.IsNullOrEmpty(Identification))
            {
                throw new ArgumentException("Requerido", "Identificacion");
            }

            if (string.IsNullOrEmpty(Email))
            {
                throw new ArgumentException("Requerido", "Correo Electronico");
            }

            if (string.IsNullOrEmpty(Password))
            {
                throw new ArgumentException("Requerido", "Contraseña");
            }

            if (Password.Length < 8 || Password.Length > 20)
            {
                throw new ArgumentException("Debe tener entre 8 y 20 caracteres", "Contraseña");
            }



            if (!Regex.IsMatch(Email, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                      @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                      @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
            {
                throw new ArgumentException("Invalido", "Correo Electronico");
            }


        }
    }

}
