﻿using System;
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
using System.Data.Entity;

namespace DogShowProgram.Pages
{
    /// <summary>
    /// Interaction logic for EditDogPassport_Page.xaml
    /// </summary>

    public partial class EditDogPassport_Page : Page
    {
        public DogPassport passport;
        public DogOwner owner;

        public EditDogPassport_Page()
        {
            InitializeComponent();
        }

        private void back_but_Click(object sender, RoutedEventArgs e)
        {
            Scripts.DataHolder.frame_main.GoBack();
        }

        private void editDogPassport_but_Click(object sender, RoutedEventArgs e)
        {
            using (DogShowEntities db = new DogShowEntities())
            {
                passport.NickName = nickName_textbox.Text;
                passport.Gender = gender_cb.Text;
                passport.Breed = breed_textbox.Text;
                passport.BrithdayDate = brithdayDate_datePic.DisplayDate;
                passport.LastDateVaccination = vaccinationDate_datePic.DisplayDate;
                passport.IdDogOwner = owner.IdDogOwner;

                db.Entry(passport).State = EntityState.Modified;
                db.SaveChanges();
            }
            
            Windows.Messagebox_Window messagebox = new Windows.Messagebox_Window()
            {
                nameMessage = "Уведомление",
                Message = "Паспорт собаки был изменён.",
                error = false
            };
            messagebox.ShowDialog();
            Scripts.DataHolder.frame_main.GoBack();

        }
    }
}
