using ProjetoVagas.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoVagas.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewJobs : ContentPage
	{
		public ViewJobs ()
		{
			InitializeComponent ();
		}

        public void CreateNewJob(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new RegisterJobs());
            
        }

        public void MoreDetails(object sender, EventArgs args)
        {
            Label lblDetail = (Label)sender;
            Vagas job =((TapGestureRecognizer)lblDetail.GestureRecognizers[0]).CommandParameter as Vagas;

            Navigation.PushModalAsync(new JobDetail(job));
        }
    }
}