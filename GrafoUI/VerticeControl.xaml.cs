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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GrafoUI
{
    /// <summary>
    /// Interaction logic for VerticeControl.xaml
    /// </summary>
    public partial class VerticeControl : UserControl
    {
        public double HeightVertice
        {
            get { return (double)GetValue(HeightVerticeProperty);}
            set { SetValue(HeightVerticeProperty, value);}
        }

        public double WidthVertice
        {
            get { return (double)GetValue(WidthVerticeProperty); }
            set { SetValue(WidthVerticeProperty, value); }
        }

        public string TextVertice
        {
            get { return (string)GetValue(TextVerticeProperty); }
            set { SetValue(TextVerticeProperty, value); }
        }

        public Brush VerticeFill
        {
            get { return (Brush)GetValue(VerticeFillProperty); }
            set { SetValue(VerticeFillProperty, value); }
        }

        public string VerticeName { get; set; }

        #region DependencyProperties

        public static readonly DependencyProperty HeightVerticeProperty =
        DependencyProperty.Register("HeightVerticeProp", typeof(double), typeof(VerticeControl), new PropertyMetadata((double)100));

        public static readonly DependencyProperty WidthVerticeProperty =
        DependencyProperty.Register("WidthVerticeProp", typeof(double), typeof(VerticeControl), new PropertyMetadata((double)100));

        public static readonly DependencyProperty TextVerticeProperty =
            DependencyProperty.Register("TextVerticeProp", typeof(string), typeof(VerticeControl), new PropertyMetadata("Vertice"));

        public static readonly DependencyProperty VerticeFillProperty =
            DependencyProperty.Register("VerticeFill", typeof(Brush), typeof(VerticeControl), new PropertyMetadata(Brushes.DarkBlue));

        #endregion

        public Dictionary<string, string> Data { get; set; }

        public VerticeControl()
        {
            InitializeComponent();
            Data = new Dictionary<string, string>();
        }

        public override string ToString()
        {
            return VerticeName;
        }
    }
}
