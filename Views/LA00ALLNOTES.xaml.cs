namespace Leonardo_Andrade_PROYECTOAPUNTES.Views;

public partial class LA00ALLNOTES : ContentPage
{
	public LA00ALLNOTES()
	{
		InitializeComponent();  
        BindingContext = new Models.LA000ALLNOTES();
    }
  
    protected override void OnAppearing()
    {
        ((Models.LA000ALLNOTES)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(LAqNotePage));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.LAqNote)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(LAqNotePage)}?{nameof(LAqNotePage.ItemId)}={note.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}