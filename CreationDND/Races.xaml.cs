using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CreationDND
{
    /// <summary>
    /// Lógica interna para Races.xaml
    /// </summary>
    public partial class Races : Window
    {
        public enum enumRaces
        {
            Haut_elfe,
            elfe_sylvestre
        }

        public Races()
        {
            InitializeComponent();
            foreach (enumRaces valeurs in Enum.GetValues(typeof(enumRaces)))
            {
                ComboBox1.Items.Add(valeurs);
            }

            //ComboBox1.ItemsSource = Enum.GetValues(typeof(enumRaces)).Cast<enumRaces>();
        }

        public void comboBox_ChangerImage(object sender, SelectionChangedEventArgs e)
        {
            
            ComboBox cmb = sender as ComboBox;
            ComboBoxItem iter = cmb.SelectedItem as ComboBoxItem;
            if (iter != null)
            {
                string chaine = ((ComboBoxItem)cmb.SelectedItem).Content.ToString();
                enumRaces selectedValues = Enum.Parse<enumRaces>(chaine);

                switch (selectedValues)
                {
                    case enumRaces.Haut_elfe:
                        img.Source = new BitmapImage(new Uri("/Images/highelf.png", UriKind.Relative));
                        break;

                    case enumRaces.elfe_sylvestre:
                        img.Source = new BitmapImage(new Uri("/Images/WOOD-ELF-2.png", UriKind.Relative));
                        break;

                    default:
                        throw new Exception("Pas d'image");
                }

            }
        }


    }

}
