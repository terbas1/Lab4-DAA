using Business;
using Entity;
using System;
using System.Windows;
using System.Windows.Controls;


namespace _04
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            BPedido bPedido = null;
            try
            {
                bPedido = new BPedido();
                dgvPedido.ItemsSource = bPedido.GetPedidosEntreFechas(
                Convert.ToDateTime(textFechaInicio.Text),
                Convert.ToDateTime(textFechaFin.Text));
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void DgvPedido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                BDetallePedido detallePedido = new BDetallePedido();
                int idPedido;
                var item = (Pedido)dgvPedido.SelectedItem;
                if (item == null) return;
                idPedido = Convert.ToInt32(item.IdPedido);
                dgvDetallePedido.ItemsSource = detallePedido.GetPedidosEntreFechas(idPedido);
                textTotal.Text = Convert.ToString(detallePedido.GetDetalleTotalPorId(idPedido));

            }
            catch (Exception)
            {
                //throw;
            }
        }
    }
}
