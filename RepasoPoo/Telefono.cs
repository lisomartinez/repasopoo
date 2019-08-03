using System;
using System.Collections.Generic;

namespace RepasoPoo
{
    public sealed class Telefono : IEquatable<Telefono>, IComparable<Telefono>, ICloneable
    {

        public string Prefijo { get; }
        public string Numero { get; }

        public string PrefijoNumero => Prefijo + Numero;

        public Telefono(string prefijo, string numero)
        {
            Prefijo = prefijo;
            Numero = numero;
        }

        public bool Equals(Telefono other)
        {
            if (other is null) return false;
            return this.Prefijo.Equals(other.Prefijo) && this.Numero.Equals(other.Numero);
        }

        public int CompareTo(Telefono other)
        {
            return String.Compare(this.PrefijoNumero, other.PrefijoNumero, StringComparison.Ordinal);
        }

        public object Clone()
        {
            return (Telefono) this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"{nameof(PrefijoNumero)}: {PrefijoNumero}";
        }
    }
}