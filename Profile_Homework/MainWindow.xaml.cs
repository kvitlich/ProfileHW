using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Profile_Homework
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      StreamReader reader = new StreamReader(@"C:/Users/ww/source/repos/Profile_Homework/Users/UserElements.txt");
      EnterName_TextBox.Text = reader.ReadLine();
      EnterAddress_TextBox.Text = reader.ReadLine();
      GlobalInfo.pathToPhoto = reader.ReadLine();
      reader.Close();
      Avatar.Source = new ImageSourceConverter().ConvertFromString(GlobalInfo.pathToPhoto) as ImageSource;
    }

    private void Accept_Button_Click(object sender, RoutedEventArgs e)
    {
      StreamWriter writer = new StreamWriter(@"C:/Users/ww/source/repos/Profile_Homework/Users/UserElements.txt");
      writer.WriteLine(EnterName_TextBox.Text);
      writer.WriteLine(EnterAddress_TextBox.Text);
      writer.WriteLine(GlobalInfo.pathToPhoto);
      writer.Close();
    }

    private void DownloadPhoto_Button_Click(object sender, RoutedEventArgs e)
    {
      OpenFileDialog dialog = new OpenFileDialog();
      dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png";
      if (dialog.ShowDialog() == true)
      {
        string avatarsFilePath = @"C:/Users/ww/source/repos/Profile_Homework/Photos/Avatars";
        string nameOfNewAvatar = avatarsFilePath +'\\' + dialog.FileName.Split(new char[] { '\\' })[dialog.FileName.Split(new char[] { '\\' }).Length - 1];
        File.Copy(dialog.FileName, nameOfNewAvatar);
        Avatar.Source = new ImageSourceConverter().ConvertFromString(nameOfNewAvatar) as ImageSource;
        GlobalInfo.pathToPhoto = nameOfNewAvatar;
      }
    }
  }
}
