using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections.Specialized;
using CodesADONet;

namespace CodesControl.ViewModel
{
    public class Control_ViewModel : ViewModelBase
    {

        private ObservableCollection<Student_ViewModel> itemsArray;
        private ICollectionView allItems;

        private List<Student_ViewModel> changeArray;
        private ICollectionView changeItems;

        private ObservableCollection<Model.EducationType> educationTypesArray;
        private ICollectionView educationTypes;

        private string filterCollection;

        public string StringForFilterCollection {
            get { return this.filterCollection; }
            set 
            {
                this.filterCollection = value;
                OnPropertyChanged("StringForFilterCollection");
                allItems.Filter = FilterForAviableCollection;
            }
        }

        public Control_ViewModel()
        {
            itemsArray = new ObservableCollection<Student_ViewModel>(new SomeData().GetItems());

            var m = new CodesADONet.MySql_SSH_Connection();

            foreach (var item in itemsArray)
            {
                item.OnHasBuckup += HasChanged;
            }

            educationTypesArray = new ObservableCollection<Model.EducationType>(CodesTypePrepare());
            educationTypes = new CollectionViewSource { Source = educationTypesArray }.View;
            educationTypes.CurrentChanged += delegate {
                Console.WriteLine("Смена Статусного списка");
                this.StringForFilterCollection = null;
                //allItems.Filter = FilterForAviableCollection;
            };

            allItems = new CollectionViewSource { Source = itemsArray }.View;
            allItems.CurrentChanged += delegate {
                Console.WriteLine("Смена гланого списка");
            };

            //changeItems = new CollectionViewSource { Source = itemsArray }.View;
            //changeItems.CollectionChanged += delegate {
            //    Console.WriteLine("Смена состава второго списка");
            //};
            //changeItems.Filter = OneFilter;

            changeArray = new List<Student_ViewModel>();

        }

        public ICollectionView AviableCollection
        {
            get { return this.allItems; }
        }

        public ICollectionView DifferentCollection
        {
            get { return this.changeItems; }
        }

        public ICollectionView CodesType
        {
            get { return this.educationTypes; }
        }

        private bool OneFilter(object item)
        {
            ViewModel.Student_ViewModel i = item as ViewModel.Student_ViewModel;
            return i.HasBuckup;
        }

        private List<Model.EducationType> CodesTypePrepare()
        {
            var listTypes = new List<Model.EducationType>();
            listTypes.Add(new Model.EducationType("Все статусы", this.itemsArray.Count));

            var group = itemsArray.GroupBy(g=>g.EducationType);
            var list = from type in @group select new Model.EducationType(type.Key, type.ToList().Count);
            listTypes.AddRange(list);

            return listTypes;
        }

        private bool FilterForAviableCollection(object _item)
        {
            var item = _item as ViewModel.Student_ViewModel;
            var type = (Model.EducationType)educationTypes.CurrentItem;

            string i1, i2;
            bool typeCorrect = true, stringCorrect = true;

            if (!String.IsNullOrEmpty(this.filterCollection))
            {
                i1 = (item.UserName + item.UserLastName + item.UserParentName + item.Code).ToUpper();
                i2 = this.filterCollection.ToUpper();

                if ( !i1.Contains(i2) ) { stringCorrect = false; }
            }

            if (type != null)
            {
                if (type.Title == "Все статусы")
                {
                    typeCorrect = true;
                }
                else
                {
                    if (!item.EducationType.Equals(type.Title)) { typeCorrect = false; }
                }                
            }

            return typeCorrect & stringCorrect;
        }

        private void HasChanged()
        {
            Console.WriteLine("Перетасовка списка");
            var _list = from i in this.itemsArray where i.HasBuckup select i;
            changeArray = _list.ToList();

            changeItems = new ListCollectionView(changeArray);

            changeItems.Refresh();
            OnPropertyChanged("DifferentCollection");

            changeItems.CurrentChanged += delegate { Console.WriteLine("Второй куррент изменен!"); };
        }

    }
}
