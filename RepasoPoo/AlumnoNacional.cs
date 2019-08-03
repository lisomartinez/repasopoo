using System.Collections.Generic;

namespace RepasoPoo
{
    public class AlumnoNacional : Alumno
    {
        public AlumnoNacional(string nombre, int legajo) : base(nombre, legajo)
        {
        }

        public AlumnoNacional(string nombre, int legajo, List<Telefono> telefonos) : base(nombre, legajo, telefonos)
        {
        }

        public override string Nacionalidad => "Argentino";
        public override object Clone()
        {
            List<Telefono> tels = new List<Telefono>();
            foreach (var telefono in this.Telefonos)
            {
                tels.Add(telefono);
            }

            return new AlumnoNacional(this.Nombre, this.Legajo, tels);
        }
    }
}