using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodesControl.ViewModel
{
    public class ItemUserCodes_ViewModel : ViewModelBase
    {
        Model.ItemUserCodes_Model ItemModel;

        // Коструктор
        public ItemUserCodes_ViewModel(Model.ItemUserCodes_Model model)
        {
            this.ItemModel = model;
        }



        //Поля для чтения класса пользователя
        public Int32 UserId { get { return ItemModel.User.ID; } }
        public string UserName { get { return ItemModel.User.Name; } }
        public string UserLastName { get { return ItemModel.User.LastName; } }
        public string UserParentName { get { return ItemModel.User.ParentName; } }
        public string UserEmail { get { return ItemModel.User.Email; } }
        public string UserLogin { get { return ItemModel.User.Login; } }
        public string UserPhone { get { return ItemModel.User.Phone; } }
        public string UserSkype { get { return ItemModel.User.Skype; } }
        // Поля для изменения
        public string UserEducationType
        {
            get
            {
                string type = "Не определён";
                if (ItemModel.User.EducationType == "S") { type = "Студент"; }
                if (ItemModel.User.EducationType == "Z") { type = "Заочник"; }
                if (ItemModel.User.EducationType == "V") { type = "Выпускник"; }
                return type;
            }
            set
            {
                if (value != ItemModel.User.EducationType)
                {
                    ItemModel.User.EducationType = value; ItemModel.Code.EducationType = value;
                    OnPropertyChanged("UserEducationType");
                }
            }
        }

        public string UserCode
        {
            get
            {
                return ItemModel.User.Code;
            }
            set
            {
                if (value != ItemModel.User.Code)
                {
                    ItemModel.User.Code = value; ItemModel.Code.Code = value;
                    OnPropertyChanged("UserCode");
                }
            }
        }

        //Поля для чтения класса кодов
        public Int32 CodeId { get { return ItemModel.Code.Id; } }
        public bool CodeActive { get { return ItemModel.Code.Active; } }

        public string CodeEducationType
        {
            get
            {
                return ItemModel.Code.EducationType;
            }
            set
            {
                if (value != ItemModel.Code.EducationType)
                {
                    ItemModel.Code.EducationType = value; ItemModel.User.EducationType = value;
                    OnPropertyChanged("CodeEducationType");
                }
            }
        }

        public string CodeCode
        {
            get
            {
                return ItemModel.Code.Code;
            }
            set
            {
                if (value != ItemModel.Code.Code)
                {
                    ItemModel.Code.Code = value; ItemModel.User.Code = value;
                    OnPropertyChanged("CodeCode");
                }
            }
        }

        public DateTime CodeExpirationDate
        {
            get
            {
                return ItemModel.Code.ExpirationDate;
            }
            set
            {
                if (value != ItemModel.Code.ExpirationDate)
                {
                    ItemModel.Code.ExpirationDate = value;
                    OnPropertyChanged("CodeExpirationDate");
                }
            }
        }


    }
}