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

namespace PruebaPracticaJGG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Load the image from the resource file
            BitmapImage image = new BitmapImage(new Uri("C:\\Users\\javgalgas\\Documents\\ShareX\\Screenshots\\2024-05\\chrome_EHDh6JFOs6.png"));

            // Set the image as the Image control's Source property
            myImage.Source = image;
        }
    }
}
