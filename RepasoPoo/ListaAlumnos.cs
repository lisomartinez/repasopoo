using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


//https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerator?view=netframework-4.8
namespace RepasoPoo
{
    public class ListaAlumnos : IEnumerable
    {
        private readonly Alumno[] alumnos;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
           return new Enumerador(alumnos);
        }
        public ListaAlumnos(List<Alumno> alumnosLista)
        {
            alumnos = alumnosLista.ToArray();
        }

        public class Enumerador : IEnumerator
        {
            private Alumno[] alumnos;
            private int index = -1;

            public Enumerador(Alumno[] alumnos)
            {
                this.alumnos = alumnos;
            }

            bool IEnumerator.MoveNext()
            {
                index++;
                return index < alumnos.Length;
            }

            public void Reset()
            {
                index = -1;
            }

            public object Current
            {
                get
                {
                    try
                    {
                        return alumnos[index];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }


    }
}