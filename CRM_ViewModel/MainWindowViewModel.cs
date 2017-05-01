using CRM_ExtraSelfDesignLibraries;
using CRM_Model;
using CRM_ViewModel.Commands;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Threading;

namespace CRM_ViewModel
{
    public class MainWindowViewModel//:ViewModel
    {
        //private LoginViewModel loginView = new LoginViewModel();
        private Employee _EmployeeLoggedIn;
        public Employee EmployeeLoggedIn
        {
            get { return _EmployeeLoggedIn; }
            set
            {
                _EmployeeLoggedIn = value;
                RaisePropertyChanged("EmployeeLoggedIn");
            }
        }

     //   private ViewModel currentView;
     /*   public ViewModel CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;

                RaisePropertyChanged("CurrentView");
            }

        }*/


        public MainWindowViewModel()
        {
           
            //Register for messages from different viewModels
            //EmployeeLoginMessage.Default.Register<Employee>(this, (employee) =>
            //{
            //    ReceiveMessage(employee);
            //});
          /*  CurrentView = loginView;
            _timer = new DispatcherTimer(DispatcherPriority.Render);
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (sender, args) =>
            {
                CurrentTime = DateTime.Now.ToLongTimeString();
            };
            _timer.Start();*/

        }

        /// <summary>
        /// Property Change Event Handeller
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        readonly static MainWindowViewModel MainVm = new MainWindowViewModel();
       
        //private void ReceiveMessage(Employee e)
        //{
        //    EmployeeLoggedIn = e;
            
        //    //CurrentView = MainVm;
        //}

    /*    #region CurrentTime

        private string _currentTime;

        public DispatcherTimer _timer;

        public string CurrentTime
        {
            get
            {
                return this._currentTime;
            }
            set
            {
                if (_currentTime == value)
                    return;
                _currentTime = value;
                RaisePropertyChanged("CurrentTime");
            }
        }
        #endregion*/
    }
}
