using System;
using ProjetoVagas.Models;
using ProjetoVagas.Data;
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

        public void SaveJob(object sender, EventArgs args)
        {
            //TODO - Validar Dados do cadastro
            try
            {
                Vagas job = new Vagas();
                job.JobTitle = JobTitle.Text;
                job.Companies = Companies.Text;
                job.Quantity = short.Parse(Quantity.Text);
                job.City = City.Text;
                job.Salary = double.Parse(Salary.Text);
                job.Description = Description.Text;
                job.TypeOfHiring = (TypeOfHiring.IsToggled) ? "PJ" : "CLT";
                job.Telephone = Telephone.Text;
                job.Email = Email.Text;

                BaseData dataBase = new BaseData();
                dataBase.Save(job);

                App.Current.MainPage = new Home();
            }
            catch (Exception e)
            {
                DisplayAlert("Campo Invalido", "Preencha todos os campos", "OK");
            }
        }
    }
}