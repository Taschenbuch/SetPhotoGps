using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ExifLib;
using SetPhotoGps.Model;
using SetPhotoGps.Properties;
using SetPhotoGps.Service;

namespace SetPhotoGps
{
    /* TODO
     * - löschen klappt noch nicht richtig, weil prozess datei verwendet
     * - alte datei durch neue ersetzen wäre interessant, klappte aber auch nicht (wegen löschen problem)
     * - prüft dateiendung, aber dabei ggf. falsche endung → wie testen ob echtes jpeg? "MIME"?
     * - browser darstellung ist nervig
     * - statische map einbauen oder besser dynamische mit feld für ort suche und anzeige von gps daten
     * Das geht aber scheinbar nur mit javascript api. normale api, die c# verwenden kann, kann nur statische maps zeigen
     */
    public partial class Form1 : Form
    {
        public double Longitude
        {
            get => (double) LongitudeNumericUpDown.Value;
            set => LongitudeNumericUpDown.Value = (decimal) value;
        }

        public double Latitude
        {
            get => (double) LatitudeNumericUpDown.Value;
            set => LatitudeNumericUpDown.Value = (decimal) value;
        }

        public string SelectedFolderPath { get; set; }


        public Form1()
        {
            InitializeComponent();
            _folderExplorerService = new FolderExplorerService(treeViewFolderExplorer);
            InitializeForms();
            InitializeWebBrowser();
            InitializeGoogleMaps();
            WindowState = FormWindowState.Maximized;
        }

        public void ShowPhotosInListView()
        {
            listViewPhotosInFolder.BeginUpdate();
            listViewPhotosInFolder.Items.Clear();
            var selectedFolderPath = new DirectoryInfo(SelectedFolderPath);
            foreach (var file in selectedFolderPath.GetFiles())
            {
                if (FileExtensionService.GetIsImage(file)) // eig. überflüssig, aber code ist so schön, deswegen bleibts drin
                    if (FileExtensionService.GetIsJpgOrJpeg(file))
                        AddPhotoToListView(file);
            }

            listViewPhotosInFolder.EndUpdate();
        }

        private void InitializeGoogleMaps()
        {
            _googleMaps = new GoogleMapsService(Resources.GoogleMapsApiKey);
        }

        private void InitializeWebBrowser()
        {
            webBrowserGoogleMaps.Url = new Uri(@"https://www.google.de/maps");
        }


        private void InitializeForms()
        {
            listViewPhotosInFolder.FullRowSelect = true;
            SelectedFolderPath = Settings.Default.savedFolderPath;
            UpdateForms();
        }

        private void buttonFolderpath_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "select image folder that should be displayed",
                SelectedPath = SelectedFolderPath,
                ShowNewFolderButton = false
            };
            var pressedCancelInFolderDialog = folderBrowserDialog.ShowDialog() != DialogResult.OK;
            if (pressedCancelInFolderDialog)
                return;
            if (folderBrowserDialog.SelectedPath == @"C:\")
            {
                MessageBox.Show("It is not possible to select C drive because it would freeze the programm because of too many files.");
                return;
            }

            SelectedFolderPath = folderBrowserDialog.SelectedPath;
            UpdateForms();
            SaveSelectedPathToConfigFile();
        }

        private void UpdateForms()
        {
            var isPathNotNullOrEmpty = false == string.IsNullOrWhiteSpace(SelectedFolderPath);
            if (isPathNotNullOrEmpty)
            {
                textBoxSelectedFolderPath.Text = SelectedFolderPath;
                ShowPhotosInListView();
                _folderExplorerService.PopulateTreeView(SelectedFolderPath);
            }
        }


        private void AddPhotoToListView(FileInfo file)
        {
            var listViewItem = new ListViewItem(file.Name, 0);
            if (FileExtensionService.GetIsJpgOrJpeg(file))
            {
                try
                {
                    Gps gpsData = ExifService.GetGps(file.FullName);
                    var isGpsDataAvailable = gpsData.LatitudeDecimal.HasValue && gpsData.LongitudeDecimal.HasValue;
                    if (isGpsDataAvailable)
                    {
                        listViewItem.SubItems.Add(gpsData.LatitudeDecimal.ToString());
                        listViewItem.SubItems.Add(gpsData.LongitudeDecimal.ToString());
                    }
                }
                catch (ExifLibException ex)
                {
                    listViewItem.SubItems.Add(ex.Message);
                    listViewItem.SubItems.Add("no image preview possible");
                }
            }
            else
            {
                // redundant, weil nur noch jpg, jpeg angezeigt werden
                listViewItem.SubItems.Add("No gps GPS for:");
                listViewItem.SubItems.Add(file.Extension);
            }

            listViewPhotosInFolder.Items.Add(listViewItem);
        }


        private void listViewPhotosInFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            var isItemSelected = listViewPhotosInFolder.SelectedItems.Count > 0;
            if (isItemSelected)
                ShowThumbnail();
        }

        private void ShowThumbnail()
        {
            var photoFilePath = Path.Combine(SelectedFolderPath, listViewPhotosInFolder.SelectedItems[0].Text);
            try
            {
                pictureBoxThumbnail.Image = ExifService.GetThumbnail(photoFilePath);
            }
            catch (ExifLibException)
            {
                pictureBoxThumbnail.Image = null;
            }
        }

        private void buttonSetGps_Click(object sender, EventArgs e)
        {
            var isItemSelected = listViewPhotosInFolder.SelectedItems.Count > 0;
            if (isItemSelected)
            {
                SetSelectedPhotosGps();
                var index = listViewPhotosInFolder.TopItem.Index;
                ShowPhotosInListView();
                listViewPhotosInFolder.TopItem = listViewPhotosInFolder.Items[index];
            }
        }

        private void SetSelectedPhotosGps()
        {
            foreach (var selectedIndex in listViewPhotosInFolder.SelectedIndices)
            {
                SetGps((int) selectedIndex);
            }
        }

        private void SetGps(int selectedIndex)
        {
            var photoFileName = listViewPhotosInFolder.Items[selectedIndex].Text;
            var photoFilePath = Path.Combine(SelectedFolderPath, photoFileName);
            var newPhotoFilePath = AddPrefixToFileName(photoFilePath, "__old_");
            try
            {
                File.Move(photoFilePath, newPhotoFilePath);
                // https://stackoverflow.com/a/34305849
                ExifService.SetGps(new Bitmap(newPhotoFilePath), Latitude, Longitude)
                           .Save(photoFilePath, ImageFormat.Jpeg);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error: {e.Message}");
            }
        }

        private static string AddPrefixToFileName(string filePath, string prefix)
        {
            var fileDirectory = Path.GetDirectoryName(filePath);
            var fileName = Path.GetFileName(filePath);
            var fileNameWithPrefix = $"{prefix}{fileName}";
            return Path.Combine(fileDirectory, fileNameWithPrefix);
        }

        private void textBoxSelectedFolderPath_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    var isDirectoryValid = Directory.Exists(textBoxSelectedFolderPath.Text);
                    if (isDirectoryValid)
                    {
                        SelectedFolderPath = textBoxSelectedFolderPath.Text;
                        SaveSelectedPathToConfigFile();
                        ShowPhotosInListView();
                        _folderExplorerService.PopulateTreeView(SelectedFolderPath);
                    }

                    break;
            }
        }

        private void SaveSelectedPathToConfigFile()
        {
            Settings.Default.savedFolderPath = SelectedFolderPath;
            Settings.Default.Save();
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectedFolderPath = ((DirectoryInfo) e.Node.Tag).FullName;
            textBoxSelectedFolderPath.Text = SelectedFolderPath;
            ShowPhotosInListView();
        }

        private void textBoxGpsCoordinates_TextChanged(object sender, EventArgs e)
        {
            var isGps = AddGpsStringToNumericUpDown();
            if (isGps)
            {
                ShowMapAtCoordinates();
                textBoxGpsCoordinatesOrCity.TextChanged -= textBoxGpsCoordinates_TextChanged;
                textBoxGpsCoordinatesOrCity.Text = _googleMaps.GetCity(Latitude, Longitude);
                textBoxGpsCoordinatesOrCity.TextChanged += textBoxGpsCoordinates_TextChanged;
            }

            //            "51.194161, 8.525399"
        }

        private void ShowMapAtCoordinates()
        {
            var latitude = Latitude.ToString().Replace(',', '.');
            var longitude = Longitude.ToString().Replace(',', '.');
            var zoom = trackBarZoomGoogleMaps.Value;
            webBrowserGoogleMaps.Url = new Uri($@"https://www.google.de/maps/@{latitude},{longitude},{zoom}z");
        }

        private bool AddGpsStringToNumericUpDown()
        {
            var gpsCoordinates = textBoxGpsCoordinatesOrCity.Text
                                                            .Split(new[] {", "}, StringSplitOptions.None)
                                                            .Select(a => a.Replace('.', ','));

            var latitudeString = gpsCoordinates.First();
            var isLatitude = Double.TryParse(latitudeString, out var latitudeNumber);
            Latitude = latitudeNumber;

            var longitudeString = gpsCoordinates.Last();
            var isLongitude = Double.TryParse(longitudeString, out var longitudeNumber);
            Longitude = longitudeNumber;

            var isGps = isLatitude && isLongitude;
            return isGps;
        }

        private void textBoxGpsCoordinates_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    var city = textBoxGpsCoordinatesOrCity.Text;
                    var gps = _googleMaps.GetGpsCoordinates(city);
                    Latitude = (double) gps.LatitudeDecimal;
                    Longitude = (double) gps.LongitudeDecimal;
                    ShowMapAtCoordinates();
                    break;
            }
        }

        private void buttonDeletePhoto_Click(object sender, EventArgs e)
        {
            foreach (var selectedIndex in listViewPhotosInFolder.SelectedIndices)
            {
                var photoFileName = listViewPhotosInFolder.Items[(int) selectedIndex].Text;
                var photoFilePath = Path.Combine(SelectedFolderPath, photoFileName);
                try
                {
                    File.Delete(photoFilePath);
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Error when deleting file: {exception.Message}");
                }
            }
            var index = listViewPhotosInFolder.TopItem.Index;
            ShowPhotosInListView();
            listViewPhotosInFolder.TopItem = listViewPhotosInFolder.Items[index];
        }

        private void listViewPhotosInFolder_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var isOnePhotoSelected = listViewPhotosInFolder.SelectedItems.Count == 1;
            if (isOnePhotoSelected)
            {
                OpenPhotoInDefaultWindowsPhotoViewer();
            }
        }

        private void OpenPhotoInDefaultWindowsPhotoViewer()
        {
            var photoFileName = listViewPhotosInFolder.SelectedItems[0].Text;
            var photoFilePath = Path.Combine(SelectedFolderPath, photoFileName);
            try
            {
                Process.Start(photoFilePath);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error when starting windows foto preview: {exception}");
            }
        }

        private void trackBarZoomGoogleMaps_Scroll(object sender, EventArgs e)
        {
            ShowMapAtCoordinates();
        }

        private void listViewPhotosInFolder_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    var isOnePhotoSelected = listViewPhotosInFolder.SelectedItems.Count == 1;
                    if (isOnePhotoSelected)
                    {
                        OpenPhotoInDefaultWindowsPhotoViewer();
                    }
                    break;
            }
        }

        private readonly FolderExplorerService _folderExplorerService;
        private GoogleMapsService _googleMaps;
    }
}