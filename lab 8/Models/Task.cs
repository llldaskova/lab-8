using Avalonia.Controls;
using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_8.Models
{
    public class Task : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChangedEvent(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, e);
            }
        }
        public Task(string name, string text)
        {
            Name = name;
            Text = text;
        }
        public string Name { get; set; }
        public string Text { get; set; }
        private string path;
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
                if (path != null)
                    Image = new Bitmap(path);
                else
                    Image = null;
                RaisePropertyChangedEvent("Image");
               
            }
        }
        public Bitmap Image { get; set; }


        public async void NewImage(Window parent)
        {
            var openFileDialog = new OpenFileDialog().ShowAsync(parent);
            string[]? path = await openFileDialog;
            try
            {
                string Path = string.Join(@"\", path);
                this.Path = Path;
            }
            catch
            {
                Path=null;
            }
        }

        internal bool Search(Task task)
        {
            if (task.Name == Name && task.Text == Text&&task.Path==Path)
                return true;
            return false;
        }
    }
}
