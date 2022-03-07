using System;
using e53.Helpers;
using e53.Models;
using System.Threading.Tasks;

namespace e53.ViewModels
{
    public class DoctoresViewModel: ViewModelBase
    {
        HelperDoctorAzure helper = new HelperDoctorAzure();
        private Doctor _Doctor;

        public Doctor Doctor
        {
            get { return _Doctor; }
            set { _Doctor = value; OnPropertyChanged("Doctor"); }
        }

        public void getDoctor(int id)
        {
            Task.Run(async () => {
                Doctor doc = await helper.GetDoctor(id);
                this.Doctor = doc;
            });
        }
    }
}
