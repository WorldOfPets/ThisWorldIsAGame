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

namespace ThisWorldIsAGame.PageF
{
    /// <summary>
    /// Логика взаимодействия для WinAdd.xaml
    /// </summary>
    public partial class WinAdd : Window
    {
        public string param { get; set; }

        public int IdU { get; set; }
        public WinAdd(string parametr, int IDUserG)
        {
            InitializeComponent();

            param = parametr;
            IdU = IDUserG;
            this.Title = param;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
            TbExp.Text = $"{e.NewValue} Exp";
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TbNameAction.Text != "")
            { 
                DataBaseF.Action action = new DataBaseF.Action()
                {
                    Name = TbNameAction.Text,
                    ActionExp = Convert.ToInt32(TbExp.Text.Replace(" Exp", ""))
                };
                ClassF.DBClass.GameEntities.Action.Add(action);
                ClassF.DBClass.GameEntities.SaveChanges();

                DataBaseF.UserAction userAction = new DataBaseF.UserAction()
                {
                    IdAction = action.Id,
                    IdUser = IdU,
                    Parameter = param
                };
                ClassF.DBClass.GameEntities.UserAction.Add(userAction);
                ClassF.DBClass.GameEntities.SaveChanges();

                MessageBox.Show("Действие успешно добавлено!");
            }
            else{ MessageBox.Show("Пустые поля!"); }
        }

        private void TbNameAction_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TbNameAction.Text == "Придумайте задание")
            {
                TbNameAction.Text = "";
                var bc = new BrushConverter();
                TbNameAction.Foreground = (Brush)bc.ConvertFrom("#4285F4");
            }
        }
    }
}
