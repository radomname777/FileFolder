﻿
using Microsoft.Win32;
using MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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


namespace WpfApp6
{
    public partial class MainWindow : Window
    {
        public AddViewModel add { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            add= new AddViewModel(this);
            DataContext = add;

        }
    }
}
