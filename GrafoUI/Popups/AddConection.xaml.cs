using Grafo;
using Petzold.Media2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GrafoUI.Popups
{
    /// <summary>
    /// Interaction logic for AddConection.xaml
    /// </summary>
    public partial class AddConection : Window
    {
        public AddConection(List<VerticeControl> vertices, Canvas canvas, GrafoObject<VerticeControl, ArrowLine> grafo)
        {
            InitializeComponent();

            lstTo.ItemsSource = vertices;
            lstFrom.ItemsSource = vertices;

            addConec.Click += (sender, args) =>
            {
                var from = lstFrom.SelectedItem as VerticeControl;
                var to = lstTo.SelectedItem as VerticeControl;

                double X1 = Canvas.GetLeft(from)+50;
                double X2 = Canvas.GetLeft(to)+50;
                double Y1 = Canvas.GetTop(from)+50;
                double Y2 = Canvas.GetTop(to)+50;

                ArrowLine arrow = new ArrowLine()
                {
                    X1 = X1,
                    X2 = X2,
                    Y1 = Y1,
                    Y2 = Y2,
                    Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6F000000")),
                    Stroke = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6F000000")),
                    StrokeThickness = 3,

                };

                var v1 = grafo.VerticesLis.Where(vertice => vertice.ToString() == from.ToString()).FirstOrDefault();
                var v2 = grafo.VerticesLis.Where(vertice => vertice.ToString() == to.ToString()).FirstOrDefault();
                grafo.AgregarConexion(v1, v2, arrow);

                grafo.ConexionRepetidaEventHandler += (s, a) =>
                {
                    MessageBoxResult res = MessageBox.Show("Al parecer la conexion ya existe, no puedes agregar la conexion", "Houston, tenemos un problema", MessageBoxButton.YesNo);
                    if (res == MessageBoxResult.Yes)
                    {
                        Arista<ArrowLine, VerticeControl> arista = s as Arista<ArrowLine, VerticeControl>;
                        arista.Objeto = a.Peso as ArrowLine;
                        MessageBox.Show("La conexion ha sido cambiada", "¡Éxito!");
                    }
                };

                canvas.Children.Add(arrow);
            };
        }
    }
}
