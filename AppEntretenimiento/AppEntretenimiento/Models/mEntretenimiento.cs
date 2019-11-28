using System.Collections.Generic;

namespace AppEntretenimiento.Models
{
    public class ActorPrincipal
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
    }

    public class Caracteristica
    {
        public string IdCaracteristica { get; set; }
        public string Nombre { get; set; }
        public string Ano { get; set; }
        public List<ActorPrincipal> ActorPrincipal { get; set; }
    }

    public class mEntretenimiento
    {
        public string Id { get; set; }
        public string Tipo { get; set; }
        public string Genero { get; set; }
        public List<Caracteristica> Caracteristica { get; set; }
    }

}
