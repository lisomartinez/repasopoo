using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RepasoPoo
{
    public abstract class Alumno : IEquatable<Alumno>, IComparable<Alumno>, ICloneable
    {

        public string Nombre { get; set; }
        public int Legajo { get; set; }
        public abstract string Nacionalidad { get; }
        public static readonly string PrefijoTelefono = "011";
        public List<Telefono> Telefonos { get; }

        public static event EventHandler<PrefijoCABAEventArgs> PrefijoCABAHandler; 

        public Alumno(string nombre, int legajo)
        {
            Nombre = nombre;
            Legajo = legajo;
            Telefonos = new List<Telefono>();
        }

        public Alumno(string nombre, int legajo, List<Telefono> telefonos)
        {
            Nombre = nombre;
            Legajo = legajo;
            Telefonos = telefonos;
        }

        public void AgregarTelefono(Telefono telefono)
        {
            if (Telefonos.Contains(telefono)) throw new TelefonoYaExisteException(telefono.PrefijoNumero);

            //            if (Telefonos.Exists(t => t.CompareTo(telefono) == 0)) throw new TelefonoYaExisteException(telefono.PrefijoNumero);

            if (telefono.Prefijo.Equals(PrefijoTelefono))
            {
                PrefijoCABAHandler?.Invoke(this, new PrefijoCABAEventArgs(this, telefono.PrefijoNumero));
            }

            Telefonos.Add(telefono);
        }

        public void RemoverTelefono(Telefono telefono)
        {

        }

        public bool Equals(Alumno other)
        {
            return !(other is null) && this.Legajo.Equals(other.Legajo);
        }

        public int CompareTo(Alumno other)
        {
            //si this es mayor que other, return 1;
            //si this es igual a other, return 0;
            //si this es menor que other, return -1;
            return this.Legajo - other.Legajo;
        }

        public override string ToString()
        {
            return $"{nameof(Legajo)}: {Legajo}, {nameof(Nombre)}: {Nombre}, {nameof(Nacionalidad)}: {Nacionalidad}";
        }


        public abstract object Clone();
    }
}
