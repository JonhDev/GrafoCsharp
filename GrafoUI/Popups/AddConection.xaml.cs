using Grafo;
using Petzold.Media2D;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

                if (from == null && to == null)
                {
                    MessageBox.Show("Debes de seleccionar los vertices con los que se hara la conexión", "Ooops");
                    return;
                }

                if (from != null && to == null)
                {
                    MessageBox.Show("Falta seleccionar un vertice", "Ooops");
                    return;
                }

                if (to != null && from == null)
                {
                    MessageBox.Show("Falta seleccionar un vertice", "Ooops");
                    return;
                }

                if (value.Text == string.Empty)
                {
                    MessageBox.Show("Debes de dar una ponderación a la conexión", "Ooops");
                    return;
                }

                double X1 = Canvas.GetLeft(from)+50;
                double X2 = Canvas.GetLeft(to)+50;
                double Y1 = Canvas.GetTop(from)+50;
                double Y2 = Canvas.GetTop(to)+50;

                if (from == to)
                {
                    Assembly asm = Assembly.GetExecutingAssembly();
                    var a = asm.GetManifestResourceNames();
                    Stream iconStream = asm.GetManifestResourceStream("GrafoUI.Images.reload.png");
                    PngBitmapDecoder iconDecoder = new PngBitmapDecoder(iconStream,
                        BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
                    ImageSource iconSource = iconDecoder.Frames[0];
                    Image ima = new Image();
                    ima.Height = 50;
                    ima.Width = 50;
                    ima.Source = iconSource;
                    Canvas.SetLeft(ima, X1 + 31);
                    Canvas.SetTop(ima, Y1 - 50);
                    canvas.Children.Add(ima);
                    Label ponderacion = new Label();
                    ponderacion.Content = value.Text;
                    ponderacion.Height = 50;
                    ponderacion.Width = 80;
                    ponderacion.Foreground = Brushes.Black;
                    Canvas.SetLeft(ponderacion, X1 + 45);
                    Canvas.SetTop(ponderacion, Y1 - 40);
                    canvas.Children.Add(ponderacion);
                }
                else
                {
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

                    Label ponderacion = new Label();
                    ponderacion.Content = value.Text;
                    ponderacion.Height = 50;
                    ponderacion.Width = 80;
                    ponderacion.Foreground = Brushes.Black;
                    var newX = (X1 + X2) / 2;
                    var newY = (Y1 + Y2) / 2;
                    Canvas.SetLeft(ponderacion, newX);
                    Canvas.SetTop(ponderacion, newY);
                    canvas.Children.Add(ponderacion);

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
                }

                
                this.Close();
            };
        }
    }
}
