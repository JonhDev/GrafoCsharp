using System.Windows;
using System.Windows.Media;
using System.Linq;
using System.Collections.Generic;
using System;

namespace GrafoUI
{
    /// <summary>
    /// Interaction logic for EditVertice.xaml
    /// </summary>
    public partial class EditVertice : Window
    {
        private VerticeControl control;
        public EditVertice(VerticeControl control)
        {
            InitializeComponent();
            this.control = control;
            idVertice.Text = control.TextVertice;
            var lista = control.Data.ToList();
            if(lista.Count > 0)
            {
                try
                {
                    d1.Text = lista[0].Key;
                    d1v.Text = lista[0].Value;
                    d2.Text = lista[1].Key;
                    d2v.Text = lista[1].Value;
                    d3.Text = lista[2].Key;
                    d3v.Text = lista[2].Value;
                    d4.Text = lista[3].Key;
                    d4v.Text = lista[3].Value;
                    d5.Text = lista[4].Key;
                    d5v.Text = lista[4].Value;
                }
                catch (Exception e) { }
                
            }

        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            control.TextVertice = idVertice.Text;
            if(colorPicker.SelectedColor != null)
                control.VerticeFill = (SolidColorBrush)(new BrushConverter().ConvertFrom(colorPicker.SelectedColorText));
            control.Data = new Dictionary<string, string>();
            if (d1.Text != "")
                control.Data.Add(d1.Text, d1v.Text);
            if (d2.Text != "")
                control.Data.Add(d2.Text, d2v.Text);
            if (d3.Text != "")
                control.Data.Add(d3.Text, d3v.Text);
            if (d4.Text != "")
                control.Data.Add(d4.Text, d4v.Text);
            if (d5.Text != "")
                control.Data.Add(d5.Text, d5v.Text);
            this.Close();
        }
    }
}
