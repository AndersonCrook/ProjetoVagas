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

    }
}