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

namespace ThisWorldIsAGame.PageF
{
    /// <summary>
    /// Логика взаимодействия для MainPageUser.xaml
    /// </summary>
    public partial class MainPageUser : Page
    {
        public MainPageUser()
        {
            InitializeComponent();
            try
            {
                var userLvl = ClassF.DBClass.GameEntities.UserG.FirstOrDefault(x => x.Id == 1);

                TbUserLogin.Text = userLvl.Login;
                

                StrengthDataGrid.ItemsSource = ClassF.DBClass.GameEntities.UserAction.Where(x => x.Parameter == "Strength" && x.IdUser == 1).ToList();//One
                TwoDataGrid.ItemsSource = ClassF.DBClass.GameEntities.UserAction.Where(x => x.Parameter == "Intellect" && x.IdUser == 1).ToList();//Two
                ThreeDataGrid.ItemsSource = ClassF.DBClass.GameEntities.UserAction.Where(x => x.Parameter == "Skill" && x.IdUser == 1).ToList();//Three
                FourDataGrid.ItemsSource = ClassF.DBClass.GameEntities.UserAction.Where(x => x.Parameter == "GoodHabits" && x.IdUser == 1).ToList();//Four
                FiveDataGrid.ItemsSource = ClassF.DBClass.GameEntities.UserAction.Where(x => x.Parameter == "BadHabits" && x.IdUser == 1).ToList();//Five


                var userparam = ClassF.DBClass.GameEntities.ParameterLevel.FirstOrDefault(x => userLvl.Parameter.Strength >= x.ParamExp && userLvl.Parameter.Strength < x.ParamExp * 2);//One
                var userparamTwo = ClassF.DBClass.GameEntities.ParameterLevel.FirstOrDefault(x => userLvl.Parameter.Intellect >= x.ParamExp && userLvl.Parameter.Intellect < x.ParamExp * 2);//Two
                var userparamThree = ClassF.DBClass.GameEntities.ParameterLevel.FirstOrDefault(x => userLvl.Parameter.Skill >= x.ParamExp && userLvl.Parameter.Skill < x.ParamExp * 2);//Three
                var userparamFour = ClassF.DBClass.GameEntities.ParameterLevel.FirstOrDefault(x => userLvl.Parameter.GoodHabits >= x.ParamExp && userLvl.Parameter.GoodHabits < x.ParamExp * 2);//Four
                var userparamFive = ClassF.DBClass.GameEntities.ParameterLevel.FirstOrDefault(x => userLvl.Parameter.BadHabits >= x.ParamExp && userLvl.Parameter.BadHabits < x.ParamExp * 2);//Five

                LevelStrengthTb.Text = userparam.lvl.ToString();//One
                TwoLevelStrengthTb.Text = userparamTwo.lvl.ToString();//Two
                ThreeLevelStrengthTb.Text = userparamThree.lvl.ToString();//Three
                FourLevelStrengthTb.Text = userparamThree.lvl.ToString();//Four
                FiveLevelStrengthTb.Text = userparamThree.lvl.ToString();//Five

                userLvl.Exp = userparam.lvl + userparamTwo.lvl + userparamThree.lvl + userparamFour.lvl - userparamFive.lvl + 1;
                ClassF.DBClass.GameEntities.SaveChanges();

                var userLevel = ClassF.DBClass.GameEntities.UserLevel.FirstOrDefault(x => userLvl.Exp >= x.UserLvlExp && userLvl.Exp < x.UserLvlExp * 2);
                PrBarUserLevel.Value = ((Convert.ToDouble(userLvl.Exp) - Convert.ToDouble(userLevel.UserLvlExp)) / Convert.ToDouble(userLevel.UserLvlExp)) * 100;
                TbUserLevel.Text = userLevel.lvl.ToString();
                TbStatus.Text = userLevel.Name;

                ProgressBarStrength.Value = ((Convert.ToDouble(userLvl.Parameter.Strength) - Convert.ToDouble(userparam.ParamExp))/Convert.ToDouble(userparam.ParamExp))*100;//One
                TwoProgressBarStrength.Value = ((Convert.ToDouble(userLvl.Parameter.Intellect) - Convert.ToDouble(userparamTwo.ParamExp)) / Convert.ToDouble(userparamTwo.ParamExp)) * 100;//Two
                ThreeProgressBarStrength.Value = ((Convert.ToDouble(userLvl.Parameter.Skill) - Convert.ToDouble(userparamThree.ParamExp)) / Convert.ToDouble(userparamThree.ParamExp)) * 100;//Three
                FourProgressBarStrength.Value = ((Convert.ToDouble(userLvl.Parameter.GoodHabits) - Convert.ToDouble(userparamFour.ParamExp)) / Convert.ToDouble(userparamFour.ParamExp)) * 100;//Four
                FiveProgressBarStrength.Value = ((Convert.ToDouble(userLvl.Parameter.BadHabits) - Convert.ToDouble(userparamFive.ParamExp)) / Convert.ToDouble(userparamFive.ParamExp)) * 100;//Five
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Plus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var cell = (Image)sender;
                var context = cell.DataContext as DataBaseF.UserAction;

                var userparam = ClassF.DBClass.GameEntities.ParameterLevel.FirstOrDefault(x => context.UserG.Parameter.Strength >= x.ParamExp && context.UserG.Parameter.Strength < x.ParamExp * 2);//One
                var userparamTwo = ClassF.DBClass.GameEntities.ParameterLevel.FirstOrDefault(x => context.UserG.Parameter.Intellect >= x.ParamExp && context.UserG.Parameter.Intellect < x.ParamExp * 2);//Two
                var userparamThree = ClassF.DBClass.GameEntities.ParameterLevel.FirstOrDefault(x => context.UserG.Parameter.Skill >= x.ParamExp && context.UserG.Parameter.Skill < x.ParamExp * 2);//Three
                var userparamFour = ClassF.DBClass.GameEntities.ParameterLevel.FirstOrDefault(x => context.UserG.Parameter.GoodHabits >= x.ParamExp && context.UserG.Parameter.GoodHabits < x.ParamExp * 2);//Four
                var userparamFive = ClassF.DBClass.GameEntities.ParameterLevel.FirstOrDefault(x => context.UserG.Parameter.BadHabits >= x.ParamExp && context.UserG.Parameter.BadHabits < x.ParamExp * 2);//Five

                if (context.Parameter == "Strength")
                {
                    //---------------------------------------
                    context.UserG.Parameter.Strength += context.Action.ActionExp;//One
                    ClassF.DBClass.GameEntities.SaveChanges();
                    LevelStrengthTb.Text = ClassF.DBClass.GameEntities.ParameterLevel.FirstOrDefault(x => context.UserG.Parameter.Strength >= x.ParamExp && context.UserG.Parameter.Strength < x.ParamExp * 2).lvl.ToString();//One
                    ProgressBarStrength.Value = ((Convert.ToDouble(context.UserG.Parameter.Strength) - Convert.ToDouble(userparam.ParamExp)) / Convert.ToDouble(userparam.ParamExp)) * 100;//One
                    ClassF.DBClass.GameEntities.SaveChanges();
                    //---------------------------------------
                    ExpTb.Visibility = Visibility.Visible;//One
                    ExpTb.Text = $"+{context.Action.ActionExp.ToString()}exp";//One
                    await Task.Delay(3000);
                    ExpTb.Visibility = Visibility.Collapsed;//One
                    StrengthDataGrid.ItemsSource = ClassF.DBClass.GameEntities.UserAction.Where(x => x.Parameter == "Strength" && x.IdUser == context.UserG.Id).ToList();//One
                }//One

                if (context.Parameter == "Intellect")
                {
                    //---------------------------------------
                    context.UserG.Parameter.Intellect += context.Action.ActionExp;//Two
                    ClassF.DBClass.GameEntities.SaveChanges();
                    TwoLevelStrengthTb.Text = ClassF.DBClass.GameEntities.ParameterLevel.FirstOrDefault(x => context.UserG.Parameter.Intellect >= x.ParamExp && context.UserG.Parameter.Intellect < x.ParamExp * 2).lvl.ToString();//Two
                    TwoProgressBarStrength.Value = ((Convert.ToDouble(context.UserG.Parameter.Intellect) - Convert.ToDouble(userparamTwo.ParamExp)) / Convert.ToDouble(userparamTwo.ParamExp)) * 100;//Two
                    ClassF.DBClass.GameEntities.SaveChanges();
                    //---------------------------------------
                    TwoExpTb.Visibility = Visibility.Visible;//Two
                    TwoExpTb.Text = $"+{context.Action.ActionExp.ToString()}exp";//Two
                    await Task.Delay(3000);
                    TwoExpTb.Visibility = Visibility.Collapsed;//Two
                    TwoDataGrid.ItemsSource = ClassF.DBClass.GameEntities.UserAction.Where(x => x.Parameter == "Intellect" && x.IdUser == context.UserG.Id).ToList();//Two
                }//Two

                if(context.Parameter == "Skill")
                {
                    //---------------------------------------
                    context.UserG.Parameter.Skill += context.Action.ActionExp;//Three
                    ClassF.DBClass.GameEntities.SaveChanges();
                    ThreeLevelStrengthTb.Text = ClassF.DBClass.GameEntities.ParameterLevel.FirstOrDefault(x => context.UserG.Parameter.Skill >= x.ParamExp && context.UserG.Parameter.Skill < x.ParamExp * 2).lvl.ToString();//Three
                    ThreeProgressBarStrength.Value = ((Convert.ToDouble(context.UserG.Parameter.Skill) - Convert.ToDouble(userparamThree.ParamExp)) / Convert.ToDouble(userparamThree.ParamExp)) * 100;//Three
                    ClassF.DBClass.GameEntities.SaveChanges();
                    //---------------------------------------
                    ThreeExpTb.Visibility = Visibility.Visible;//Three
                    ThreeExpTb.Text = $"+{context.Action.ActionExp.ToString()}exp";//Three
                    await Task.Delay(3000);
                    ThreeExpTb.Visibility = Visibility.Collapsed;//Three
                    ThreeDataGrid.ItemsSource = ClassF.DBClass.GameEntities.UserAction.Where(x => x.Parameter == "Skill" && x.IdUser == context.UserG.Id).ToList();//Three
                }//Three

                if (context.Parameter == "GoodHabits")
                {
                    //---------------------------------------
                    context.UserG.Parameter.GoodHabits += context.Action.ActionExp;//Four
                    ClassF.DBClass.GameEntities.SaveChanges();
                    FourLevelStrengthTb.Text = ClassF.DBClass.GameEntities.ParameterLevel.FirstOrDefault(x => context.UserG.Parameter.GoodHabits >= x.ParamExp && context.UserG.Parameter.GoodHabits < x.ParamExp * 2).lvl.ToString();//Four
                    FourProgressBarStrength.Value = ((Convert.ToDouble(context.UserG.Parameter.GoodHabits) - Convert.ToDouble(userparamFour.ParamExp)) / Convert.ToDouble(userparamFour.ParamExp)) * 100;//Four
                    ClassF.DBClass.GameEntities.SaveChanges();
                    //---------------------------------------
                    FourExpTb.Visibility = Visibility.Visible;//Four
                    FourExpTb.Text = $"+{context.Action.ActionExp.ToString()}exp";//Four
                    await Task.Delay(3000);
                    FourExpTb.Visibility = Visibility.Collapsed;//Four
                    FourDataGrid.ItemsSource = ClassF.DBClass.GameEntities.UserAction.Where(x => x.Parameter == "GoodHabits" && x.IdUser == context.UserG.Id).ToList();//Four
                }//Four

                if (context.Parameter == "BadHabits")
                {
                    //---------------------------------------
                    context.UserG.Parameter.BadHabits += context.Action.ActionExp;//Five
                    ClassF.DBClass.GameEntities.SaveChanges();
                    FiveLevelStrengthTb.Text = ClassF.DBClass.GameEntities.ParameterLevel.FirstOrDefault(x => context.UserG.Parameter.BadHabits >= x.ParamExp && context.UserG.Parameter.BadHabits < x.ParamExp * 2).lvl.ToString();//Five
                    FiveProgressBarStrength.Value = ((Convert.ToDouble(context.UserG.Parameter.BadHabits) - Convert.ToDouble(userparamFive.ParamExp)) / Convert.ToDouble(userparamFive.ParamExp)) * 100;//Five
                    ClassF.DBClass.GameEntities.SaveChanges();
                    //---------------------------------------
                    FiveExpTb.Visibility = Visibility.Visible;//Five
                    FiveExpTb.Text = $"+{context.Action.ActionExp.ToString()}exp";//Five
                    await Task.Delay(3000);
                    FiveExpTb.Visibility = Visibility.Collapsed;//Five
                    FiveDataGrid.ItemsSource = ClassF.DBClass.GameEntities.UserAction.Where(x => x.Parameter == "BadHabits" && x.IdUser == context.UserG.Id).ToList();//Five
                }//Five

                context.UserG.Exp = userparam.lvl + userparamTwo.lvl + userparamThree.lvl + userparamFour.lvl - userparamFive.lvl + 1;

                var userLevel = ClassF.DBClass.GameEntities.UserLevel.FirstOrDefault(x => context.UserG.Exp >= x.UserLvlExp && context.UserG.Exp < x.UserLvlExp * 2);
                TbUserLevel.Text = userLevel.lvl.ToString();
                PrBarUserLevel.Value = ((Convert.ToDouble(context.UserG.Exp) - Convert.ToDouble(userLevel.UserLvlExp)) / Convert.ToDouble(userLevel.UserLvlExp)) * 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "404");
            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (DataCellMinus.Visibility == Visibility.Visible)
            {
                DataCellMinus.Visibility = Visibility.Collapsed;//One
                TwoDataCellMinus.Visibility = Visibility.Collapsed;//Two
                ThreeDataCellMinus.Visibility = Visibility.Collapsed;//Three
                FourDataCellMinus.Visibility = Visibility.Collapsed;//Four
                FiveDataCellMinus.Visibility = Visibility.Collapsed;//Five
            }
            else 
            { 
                DataCellMinus.Visibility = Visibility.Visible;//One
                TwoDataCellMinus.Visibility = Visibility.Visible;//Two
                ThreeDataCellMinus.Visibility = Visibility.Visible;//Three
                FourDataCellMinus.Visibility = Visibility.Visible;//Four
                FiveDataCellMinus.Visibility = Visibility.Visible;//Five
            } 
        }


        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var cell = (Image)sender;
                var context = cell.DataContext as DataBaseF.UserAction;
                ClassF.DBClass.GameEntities.UserAction.Remove(context);
                ClassF.DBClass.GameEntities.SaveChanges();
                MessageBox.Show("Действие успешно удалено!");

                StrengthDataGrid.ItemsSource = ClassF.DBClass.GameEntities.UserAction.Where(x => x.Parameter == "Strength" && x.IdUser == 1).ToList();//One
                TwoDataGrid.ItemsSource = ClassF.DBClass.GameEntities.UserAction.Where(x => x.Parameter == "Intellect" && x.IdUser == 1).ToList();//Two
                ThreeDataGrid.ItemsSource = ClassF.DBClass.GameEntities.UserAction.Where(x => x.Parameter == "Skill" && x.IdUser == 1).ToList();//Three
                FourDataGrid.ItemsSource = ClassF.DBClass.GameEntities.UserAction.Where(x => x.Parameter == "GoodHabits" && x.IdUser == 1).ToList();//Four
                FiveDataGrid.ItemsSource = ClassF.DBClass.GameEntities.UserAction.Where(x => x.Parameter == "BadHabits" && x.IdUser == 1).ToList();//Five
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BtnAdd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WinAdd winAdd = new WinAdd("Strength", 1);//One
            winAdd.Show();
        }

        private void TwoBtnAdd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WinAdd winAdd = new WinAdd("Intellect", 1);//Two
            winAdd.Show();
        }

        private void ThreeBtnAdd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WinAdd winAdd = new WinAdd("Skill", 1);//Three
            winAdd.Show();
        }

        private void FourBtnAdd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WinAdd winAdd = new WinAdd("GoodHabits", 1);//Four
            winAdd.Show();
        }

        private void FiveBtnAdd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WinAdd winAdd = new WinAdd("BadHabits", 1);//Five
            winAdd.Show();
        }
    }
}
