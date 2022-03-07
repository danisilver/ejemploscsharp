using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using e53.Helpers;
using e53.Models;
using e53.ViewModels;
using Xamarin.Forms;

namespace e53
{
    public partial class DoctorView : ContentPage
    {
        private DoctoresViewModel dvm = new DoctoresViewModel();
        public DoctorView()
        {
            InitializeComponent();
            layoutDoctor.BindingContext = dvm;
            buscar.Clicked += (object o, EventArgs e) => {
                dvm.getDoctor(int.Parse(txtNumero.Text));
            };
        }
    }
}
