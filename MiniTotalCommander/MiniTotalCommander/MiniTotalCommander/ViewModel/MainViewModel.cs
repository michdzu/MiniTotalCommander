using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.IO;


namespace MiniTotalCommander.ViewModel
{

    using BaseClass;

    class MainViewModel : BaseViewModel
    {

        public MainViewModel()
        {
            Left = new PanelTCViewModel();
            Right = new PanelTCViewModel();
            
            
        }

        private PanelTCViewModel left;
        public PanelTCViewModel Left
        {
            get { return left; }
            set => SetProperty(ref left, value);
        }
        private PanelTCViewModel right;
        public PanelTCViewModel Right
        {
            get { return right; }
            set => SetProperty(ref right, value);
        }
  

        private ICommand copy;
        public ICommand Copy => copy ?? (copy = new RelayCommand((p) => { copyFile(); }, p => true));

        void copyFile()
        {
            string item = Left.SelectedPath;
            string leftFile = Left.CurrentPath;
            string rightFile = Right.CurrentPath;
            if (item.StartsWith("<D>") || item.Equals("..."))
            {
                return;
            }
            string sourceFile = Path.Combine(leftFile, item);
            string destFile = Path.Combine(rightFile, item);
            File.Copy(sourceFile, destFile, true);           
            Right.UpdateDir();
        }
    }
}