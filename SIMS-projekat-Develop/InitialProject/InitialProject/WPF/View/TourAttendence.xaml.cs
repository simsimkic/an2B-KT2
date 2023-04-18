﻿using InitialProject.Domain.Model;
using InitialProject.WPF.ViewModel;
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

namespace InitialProject.WPF.View
{
    /// <summary>
    /// Interaction logic for TourAttendence.xaml
    /// </summary>
    public partial class TourAttendence : Window
    {
        public TourAttendence(User user)
        {
            InitializeComponent();
            TourAttendenceViewModel tourAttendenceViewModel = new TourAttendenceViewModel(user);
            DataContext=tourAttendenceViewModel;
            if (tourAttendenceViewModel.CloseAction == null)
                tourAttendenceViewModel.CloseAction = new Action(this.Close);
        }
    }
}
