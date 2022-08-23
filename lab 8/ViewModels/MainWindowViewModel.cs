using Avalonia.Controls;
using lab_8.Models;
using Newtonsoft.Json;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace lab_8.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Item = new ObservableCollection<Task>[3] { new ObservableCollection<Task>(),
                                                       new ObservableCollection<Task>(), 
                                                       new ObservableCollection<Task>() };
            index = 0;
        }
        private ObservableCollection<Task>[] item;
        public ObservableCollection<Task>[] Item
        {
            get
            {
                return item;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref item, value);
            }
        }

        private string path;
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref path, value);
            }
        }



        public void DeleteTask0(Task task)
        {
            for (int i = 0; i < Item[0].Count; i++)
            {
                if (Item[0][i].Search(task) == true)
                {
                    Item[0].RemoveAt(i);
                    break;
                }
            }
        }
        public void DeleteTask1(Task task)
        {
            for (int i = 0; i < Item[1].Count; i++)
            {
                if (Item[0][i].Search(task) == true)
                {
                    Item[0].RemoveAt(i);
                    break;
                }
            }
        }
        public void DeleteTask2(Task task)
        {
            for (int i = 0; i < Item[2].Count; i++)
            {
                if (Item[0][i].Search(task) == true)
                {
                    Item[0].RemoveAt(i);
                    break;
                }
            }
        }
        private static int i;
        private static int index
        {
            set
            {
                i = value;
            }
            get
            {
                i++;
                return i;
            }
        }
        public void AddTask0()
        {
            string str = "Новая задача " + index;
            Item[0].Add(new Task(str, ""));
        }
        public void AddTask1()
        {
            string str = "Новая задача " + index;
            Item[1].Add(new Task(str, ""));
        }
        public void AddTask2()
        {
            string str = "Новая задача " + index;
            Item[2].Add(new Task(str, ""));
        }
        public void New()
        {
            foreach (var i in Item)
                i.Clear();
        }
        public void MenuLoad(string Path)
        {
            var str = File.ReadAllText(Path);
            if (str != null)
            {
                Item = JsonConvert.DeserializeObject<ObservableCollection<Task>[]> (str);
            }

        }
        public void MenuSave(string Path)
        {
                File.WriteAllText(Path, JsonConvert.SerializeObject(Item));
        }

    }
}
