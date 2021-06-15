using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MiniTotalCommander.View
{
    public partial class PanelTC : UserControl
    {
        public PanelTC()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CurrentPathProperty =
            DependencyProperty.Register(
                    nameof(CurrentPath),
                    typeof(string),
                    typeof(PanelTC));


        public string CurrentPath
        {
            get { return (string)GetValue(CurrentPathProperty); }
            set
            {
                SetValue(CurrentPathProperty, value);
            }
        }

        public static readonly DependencyProperty SelectedPathProperty =
            DependencyProperty.Register(
                    nameof(SelectedPath),
                    typeof(string),
                    typeof(PanelTC));


        public string SelectedPath
        {
            get { return (string)GetValue(SelectedPathProperty); }
            set
            {
                SetValue(SelectedPathProperty, value);
            }
        }

        public static readonly DependencyProperty DriveProperty =
            DependencyProperty.Register(
                    nameof(Drives),
                    typeof(string[]),
                    typeof(PanelTC));

        public string[] Drives
        {
            get { return (string[])GetValue(DriveProperty); }
            set
            {
                SetValue(DriveProperty, value);
            }
        }

        public static readonly DependencyProperty CurrentDriveProperty =
            DependencyProperty.Register(
                    nameof(CurrentDrive),
                    typeof(string),
                    typeof(PanelTC));       

        public string[] Paths
        {
            get { return (string[])GetValue(PathProperty); }
            set
            {
                SetValue(PathProperty, value);
            }
        }

        public string CurrentDrive
        {
            get { return (string)GetValue(CurrentDriveProperty); }
            set
            {
                SetValue(CurrentDriveProperty, value);
            }
        }

        public static readonly DependencyProperty PathProperty =
            DependencyProperty.Register(
                    nameof(Paths),
                    typeof(string[]),
                    typeof(PanelTC));


        public static readonly DependencyProperty DoubleClickProperty =
        DependencyProperty.Register(
            nameof(DoubleClickCommand),
            typeof(ICommand),
            typeof(PanelTC),
            new PropertyMetadata(null));
        public ICommand DoubleClickCommand
        {
            get { return (ICommand)GetValue(DoubleClickProperty); }
            set { SetValue(DoubleClickProperty, value); }
        }

    }
}
