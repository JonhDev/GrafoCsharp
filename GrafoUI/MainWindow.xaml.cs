using Grafo;
using GrafoUI.Models;
using GrafoUI.Popups;
using Petzold.Media2D;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace GrafoUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<VerticeControl> vertices;
        GrafoObject<VerticeControl, ArrowLine> grafo;
        int contVertice = 1;

        public MainWindow()
        {
            InitializeComponent();
            vertices = new List<VerticeControl>();
            grafo = new GrafoObject<VerticeControl, ArrowLine>();

            addVertice.Click += (sender, args) =>
            {
                vertices.Add(new VerticeControl()
                {
                    HeightVertice = 100,
                    WidthVertice = 100,
                    TextVertice = $"Vertice {contVertice}",
                    VerticeName = $"Vertice {contVertice}"
                });

                vertices[vertices.Count - 1].MouseDoubleClick += MainWindow_MouseDoubleClick;
                vertices[vertices.Count - 1].MouseDown += MainWindow_MouseDown;
                vertices[vertices.Count - 1].MouseMove += MainWindow_MouseMove;

                grafo.VerticesLis.Add(new Vertice<VerticeControl, ArrowLine>(vertices[vertices.Count - 1]));

                canvas.Children.Add(vertices[vertices.Count - 1]);
                Canvas.SetLeft(vertices[vertices.Count - 1], 10);
                Canvas.SetTop(vertices[vertices.Count - 1], 10);
                contVertice++;
                new EditVertice(vertices[vertices.Count - 1]) { Owner = this }.ShowDialog();
            };

            addArista.Click += (sender, args) =>
            {
                new AddConection(vertices, canvas, grafo).ShowDialog();
            };
        }

        #region MouseMovenment
        Point p;
        private void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            VerticeControl ellipse = sender as VerticeControl;
            p = e.GetPosition(ellipse);
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            VerticeControl v = sender as VerticeControl;
            if(e.LeftButton == MouseButtonState.Pressed)
            {

                double pVT = Canvas.GetTop(v);
                double pCY = Mouse.GetPosition(v).Y;
                double top = pVT + pCY - p.Y;
                Canvas.SetTop(v, top);

                double pVL = Canvas.GetLeft(v);
                double pCX = Mouse.GetPosition(v).X;
                double left = pVL + pCX - p.X;

                Canvas.SetLeft(v, left);
            }
        }

        private void MainWindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            VerticeControl control = sender as VerticeControl;
            new EditVertice(control) { Owner = this }.ShowDialog();
        }
        #endregion
    }


}
