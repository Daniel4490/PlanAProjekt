﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PlanA.BaseClasses;
using PlanA.CatalogClasses;
using PlanA.ProductClasses;
using PlanA.ViewModels;

namespace PlanA.CommandClasses
{
    class CreateProductCommand : ICommand
    {
        private ProductBase _product;
        private ProductCatalog _productCatalog;

        public CreateProductCommand(ProductBase product, ProductCatalog productCatalog)
        {
            _product = product;
            _productCatalog = productCatalog;
        }

        public bool CanExecute(object parameter)
        {
            if (_productCatalog.GetProductCatalog.ContainsKey(_product.ProductID))
            {
                return false;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            _productCatalog.AddProduct(_product.ProductID, _product);
        }

        public event EventHandler CanExecuteChanged;
    }
}
