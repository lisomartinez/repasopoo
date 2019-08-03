using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepasoPoo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Alumno.PrefijoCABAHandler += new EventHandler<PrefijoCABAEventArgs>(
                delegate(object o, PrefijoCABAEventArgs args)
                {
                    Console.WriteLine($@"Evento Delegado ANÓNIMO alumno = {args.Alumno}, teléfono = {args.Telefono}");
                });

            Alumno.PrefijoCABAHandler += EventoConNombre;
            InitializeComponent();
        }

        private void EventoConNombre(object o, PrefijoCABAEventArgs args)
        {
            Console.WriteLine($@"Evento Delegado Con NOMBRE alumno = {args.Alumno}, teléfono = {args.Telefono}");

        }

        private void Mostrar<T>(List<T> elementos)
        {
            elementos.ForEach(e => Console.WriteLine(e));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Alumno> alumnos = new List<Alumno>()
            {
                new AlumnoNacional("Mariano Montano", 10),
                new AlumnoExtranjero("Lisandro Martinez", 2, "Aleman"),
                new AlumnoNacional("Matias Molina", 5)
            };
            
            Mostrar(alumnos);
            alumnos.Sort();
            Mostrar(alumnos);

            alumnos.Sort((a1, a2) => a2.CompareTo(a1));
            Mostrar(alumnos);

            //no llamar
            Telefono caba = new Telefono("011", "48603242");

            alumnos[0].AgregarTelefono(caba);

            var alumnosLista = new ListaAlumnos(alumnos);
            Console.WriteLine("IEnumerator ForEach");
            foreach (var a in alumnosLista)
            {
                Console.WriteLine(a);
            }

            var enumerador = alumnosLista.GetEnumerator();
            Console.WriteLine(enumerador.GetType().ToString());

            Console.WriteLine("IEnumerator While");
            while (enumerador.MoveNext())
            {
                Console.WriteLine(enumerador.Current);                
            }

            Telefono nocaba = new Telefono("999999", "48603242");

            Alumno clon = (Alumno)alumnos[0].Clone();
            clon.AgregarTelefono(nocaba);

            //alumno original
            Console.WriteLine("Alumno Original");
            Mostrar(alumnos[0].Telefonos);

            //alumno clon
            Console.WriteLine("Alumno Clon");
            Mostrar(clon.Telefonos);
        }


    }
}
