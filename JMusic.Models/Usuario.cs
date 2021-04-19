using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace JMusic.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Orden = new HashSet<Orden>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Estatus { get; set; }
        public int PerfilId { get; set; }

        public virtual Perfil Perfil { get; set; }
        public virtual ICollection<Orden> Orden { get; set; }
    }
}
