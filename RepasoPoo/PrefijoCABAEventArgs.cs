using System;

namespace RepasoPoo
{
    public class PrefijoCABAEventArgs : EventArgs
    {
        public Alumno Alumno { get; }
        public string Telefono { get; }

        public PrefijoCABAEventArgs(Alumno alumno, string telefono)
        {
            Alumno = alumno ?? throw new ArgumentNullException(nameof(alumno));
            Telefono = telefono ?? throw new ArgumentNullException(nameof(telefono));
        }
    }
}