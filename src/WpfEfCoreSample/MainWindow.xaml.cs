using System.Windows;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WpfEfCoreSample;

namespace WpfEfCoreSample
{
    public partial class MainWindow : Window
    {
        private AppDbContext _db;

        public MainWindow()
        {
            InitializeComponent();
            _db = new AppDbContext();
            _db.Database.Migrate(); // マイグレーションを適用
            LoadPeople();
        }

        private void LoadPeople()
        {
            PeopleListBox.ItemsSource = _db.People.Select(p => $"{p.Id}: {p.Name}, {p.Age}歳").ToList();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var name = NameTextBox.Text.Trim();
            var ageText = AgeTextBox.Text.Trim();
            
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("名前を入力してください。");
                return;
            }
            
            if (!int.TryParse(ageText, out int age))
            {
                MessageBox.Show("年齢は数値で入力してください。");
                return;
            }
            
            _db.People.Add(new Person { Name = name, Age = age });
            _db.SaveChanges();
            NameTextBox.Text = "";
            AgeTextBox.Text = "";
            LoadPeople();
        }
    }
}