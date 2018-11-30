using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoVagas.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterJobs : ContentPage
	{
		public RegisterJobs ()
		{
			InitializeComponent ();
		}

        public void CloseModal(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();

        }

    }
}