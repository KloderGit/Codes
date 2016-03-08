using System;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using System.ComponentModel;

namespace CodesControl.ViewModel
{
    public class Control_ViewModel
    {

        private ObservableCollection<ViewModel.ItemUserCodes_ViewModel> itemsArray;
        private ICollectionView allItems;
        private ICollectionView changeItems;

        private ObservableCollection<Model.EducationType> educationTypesArray;
        private ICollectionView educationTypes;

        private string filterCollection;

        public string FilterCollection {
            get { return this.filterCollection; }
            set 
            {
                filterCollection = value;
            }
        }

        public Control_ViewModel()
        {
            itemsArray = new ObservableCollection<ViewModel.ItemUserCodes_ViewModel>(new SomeData().GetItems());
            allItems = new CollectionViewSource { Source = itemsArray }.View;

            changeItems = new CollectionViewSource { Source = itemsArray }.View;
            changeItems.Filter = OneFilter;

            educationTypesArray = new ObservableCollection<Model.EducationType>(CodesTypePrepare());
            educationTypes = new CollectionViewSource { Source = educationTypesArray }.View;
            educationTypes.CurrentChanged += delegate { allItems.Filter = FilterForAviableCollection; this.filterCollection = ""; };
            
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
            bool result = false;
            ViewModel.ItemUserCodes_ViewModel i = item as ViewModel.ItemUserCodes_ViewModel;
            if (i.EducationType.Equals("Заочник")) { result = true; }
            return result;            
        }

        private List<Model.EducationType> CodesTypePrepare()
        {
                var group = itemsArray.GroupBy(g=>g.EducationType);
                var list = from type in @group select new Model.EducationType(type.Key, type.ToList().Count);
                return list.ToList();
        }

        private bool FilterForAviableCollection(object item)
        {
            Model.EducationType type = (Model.EducationType)educationTypes.CurrentItem;
            bool result = false;
            ViewModel.ItemUserCodes_ViewModel i = item as ViewModel.ItemUserCodes_ViewModel;

            string i1 = "";
            string i2 = ""; 

            if ( !String.IsNullOrEmpty(this.filterCollection) )
            {
                i1 = (i.UserName + i.UserLastName).ToUpper();
                i2 = this.filterCollection.ToUpper();
            }

            if (i.EducationType.Equals(type.Title) && i1.Contains(i2) ) { result = true; }

            return result;
        }


    }
}
