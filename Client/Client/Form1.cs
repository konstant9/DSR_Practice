using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Text;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Threading;

namespace Client
{
    public partial class Form1 : Form
    {
        private readonly Directory _dir1;
        private readonly Directory _dir2;
        private readonly Hashtable _iconList = Foreign.RegisteredFileType.GetFileTypeAndIcon();
        public Form1()
        {
            InitializeComponent();
            var form2 = new Form2();
            form2.ShowDialog();
            directoryListView1.SmallImageList = iconList1;
            directoryListView2.SmallImageList = iconList2;
            

            var request = WebRequest.Create(ExtraData.ServerData.ConnectionString);
            var response = (HttpWebResponse)request.GetResponse();
            var inputStream = new StreamReader(response.GetResponseStream(), Encoding.Default);
            var inputString = inputStream.ReadToEnd();
            var drives = JsonConvert.DeserializeObject<DriveInfo[]>(inputString, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });

            UpdateDirectoryList(drives, directoryListView1, pathComboBox1,iconList1);
            UpdateDirectoryList(drives, directoryListView2, pathComboBox2, iconList2);
                
            _dir1 = new Directory(drives);
            _dir2 = new Directory(drives);

            if (!ExtraData.IsEnglish)
            {
                ExtraData.IsEnglish = true;
                Localize();
            }
                
        }

        private string GetExtension(string name)
        {
            if (!name.Contains('.')) return null;
            var lol = name.Split('.');
            return "." + lol.Last();
        }

        private void UpdateDirectoryList(IEnumerable<DirectoryItem> dir, ListView directoryListView, ImageList iconList)
        {
            iconList.Images.Clear();
            directoryListView.Items.Clear();
            directoryListView.Items.Add("..");
            var i = 0;
            foreach (var fsi in dir)
            {
                
                if (fsi.Type == "Directory")
                    iconList.Images.Add(Properties.Resources.folderIcon);
                else
                    try
                    {
                        iconList.Images.Add(Foreign.RegisteredFileType.ExtractIconFromFile(_iconList[GetExtension(fsi.Name)].ToString()));
                    }
                    catch (Exception)
                    {
                        try
                        {
                            iconList.Images.Add(Foreign.RegisteredFileType.ExtractIconFromFile(fsi.Name));
                        }
                        catch (Exception)
                        {
                            iconList.Images.Add(Properties.Resources.unknownFileTypeIcon);
                        }
                    }
                    

                var lvi = new ListViewItem {Text = fsi.Name, ImageIndex = i};
                var lvsi = new ListViewItem.ListViewSubItem();
                if (!ExtraData.IsEnglish)
                {
                    switch (fsi.Type)
                    {
                        case "File":
                            lvsi.Text = @"Файл";
                            break;
                        case "Directory":
                            lvsi.Text = @"Папка";
                            break;
                        default:
                            lvsi.Text = @"Диск";
                            break;
                    }
                }
                else
                    lvsi.Text = fsi.Type;

                lvi.SubItems.Add(lvsi);

                lvsi = new ListViewItem.ListViewSubItem {Text = fsi.Size};

                lvi.SubItems.Add(lvsi);

                directoryListView.Items.Add(lvi);
                i++;
            }
        }

        private void UpdateDirectoryList(DriveInfo[] drives, ListView directoryListView, ComboBox pathComboBox, ImageList iconList)
        {
            pathComboBox.Items.Clear();
            iconList.Images.Clear();
            directoryListView.Items.Clear();

            var i = 0;
            foreach (var drive in drives)
            {
                pathComboBox.Items.Add(drive);
                switch (drive.DriveType)
                {
                    case DriveType.Fixed:
                    {
                        iconList.Images.Add(Properties.Resources.localDrive);
                        break;
                    }
                    case DriveType.CDRom:
                    {
                        iconList.Images.Add(Properties.Resources.romDrive);
                        break;
                    }
                    case DriveType.Network:
                    {
                        iconList.Images.Add(Properties.Resources.netDrive);
                        break;
                    }
                    case DriveType.Removable:
                    {
                        iconList.Images.Add(Properties.Resources.portableDrive);
                        break;
                    }
                    default:
                    {
                        iconList.Images.Add(Properties.Resources.unknownDriveType);
                        break;
                    }
                }
                

                var lvi = new ListViewItem { Text = drive.Name, ImageIndex = i };

                var lvsi = new ListViewItem.ListViewSubItem();
                if (!ExtraData.IsEnglish)
                    lvsi.Text = @"Диск";
                else
                    lvsi.Text = @"Drive";

                lvi.SubItems.Add(lvsi);

                lvsi = new ListViewItem.ListViewSubItem { Text = "" };

                lvi.SubItems.Add(lvsi);

                directoryListView.Items.Add(lvi);
                i++;
            }
        }

        private void UpdateDirectoryInfo(ListView directoryListView, ComboBox pathComboBox, ImageList iconList, Directory dir)
        {
            string rawUrl;
            if (pathComboBox.Focused)
                rawUrl = pathComboBox.Text;
            else if (directoryListView.SelectedItems.Count < 1)
                return;
            else if (dir.DirectoryInfo.Select(dr => dr.Type).Contains("Drive"))
                rawUrl = dir.DirectoryInfo.ElementAt(directoryListView.SelectedItems[0].Index).Fullname;
            else
            {
                if (directoryListView.SelectedItems[0].Index != 0 &&
                (dir.DirectoryInfo.ElementAt(directoryListView.SelectedItems[0].Index - 1).Type == "File"))
                    return;

                if (directoryListView.SelectedItems[0].Index == 0)
                    rawUrl = dir.Root;
                else
                    rawUrl = dir.DirectoryInfo.ElementAt(directoryListView.SelectedItems[0].Index - 1).Fullname;       
            }

            var request = WebRequest.Create(System.Web.HttpUtility.UrlPathEncode(ExtraData.ServerData.ConnectionString + rawUrl));
            var response = request.GetResponse();
            var inputStream = new StreamReader(response.GetResponseStream(), Encoding.Default);
            var inputString = inputStream.ReadToEnd();

            if (rawUrl == string.Empty)
            {
                var drives = JsonConvert.DeserializeObject<DriveInfo[]>(inputString, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });
                dir.DirectoryInfo = drives.Select(dr => new DirectoryItem(dr.Name, dr.Name, "Drive", string.Empty));
                dir.Root = string.Empty;
                UpdateDirectoryList(drives, directoryListView, pathComboBox, iconList);   
            }
            else
            {
                dir.DirectoryInfo = JsonConvert.DeserializeObject<IEnumerable<DirectoryItem>>(inputString,
                    new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.Auto
                    });

                if (rawUrl.Length == 3)
                    dir.Root = string.Empty;
                else
                {
                    dir.Root = rawUrl.Remove(rawUrl.LastIndexOf(@"\") + 1, rawUrl.Length - rawUrl.LastIndexOf(@"\") - 1).TrimEnd(Convert.ToChar(92));
                    if (dir.Root != string.Empty && dir.Root[dir.Root.Length - 1] == ':')
                        dir.Root += @"\";
                }
                dir.DirectoryInfo = dir.DirectoryInfo.OrderBy(x => x.Type == "File").ThenBy(x => x.Name);
                UpdateDirectoryList(dir.DirectoryInfo,directoryListView, iconList);
            } 
            pathComboBox.Text = rawUrl;
        }

        private void directoryListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (directoryListView1.Focused)
                    UpdateDirectoryInfo(directoryListView1, pathComboBox1, iconList1, _dir1);
                else
                    UpdateDirectoryInfo(directoryListView2, pathComboBox2, iconList2, _dir2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void directoryListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    if (directoryListView1.Focused)
                        UpdateDirectoryInfo(directoryListView1, pathComboBox1, iconList1, _dir1);
                    else
                        UpdateDirectoryInfo(directoryListView2, pathComboBox2, iconList2, _dir2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pathComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if(pathComboBox1.Focused)
                        UpdateDirectoryInfo(directoryListView1, pathComboBox1, iconList1, _dir1);
                    else
                        UpdateDirectoryInfo(directoryListView2, pathComboBox2, iconList2, _dir2);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pathComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pathComboBox1.Focused)
                    UpdateDirectoryInfo(directoryListView1, pathComboBox1, iconList1, _dir1);
                else
                    UpdateDirectoryInfo(directoryListView2, pathComboBox2, iconList2, _dir2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Localize()
        {
            if (ExtraData.IsEnglish)
            {
                ExtraData.IsEnglish = false;
                directoryListView1.Columns[0].Name = @"Имя";
                directoryListView1.Columns[1].Name = @"Тип";
                directoryListView1.Columns[2].Name = @"Размер";

                directoryListView2.Columns[0].Name = @"Имя";
                directoryListView2.Columns[1].Name = @"Тип";
                directoryListView2.Columns[2].Name = @"Размер";

                fileToolStripMenuItem.Text = @"Файл";
                exitToolStripMenuItem.Text = @"Выход";
                languageToolStripMenuItem.Text = @"Язык";
                helpToolStripMenuItem.Text = @"Помощь";
                helpToolStripMenuSubItem.Text = @"Помощь";
                
                foreach (var lvi in directoryListView1.Items.Cast<object>().Where(lvi => ((ListViewItem) lvi).Text != ".."))
                {
                    switch (((ListViewItem)lvi).SubItems[1].Text)
                    {
                        case "File":
                            ((ListViewItem)lvi).SubItems[1].Text = @"Файл";
                            break;
                        case "Directory":
                            ((ListViewItem)lvi).SubItems[1].Text = @"Папка";
                            break;
                        default:
                            ((ListViewItem)lvi).SubItems[1].Text = @"Диск";
                            break;
                    }
                }
                foreach (var lvi in directoryListView2.Items.Cast<object>().Where(lvi => ((ListViewItem)lvi).Text != ".."))
                {

                    switch (((ListViewItem)lvi).SubItems[1].Text)
                    {
                        case "File":
                            ((ListViewItem)lvi).SubItems[1].Text = @"Файл";
                            break;
                        case "Directory":
                            ((ListViewItem)lvi).SubItems[1].Text = @"Папка";
                            break;
                        default:
                            ((ListViewItem)lvi).SubItems[1].Text = @"Диск";
                            break;
                    }
                }
            }
            else
            {
                ExtraData.IsEnglish = true;
                directoryListView1.Columns[0].Name = @"Name";
                directoryListView1.Columns[1].Name = @"Type";
                directoryListView1.Columns[2].Name = @"Size";

                directoryListView2.Columns[0].Name = @"Name";
                directoryListView2.Columns[1].Name = @"Type";
                directoryListView2.Columns[2].Name = @"Size";

                fileToolStripMenuItem.Text = @"File";
                exitToolStripMenuItem.Text = @"Exit";
                languageToolStripMenuItem.Text = @"Language";
                helpToolStripMenuItem.Text = @"Help";
                helpToolStripMenuSubItem.Text = @"Help";

                foreach (var lvi in directoryListView1.Items.Cast<object>().Where(lvi => ((ListViewItem)lvi).Text != ".."))
                {

                    switch (((ListViewItem)lvi).SubItems[1].Text)
                    {
                        case "Файл":
                            ((ListViewItem)lvi).SubItems[1].Text = @"File";
                            break;
                        case "Папка":
                            ((ListViewItem)lvi).SubItems[1].Text = @"Directory";
                            break;
                        default:
                            ((ListViewItem)lvi).SubItems[1].Text = @"Drive";
                            break;
                    }
                }
                foreach (var lvi in directoryListView2.Items.Cast<object>().Where(lvi => ((ListViewItem)lvi).Text != ".."))
                {

                    switch (((ListViewItem)lvi).SubItems[1].Text)
                    {
                        case "Файл":
                            ((ListViewItem)lvi).SubItems[1].Text = @"File";
                            break;
                        case "Папка":
                            ((ListViewItem)lvi).SubItems[1].Text = @"Directory";
                            break;
                        default:
                            ((ListViewItem)lvi).SubItems[1].Text = @"Drive";
                            break;
                    }
                }
            }
            
        }

        private void russianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!ExtraData.IsEnglish)
                return;
            Localize();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ExtraData.IsEnglish)
                return;
            Localize();
        }

    }
}
