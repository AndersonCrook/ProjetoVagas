using System;
using System.Globalization;
using ProjetoVagas.Data;
using ProjetoVagas.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjetoVagas.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Edit 
	{
        private Vagas Job { get; set;}

		public Edit (Vagas job)
		{
			InitializeComponent ();

            Job = job;

            JobTitle.Text = Job.JobTitle;
            Companies.Text = Job.Companies;
            Quantity.Text = Job.Quantity.ToString();
            City.Text = Job.City;
            Salary.Text = Job.Salary.ToString(CultureInfo.InvariantCulture);
            Description.Text = Job.Description;
            TypeOfHiring.IsToggled = (Job.TypeOfHiring != "CLT");
            Telephone.Text = Job.Telephone;
            Email.Text = Job.Email;
        }

        public void CloseModal(object sender, EventArgs args)
        {
            Navigation.PopModalAsync();
        }

        public void SaveJob(object sender, EventArgs args)
        {
            try
            {
                Job.JobTitle = JobTitle.Text;
                Job.Companies = Companies.Text;
                Job.Quantity = short.Parse(Quantity.Text);
                Job.City = City.Text;
                Job.Salary = double.Parse(Salary.Text);
                Job.Description = Description.Text;
                Job.TypeOfHiring = (TypeOfHiring.IsToggled) ? "PJ" : "CLT";
                Job.Telephone = Telephone.Text;
                Job.Email = Email.Text;

                BaseData dataBase = new BaseData();
                dataBase.Update(Job);

                Application.Current.MainPage = new Home();
            }
            catch (Exception)
            {
                DisplayAlert("Campo Invalido", "Preencha todos os campos", "OK");
            }
        }
    }
}