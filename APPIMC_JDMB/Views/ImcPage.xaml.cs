namespace APPIMC_JDMB.Views;

using APPIMC_JDMB.ViewModels;


public partial class ImcPage : ContentPage
{
	public ImcPage()
	{
		InitializeComponent();

		BindingContext = new ImcViewModel();
	}
}