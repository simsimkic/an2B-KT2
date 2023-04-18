﻿using InitialProject.Domain.Model;
using InitialProject.Forms;
using InitialProject.Repository;
using InitialProject.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace InitialProject.View
{
    /// <summary>
    /// Interaction logic for TourGuests.xaml
    /// </summary>
    public partial class TourGuests : Window
    {
        public TourGuests(Tour tour, TourPoint tourPoint)
        {
            this.Width = 430;
            this.Height = 750;
            InitializeComponent();
            TourGuestsViewModel guestsViewModel = new TourGuestsViewModel(tour, tourPoint);
            DataContext = guestsViewModel;
            if (guestsViewModel.CloseAction == null)
            {
                guestsViewModel.CloseAction = new Action(this.Close);
            }
        }

    }
}
