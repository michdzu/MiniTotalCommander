using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTotalCommander.ViewModel
{
    using BaseClass;
    using System.IO;
    using Model;
    using System.Windows.Input;

    class PanelTCViewModel : BaseViewModel
    {
        public PanelTCViewModel()
        {


            Drives = Directory.GetLogicalDrives();
            CurrentDrive = Drives[0];

        }

        private string currentPath;
        public string CurrentPath
        {
            get { return currentPath; }
            set
            {
                SetProperty(ref currentPath, value);
                UpdateDir();

            }
        }

        private string selectedPath;
        public string SelectedPath
        {
            get { return selectedPath; }
            set
            {
                SetProperty(ref selectedPath, value);


            }
        }

        
        private string[] drives;
        public string[] Drives
        {
            get { return drives; }
            set
            {
                SetProperty(ref drives, value);
            }
        }

        private string currentDrive;
        public string CurrentDrive
        {
            get { return currentDrive; }
            set
            {
                SetProperty(ref currentDrive, value ?? Drives[0]);
                CurrentPath = CurrentDrive;
                UpdateDir();               
            }
        }

        private string[] paths;
        public string[] Paths
        {
            get { return paths; }
            set
            {
                SetProperty(ref paths, value);
                
            }
        }
      
            
        public void UpdateDir()
        {

            try
            {
                Dir cont = new Dir();
                cont.Path = CurrentPath;
                cont.Directories = Directory.GetDirectories(CurrentPath);
                cont.Files = Directory.GetFiles(CurrentPath);

                int length = cont.Directories.Length + cont.Files.Length;

                string[] NewPaths = new string[length + 1];
                NewPaths[0] = ("...");

                for (int i = 0; i < cont.Directories.Length; i++)
                    NewPaths[i + 1] ="<D>" + Path.GetFileName(cont.Directories[i]);
                for (int i = 0; i < cont.Files.Length; i++)
                    NewPaths[i + cont.Directories.Length + 1] = Path.GetFileName(cont.Files[i]);

                Paths = NewPaths;
                
            }
            catch(IOException)
            {
                
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Zbyt male uprawnienia!");
            }
            
            
        }

        private void DoubleClick()
        {
            
            string selected = SelectedPath;

            if (selected.Equals("..."))
            {

                if (!Drives.Contains(CurrentPath))
                {

                    CurrentPath = Directory.GetParent(CurrentPath).FullName;

                }
            }
            else if (selected.StartsWith("<D>"))
            {
                selected = selected.Substring(3);

                if (Drives.Contains(CurrentPath))
                {

                    CurrentPath = CurrentPath + selected;

                }
                else
                {
                    CurrentPath = CurrentPath + @"\" + selected;
                }
            }

        }


        private ICommand doubleClickCommand;
        public ICommand DoubleClickcommand
        {
            get
            {
                
                if (doubleClickCommand == null)
                {
                    
                    return new RelayCommand(p => DoubleClick(), p => true);
                }
                else
                {
                    
                    return doubleClickCommand;
                }
            }
            set
            {
                SetProperty(ref doubleClickCommand, value);
                
            }
        }


    }
}
