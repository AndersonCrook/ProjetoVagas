using System;
using System.Collections.Generic;
using ProjetoVagas.Data;
using ProjetoVagas.Models;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace ProjetoVagas.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyJobsregistered : ContentPage
	{
		public MyJobsregistered ()
		{
			InitializeComponent ();
            LoadJobs();
		}

        public  void LoadJobs()
        {
            ListOfRegisteredJobs.Children.Clear();

            BaseData database = new BaseData();
            List<Vagas> Lista = database.GetAll();

            int i = 0;
            foreach (Vagas job in Lista)
            {
                RegisteredJobs(job, i);
                i++;
            }
        }

        public void RegisteredJobs(Vagas jobs, int index)
        {
            object dado = null;
            dado = new StackLayout() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Margin = 10, Spacing = 0 };
            ((StackLayout)dado).Children.Add(new Label() { Text = jobs.JobTitle, FontSize = 20, FontAttributes = FontAttributes.Bold, TextColor = Color.FromHex("#2E2E2E") });
            ((StackLayout)dado).Children.Add(new Label() { Text = jobs.Companies, FontSize = 15, FontAttributes = FontAttributes.Bold, TextColor = Color.FromHex("#464646") });
            ((StackLayout)dado).Children.Add(new Label() { Text = jobs.City, FontSize = 12, FontAttributes = FontAttributes.Bold, TextColor = Color.FromHex("#5D5D5D") });
            
            Label editar = new Label() { Text = "Editar", FontSize = 20, FontAttributes = FontAttributes.Bold, VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.End, TextColor = Color.FromHex("#FF9900") };
            Label serapador = new Label() { Text = " / ", FontSize = 20, FontAttributes = FontAttributes.Bold, VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.End, TextColor = Color.FromHex("#FF9900") };
            Label excluir = new Label() { Text = "Excluir", FontSize = 20, FontAttributes = FontAttributes.Bold, VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.End, TextColor = Color.FromHex("#FF9900") };

            TapGestureRecognizer CheckTapEditar = new TapGestureRecognizer();
            CheckTapEditar.Tapped += delegate
            {
                Navigation.PushModalAsync(new Edit(jobs));
            };
            editar.GestureRecognizers.Add(CheckTapEditar);

            TapGestureRecognizer CheckTapEcluir = new TapGestureRecognizer();
            CheckTapEcluir.Tapped += delegate
            {
                BaseData dataBase = new BaseData();
                dataBase.Delete(jobs);
                LoadJobs();
            };
            excluir.GestureRecognizers.Add(CheckTapEcluir);

            StackLayout detail = null;
            detail = new StackLayout() {Orientation = StackOrientation.Horizontal, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.EndAndExpand, Margin = 10 };
            detail.Children.Add(editar);
            detail.Children.Add(serapador);
            detail.Children.Add(excluir);

            StackLayout job = new StackLayout() { Orientation = StackOrientation.Horizontal, HeightRequest = 70, Spacing = 0, Margin = 10, BackgroundColor = Color.FromHex("#D1D1D1") };
            job.Children.Add((View)dado);
            job.Children.Add(detail);

            ListOfRegisteredJobs.Children.Add(job);
        }
    }
}