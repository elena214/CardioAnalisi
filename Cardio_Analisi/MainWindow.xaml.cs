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
using CardioLibrary;
using System.IO;

namespace Cardio_Analisi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> tipoAllenamento = new List<string>();
        private List<string> generi = new List<string>();
        private List<string> informazioni = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            LetturaFile();
        }

        private void btnCarica_Click(object sender, RoutedEventArgs e)
        {
            if (rdbRiposo.IsChecked == true)
            {
                if (!string.IsNullOrWhiteSpace(txtBattiti.Text) && !string.IsNullOrWhiteSpace(txtEtà.Text))
                {
                    try
                    {
                        int battiti = Convert.ToInt32(txtBattiti.Text);
                        int età = Convert.ToInt32(txtEtà.Text);

                        if (battiti <= 0 || età <= 0 || età > 130)
                        {
                            MessageBox.Show("I valori inseriti non sono validi", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                        else
                        {
                            string frequeRiposo = DataCardio.FrequenzaCardiacaARiposo(battiti);
                            string frequeMaxMin = DataCardio.FrequenzaCardiacaMaxMin(età);
                            lboStampa.Items.Add(frequeRiposo);
                            lboStampa.Items.Add(frequeMaxMin);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Il formato dell'età e/o dei battiti è errato", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }

                    txtEtà.Clear();
                    txtBattiti.Clear();
                    txtPeso.Clear();
                    txtTempo.Clear();
                    txtKm.Clear();
                    cboTipoAllenamento.SelectedIndex = -1;
                    cboGenere.SelectedIndex = -1;

                }
                else
                {
                    MessageBox.Show("Devi inserire i valori dell'età e/o dei battiti cardiaci", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else if (rdbSottosforzo.IsChecked == true)
            {
                if (!string.IsNullOrWhiteSpace(txtBattiti.Text) && !string.IsNullOrWhiteSpace(txtEtà.Text) && !string.IsNullOrWhiteSpace(txtKm.Text) && !string.IsNullOrWhiteSpace(txtPeso.Text) && !string.IsNullOrWhiteSpace(txtTempo.Text) && cboGenere.SelectedItem != null && cboTipoAllenamento.SelectedItem != null)
                {
                    try
                    {
                        int battiti = Convert.ToInt32(txtBattiti.Text);
                        int età = Convert.ToInt32(txtEtà.Text);
                        double km = Convert.ToDouble(txtKm.Text);
                        double peso = Convert.ToDouble(txtPeso.Text);
                        double tempo = Convert.ToDouble(txtTempo.Text);

                        if (battiti <= 0 || età <= 0 || km <= 0 || peso <= 0 || tempo <= 0 || età > 120)
                        {
                            MessageBox.Show("I valori inseriti non sono validi", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                        else
                        {
                            string frequeMaxMin = DataCardio.FrequenzaCardiacaMaxMin(età);
                            lboStampa.Items.Add(frequeMaxMin);

                            string allenamentoEfficace = DataCardio.FrequenzaCardiacaPalestra(età, battiti);
                            lboStampa.Items.Add(allenamentoEfficace);
                            string tipologia = cboTipoAllenamento.SelectedItem.ToString();
                            string categoria = cboGenere.SelectedItem.ToString();

                            if (tipologia == "corsa" || tipologia == "camminata")
                            {
                                string tipoAllenamento = DataCardio.SpesaEnergetica(tipologia, peso, km);
                                lboStampa.Items.Add(tipoAllenamento);
                            }
                            else if (tipologia == "altro")
                            {
                                string calorieBruciate = DataCardio.CalorieBruciate(peso, età, tempo, categoria);
                                lboStampa.Items.Add(calorieBruciate);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Formato della stringa di input non corretto", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }

                    txtEtà.Clear();
                    txtBattiti.Clear();
                    txtPeso.Clear();
                    txtTempo.Clear();
                    txtKm.Clear();
                    cboTipoAllenamento.SelectedIndex = -1;
                    cboGenere.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Devi inserire tutti i valori richiesti", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Devi selezionare almeno una tipologia di frequenza cardiaca", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void rdbRiposo_Checked(object sender, RoutedEventArgs e)
        {
            txtPeso.IsEnabled = false;
            txtKm.IsEnabled = false;
            txtTempo.IsEnabled = false;
        }

        private void rdbSottosforzo_Checked(object sender, RoutedEventArgs e)
        {
            txtPeso.IsEnabled = true;
            txtKm.IsEnabled = true;
            txtTempo.IsEnabled = true;
        }

        private void btnElimina_Click(object sender, RoutedEventArgs e)
        {
            if (lboStampa.SelectedItem != null)
            {
                lboStampa.Items.Remove(lboStampa.SelectedItem);
            }
            else
            {
                MessageBox.Show("Non hai selezionato nessun elemento da eliminare", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void cboTipoAllenamento_Loaded(object sender, RoutedEventArgs e)
        {
            tipoAllenamento.Add("corsa");
            tipoAllenamento.Add("camminata");
            tipoAllenamento.Add("altro");

            foreach (var item in tipoAllenamento)
            {
                cboTipoAllenamento.Items.Add(item);
            }
        }

        private void cboGenere_Loaded(object sender, RoutedEventArgs e)
        {
            generi.Add("maschio");
            generi.Add("femmina");

            foreach (var item in generi)
            {
                cboGenere.Items.Add(item);
            }
        }

        public void LetturaFile()
        {
            StreamReader streamLettura = new StreamReader(Costanti.DIRECTORY + Costanti.FILE);
            string line;

            do
            {
                line = streamLettura.ReadLine();
                if (line != null)
                {
                    informazioni.Add(line);
                }

            } while (line != null);

            streamLettura.Close();
        }

        private void btnClicca_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in informazioni)
            {
                lboInformazioni.Items.Add(item);
            }
        }
    }
}
