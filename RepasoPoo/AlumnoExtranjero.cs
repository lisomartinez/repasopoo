using System.Collections.Generic;

namespace RepasoPoo
{
    public class AlumnoExtranjero : Alumno
    {
        private string _nacionalidad;
        public override string Nacionalidad => _nacionalidad;

        public AlumnoExtranjero(string nombre, int legajo, string nacionalidad) : base(nombre, legajo)
        {
            _nacionalidad = nacionalidad;
        }

        private AlumnoExtranjero(string nombre, int legajo, string nacionalidad, List<Telefono> tels) : base(nombre, legajo, tels) {
            _nacionalidad = nacionalidad;
        }

        public override object Clone()
        {
            List<Telefono> tels = new List<Telefono>();
            foreach (var telefono in this.Telefonos)
            {
                tels.Add(telefono);
            }

            return new AlumnoExtranjero(this.Nombre, this.Legajo, this.Nacionalidad, tels);
        }
    }
}