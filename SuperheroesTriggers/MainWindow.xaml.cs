using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;


namespace SuperheroesTriggers
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Superheroe superheroe;
        private List<Superheroe> superheroes;
        public MainWindow()
        {
            InitializeComponent();
            superheroes = Superheroe.GetSamples();
            contenedorSuperheroe.DataContext = superheroes;
            actualTextBlock.Text = "1";
            totalTextBlock.Text = superheroes.Count.ToString();
            superheroe = new Superheroe();
            contenedorNuevoSuperheroe.DataContext = superheroe;
        }

        private void aceptarButton_Click(object sender, RoutedEventArgs e)
        {
            superheroe.Nombre = nombreTextBox.Text;
            superheroe.Imagen = rutaImagenTextBox.Text;
            if ((bool)villanoRadioButton.IsChecked)
            {
                superheroe.Vengador = false;
                superheroe.Xmen = false;
                superheroe.Heroe = false;
            }
            else
            {
                superheroe.Vengador = (bool)vengadoresCheckBox.IsChecked;
                superheroe.Xmen = (bool)xmenCheckBox.IsChecked;
                superheroe.Heroe = true;
                superheroe.Villano = false;
            }
            superheroes.Add(superheroe);
            MessageBox.Show("Superhéroe insertado con exito", "Superhéroes", MessageBoxButton.OK, MessageBoxImage.Information);
            totalTextBlock.Text = superheroes.Count.ToString();
            superheroe = new Superheroe();
            contenedorNuevoSuperheroe.DataContext = superheroe;
        }

        private void limpiarButton_Click(object sender, RoutedEventArgs e)
        {
            superheroe = new Superheroe();
            contenedorNuevoSuperheroe.DataContext = superheroe;
        }

        private void anteriorImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int actual = int.Parse(actualTextBlock.Text);
            if (actual > 1)
            {
                contenedorSuperheroe.DataContext = superheroes[actual - 2];
                actualTextBlock.Text = (actual - 1).ToString();
            }
        }

        private void siguiente_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int actual = int.Parse(actualTextBlock.Text);
            if (actual < superheroes.Count)
            {
                contenedorSuperheroe.DataContext = superheroes[actual];
                actualTextBlock.Text = (actual + 1).ToString();
            }
        }
    }
}
