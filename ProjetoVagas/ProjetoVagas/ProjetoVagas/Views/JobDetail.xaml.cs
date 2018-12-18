using ProjetoVagas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoVagas.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class JobDetail : ContentPage
	{
		public JobDetail (Vagas job)
		{
			InitializeComponent ();
            DisplayAlert("Vaga", job.JobTitle,"OK");
		}

        public void CloseModal(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();

        }
    }
}