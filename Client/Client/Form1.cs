using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Text;

namespace Client
{
    public partial class Form1 : Form
    {
        private readonly Directory _dir = new Directory();
        public Form1()
        {
            InitializeComponent();

            directoryListView.SmallImageList = iconList;
            directoryListView.Columns.Add(new ColumnHeader());
            directoryListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            var request = WebRequest.Create("http://localhost:8080/c:/");
            var response = request.GetResponse();
            var inputStream = new StreamReader(response.GetResponseStream(), Encoding.Default);
            var inputString = inputStream.ReadToEnd();
            _dir.DirectoryInfo = JsonConvert.DeserializeObject<IEnumerable<FileSystemInfo>>(inputString, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto
            });
            pathTextBox.Text = _dir.Root = @"c:\";
            UpdateDirectoryList(_dir.DirectoryInfo);

        }

        private void UpdateDirectoryList(IEnumerable<FileSystemInfo> dir)
        {
            iconList.Images.Clear();
            directoryListView.Items.Clear();
            directoryListView.Items.Add("..");

            var i = 0;
            foreach (var fsi in dir)
            {
                
                if (fsi is DirectoryInfo)
                    iconList.Images.Add(Properties.Resources.folderIcon);
                else
                    iconList.Images.Add(Properties.Resources.fileIcon);
                directoryListView.Items.Add(fsi.Name, i);
                i++;
            }
        }

        private void UpdateDirectoryInfo()
        {
            string rawUrl;
            if (pathTextBox.Focused)
            {
                rawUrl = pathTextBox.Text;
            }
            else
            {
                if (directoryListView.SelectedItems.Count < 1 ||
                !((directoryListView.SelectedItems[0].Index == 0) ||
                (_dir.DirectoryInfo.ElementAt(directoryListView.SelectedItems[0].Index - 1) is DirectoryInfo)))
                    return;
                if (directoryListView.SelectedItems[0].Index == 0)
                    rawUrl = _dir.Root;
                else
                    rawUrl = _dir.DirectoryInfo.ElementAt(directoryListView.SelectedItems[0].Index - 1).FullName;
            }

            var request = WebRequest.Create(System.Web.HttpUtility.UrlPathEncode("http://localhost:8080/" + rawUrl));
            var response = request.GetResponse();
            var inputStream = new StreamReader(response.GetResponseStream(), Encoding.Default);
            var inputString = inputStream.ReadToEnd();

            _dir.DirectoryInfo = JsonConvert.DeserializeObject<IEnumerable<FileSystemInfo>>(inputString,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto
                });

            _dir.Root = rawUrl.Remove(rawUrl.LastIndexOf(@"\") + 1, rawUrl.Length - rawUrl.LastIndexOf(@"\") - 1).TrimEnd(Convert.ToChar(92));
            if (_dir.Root != string.Empty && _dir.Root[_dir.Root.Length - 1] == ':')
                _dir.Root += @"\";
            pathTextBox.Text = rawUrl;
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateDirectoryInfo();

                UpdateDirectoryList(_dir.DirectoryInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void directoryListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                UpdateDirectoryInfo();

                UpdateDirectoryList(_dir.DirectoryInfo);
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
                    UpdateDirectoryInfo();

                    UpdateDirectoryList(_dir.DirectoryInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pathTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    UpdateDirectoryInfo();
                    UpdateDirectoryList(_dir.DirectoryInfo);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
