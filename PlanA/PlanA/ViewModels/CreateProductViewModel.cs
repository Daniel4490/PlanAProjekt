﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PlanA.BaseClasses;
using PlanA.CatalogClasses;
using PlanA.CommandClasses;
using PlanA.ProductClasses;

namespace PlanA.ViewModels
{
    class CreateProductViewModel : INotifyPropertyChanged
    {
        private CreateProductCommand _createProductCommand;
        private ProductCatalog _productCatalog = ProductCatalog.SingletonInstance;
        private ProductBase _selectedProductType;
        private Dictionary<string, ProductBase> _allProductTypes;

        private bool _isPaintType = false;
        private bool _isPuttyType = false;

        public CreateProductViewModel()
        {
            _allProductTypes = new Dictionary<string, ProductBase>();


            _createProductCommand = new CreateProductCommand(_selectedProductType, _productCatalog);

        }
        public Dictionary<string, ProductBase> AllProductTypes => _allProductTypes;
        public CreateProductCommand CreateProductCommand => _createProductCommand;

        public ProductBase SelectedProductType
        {
            get { return _selectedProductType; }
            set
            {
                _selectedProductType = value;
                SetTextEnabled(_selectedProductType);
                OnPropertyChanged();
            }
        }

        public void SetTextEnabled(ProductBase productType)
        {
            if (productType.Equals(_allProductTypes["Paint"]))
            {
                _isPaintType = true;
            }
            else if (productType.Equals(_allProductTypes["Putty"]))
            {
                _isPuttyType = true;
            }
        }

        public bool IsPaintType => _isPaintType;
        public bool IsPuttyType => _isPuttyType;

        public string ProductDescription
        {
            get { return _selectedProductType.Description; }
            set
            {
                _selectedProductType.Description = value;
                OnPropertyChanged();
            }
        }

        public int Quantity
        {
          get { return _selectedProductType.Quantity; }
            set
            {
                _selectedProductType.Quantity = value;
                OnPropertyChanged();
            }
        }

        public string SpecificType
        {
            get { return _selectedProductType.SpecificType; }
            set
            {
                _selectedProductType.SpecificType = value;
                OnPropertyChanged();
            }
        }

        // Properties til unikke produkter (Paint og Putty)
        public int Glans
        {
            get { return _selectedProductType.Gloss; }
            set
            {
                _selectedProductType.Gloss = value;
                OnPropertyChanged();
            }
        }

        public bool InDoor
        {
            get { return _selectedProductType.InDoor; }
            set
            {
                _selectedProductType.InDoor = value;
                OnPropertyChanged();
            }
        }

        public string Coarse
        {
            get { return _selectedProductType.Coarse; }
            set
            {
                _selectedProductType.Coarse = value;
                OnPropertyChanged();
            }
        }

        private bool _malingGridIsVisible;
        private bool _spartelGridIsVisible;

        public enum ProductChosen
        {
            Maling,
            Spartel
        }

        private ProductChosen _selectedProduct;

        public ProductChosen EnummProductStatus
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                SetGridShown(value);
                OnPropertyChanged();
            }
        }

        public void SetGridShown(ProductChosen value)
        {
            if (value == ProductChosen.Maling)
            {
                MalingGridIsVisible = true;
                SpartelGridIsVisible = false;
            }
            else if (value == ProductChosen.Spartel)
            {
                MalingGridIsVisible = false;
                SpartelGridIsVisible = true;
            }
        }

        public bool MalingGridIsVisible
        {
            get => _malingGridIsVisible;
            set { _malingGridIsVisible = value; OnPropertyChanged(); }
        }

        public bool SpartelGridIsVisible
        {
            get => _spartelGridIsVisible;
            set { _spartelGridIsVisible = value; OnPropertyChanged(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
