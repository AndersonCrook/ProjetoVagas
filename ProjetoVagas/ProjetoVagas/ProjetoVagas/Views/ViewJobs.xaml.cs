using ProjetoVagas.Models;
using System;
using System.Collections.Generic;
using ProjetoVagas.Data;
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
            LoadJobs();
        }

        public void CreateNewJob(object sender, EventArgs args)
        {
            Navigation.PushModalAsync(new RegisterJobs());
        }

        public void LoadJobs()
        {
            Listjobs.Children.Clear();

            BaseData database = new BaseData();
            List<Vagas> Lista =  database.GetAll();

            int i = 0;
            foreach (Vagas job in Lista)
            {
                Jobs(job, i);
                i++;
            }
        }

        public void Jobs(Vagas jobs, int index)
        {
            object dado = null;
            dado = new StackLayout() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Margin = 10, Spacing = 0 };
            ((StackLayout)dado).Children.Add(new Label() { Text = jobs.JobTitle, FontSize = 20, FontAttributes = FontAttributes.Bold, TextColor = Color.FromHex("#2E2E2E")});
            ((StackLayout)dado).Children.Add(new Label() { Text = jobs.Companies, FontSize = 15, FontAttributes = FontAttributes.Bold, TextColor = Color.FromHex("#464646") });
            ((StackLayout)dado).Children.Add(new Label() { Text = jobs.City, FontSize = 12, FontAttributes = FontAttributes.Bold, TextColor = Color.FromHex("#5D5D5D") });

            Label Detalhes = null;
            Detalhes = new Label() { Text = "+ Detalhes", FontSize = 20, FontAttributes = FontAttributes.Bold, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.End, TextColor = Color.FromHex("#FF9900") };

            TapGestureRecognizer CheckTap = new TapGestureRecognizer();
            CheckTap.Tapped += delegate
            {
                Navigation.PushModalAsync(new JobDetail(jobs));
            };
            Detalhes.GestureRecognizers.Add(CheckTap);

            StackLayout detail = null;
            detail = new StackLayout() { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, Margin = 23};
            detail.Children.Add((View)Detalhes);

            StackLayout job = new StackLayout(){ Orientation = StackOrientation.Horizontal, HeightRequest = 70,Spacing = 0,Margin = 10,BackgroundColor = Color.FromHex("#D1D1D1") };
            job.Children.Add((View)dado);
            job.Children.Add(detail);

            Listjobs.Children.Add(job);
        }
    }
}