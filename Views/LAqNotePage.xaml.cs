namespace Leonardo_Andrade_PROYECTOAPUNTES.Views;
[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class LAqNotePage : ContentPage
{
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
    public LAqNotePage()
    {
        InitializeComponent();


        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";


        LoadNote(Path.Combine(appDataPath, randomFileName));
    }
    public string ItemId
    {
        set { LoadNote(value); }
    }
    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.LA000ALLNOTES note)
        {
            File.WriteAllText(note.Filename, TextEditor.Text);
        }

        await Shell.Current.GoToAsync("..");
    }
    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.LA000ALLNOTES note)
        {
            // Delete the file.
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void LoadNote(string fileName)
    {
        Models.LAqNote noteModel = new Models.LAqNote();
        noteModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }
}
